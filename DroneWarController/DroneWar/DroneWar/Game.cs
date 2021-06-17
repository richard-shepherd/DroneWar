using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DroneWar
{
    /// <summary>
    /// Manages one drone-war game.
    /// </summary><remarks>
    /// Holds the game-state and connections to two or more swarm AIs.
    /// 
    /// Manages the interaction with the AIs and the update of the game
    /// state depending on the actions of the AIs.
    /// </remarks>
    public class Game
    {
        #region Properties

        /// <summary>
        /// Gets the game state.
        /// </summary>
        public GameState GameState => m_gameState;

        /// <summary>
        /// Gets performance stats.
        /// </summary>
        public PerformanceStats PerformanceStats { get; } = new PerformanceStats();

        /// <summary>
        /// Gets or sets whether the game is over.
        /// </summary>
        public bool GameOver { get; set; } = false;

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public Game(List<ISwarmAI> swarmAIs, int maxDrones)
        {
            m_swarmAIs = swarmAIs;
            m_maxDrones = maxDrones;
            m_totalPoints = maxDrones * 3 * 100;

            // We set up the swarms into their start-of-game configuration...
            setupSwarms();
        }

        /// <summary>
        /// Plays one turn of the game.
        /// </summary>
        public void playOneTurn()
        {
            if(GameOver)
            {
                return;
            }

            moveDrones();
            playAttackPhase();
            rechargeLasers();
            checkForGameOver();
            PerformanceStats.onTurnCompleted();
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        private void checkForGameOver()
        {
            GameOver = m_gameState.SwarmInfos.Any(x => x.DroneInfos.Count(d => !d.IsDead) == 0);
        }

        /// <summary>
        /// Recharges each drone's laser by 1%.
        /// </summary>
        private void rechargeLasers()
        {
            foreach(var swarmInfo in m_gameState.SwarmInfos)
            {
                foreach(var droneInfo in swarmInfo.DroneInfos)
                {
                    droneInfo.LaserStrength += (droneInfo.InitialLaserStrength / 100.0);
                    if(droneInfo.LaserStrength > droneInfo.InitialLaserStrength)
                    {
                        droneInfo.LaserStrength = droneInfo.InitialLaserStrength;
                    }
                }
            }
        }

        /// <summary>
        /// Requests movements from each AI and applies them to the drones.
        /// </summary>
        private void moveDrones()
        {
            // We get requested movements from each AI...
            var movementRequestsPerIndex = new Dictionary<int, List<MovementRequest>>(); 
            var numAIs = m_swarmAIs.Count;
            for(var aiIndex=0; aiIndex < numAIs; ++aiIndex)
            {
                var swarmAI = m_swarmAIs[aiIndex];
                movementRequestsPerIndex[aiIndex] = swarmAI.moveDrones(m_gameState, aiIndex);
            }

            // We apply the movements to the drones. 
            // Note: This is done as a separate phase so that the same game state is passed
            //       to each AI above.
            foreach(var pair in movementRequestsPerIndex)
            {
                var aiIndex = pair.Key;
                var movementRequests = pair.Value;
                applyRequestedMovements(movementRequests, aiIndex);
            }
        }

        /// <summary>
        /// Plays the attack phase and updates the health of the drones.
        /// </summary>
        private void playAttackPhase()
        {
            // We get requested attacks from each AI...
            var attackRequestsPerIndex = new Dictionary<int, List<AttackRequest>>();
            var numAIs = m_swarmAIs.Count;
            for (var aiIndex = 0; aiIndex < numAIs; ++aiIndex)
            {
                var swarmAI = m_swarmAIs[aiIndex];
                attackRequestsPerIndex[aiIndex] = swarmAI.attack(m_gameState, aiIndex);
            }

            // We make the attacks. 
            // Note: This is done as a separate phase so that the same game state is passed
            //       to each AI above.
            foreach (var pair in attackRequestsPerIndex)
            {
                var aiIndex = pair.Key;
                var attackRequests = pair.Value;
                applyRequestedAttacks(attackRequests, aiIndex);
            }
        }

        /// <summary>
        /// Applies the requested attacking actions from the drones whose Ai index is passed in.
        /// </summary>
        private void applyRequestedAttacks(List<AttackRequest> attackRequests, int aiIndex)
        {
            // TODO: Validate attack requests

            var drones = m_gameState.SwarmInfos[aiIndex].DroneInfos;
            foreach(var attackRequest in attackRequests)
            {
                // We find the attacking drone...
                var attackingSwarm = m_gameState.SwarmInfos[aiIndex];
                var attackingDrone = attackingSwarm.DroneInfos[attackRequest.AttackingDroneIndex];

                // We find the target drone...
                var targetSwarm = m_gameState.SwarmInfos[attackRequest.TargetSwarmIndex];
                var targetDrone = targetSwarm.DroneInfos[attackRequest.TargetDroneIndex];

                // The attack force decreases with distance, so we find the distance between 
                // the drones. Drones have to be relatively close before attacks have any effect.
                var distanceInfo = attackingDrone.Position.distanceTo(targetDrone.Position);
                if(distanceInfo.Distance > Constants.MINIMUM_DISTANCE_FOR_ATTACKS)
                {
                    continue;
                }
                var damageMultiplier = 1.0 - distanceInfo.Distance / Constants.MINIMUM_DISTANCE_FOR_ATTACKS;
                var damage = attackingDrone.LaserStrength * damageMultiplier * 0.1;

                // The target drone first takes damage to its shields. If there are no shields
                // left, rememining damage is taken from its health...
                targetDrone.Shields -= damage;
                if(targetDrone.Shields < 0.0)
                {
                    targetDrone.Health += targetDrone.Shields;
                    targetDrone.Shields = 0.0;
                }

                // We reset the attacking drone's laser strength to zero. It will recharge
                // over time...
                attackingDrone.LaserStrength = 0.0;
            }
        }

        /// <summary>
        /// Applies the requested movements to the drones from the swarm whose index is passed in.
        /// </summary>
        private void applyRequestedMovements(List<MovementRequest> movementRequests, int aiIndex)
        {
            // TODO: Validate the movement requests
            // eg, make sure that the same drone is not specified multiple times
            var drones = m_gameState.SwarmInfos[aiIndex].DroneInfos;
            foreach (var movementRequest in movementRequests)
            {
                var drone = drones[movementRequest.DroneIndex];
                var speed = drone.Speed * 50.0;
                drone.Position = drone.Position.moveTowards(movementRequest.Target, speed);
            }
        }

        /// <summary>
        /// Sets up the swarms into their start-of-game configuration.
        /// </summary><remarks>
        /// Includes asking each AI to set up its collection of drones, distributing
        /// abilities between them.
        /// </remarks>
        private void setupSwarms()
        {
            // We ask each AI to set up its drones. The AIs are given 300 points
            // multiplied by the number of drones, and can distribute this across
            // speed, shields and laser strength. 
            //
            // So for example, they could give each drone 100 points in each category.
            // Or they could give some drones greater values in some categories and
            // less in others.
            //
            // AIs do not have to create the maximum number of drones. They could choose
            // to create fewer drones and give them more 'tank-like' abilities.
            var numAIs = m_swarmAIs.Count;
            for (var aiIndex = 0; aiIndex < numAIs; ++aiIndex)
            {
                var ai = m_swarmAIs[aiIndex];

                // We set up a swarm-info for each AI...
                var swarmInfo = new SwarmInfo();
                swarmInfo.Name = ai.getAIName();
                swarmInfo.Color = m_swarmColors[aiIndex];

                // We get the AI to set up the swarm, and validate the results...
                swarmInfo.DroneInfos = ai.setupDroneInfos(m_maxDrones, m_totalPoints);
                validateSwarm(swarmInfo);

                // We set up initial values for properties not specified by the AI, and 
                // we set up the swarm's initial position in the game space...
                setupInitialValues(swarmInfo);
                setupInitialPositions(swarmInfo, aiIndex);

                // We add the swarm-info to the game...
                m_gameState.SwarmInfos.Add(swarmInfo);
            }
        }

        /// <summary>
        /// Sets up the swarm's intiial position in the game space.
        /// </summary>
        private void setupInitialPositions(SwarmInfo swarmInfo, int aiIndex)
        {
            // We set up the drones in random positions along the left, right,
            // top or bottom of the space depending on the AI number...
            double minX, maxX, minY, maxY;
            switch(aiIndex)
            {
                // AI 0 starts on the left...
                case 0:
                    minX = 0.0;
                    maxX = Constants.SPACE_SIZE_X / 10.0;
                    minY = 0.0;
                    maxY = Constants.SPACE_SIZE_Y;
                    break;

                // AI 1 starts on the right...
                case 1:
                    minX = Constants.SPACE_SIZE_X - Constants.SPACE_SIZE_X / 10.0;
                    maxX = Constants.SPACE_SIZE_X;
                    minY = 0.0;
                    maxY = Constants.SPACE_SIZE_Y;
                    break;

                // AI 2 starts on at the top...
                case 2:
                    minX = 0.0;
                    maxX = Constants.SPACE_SIZE_X;
                    minY = 0.0;
                    maxY = Constants.SPACE_SIZE_Y / 10.0;
                    break;

                // AI 3 starts at the bottom...
                case 3:
                    minX = 0.0;
                    maxX = Constants.SPACE_SIZE_X;
                    minY = Constants.SPACE_SIZE_Y - Constants.SPACE_SIZE_Y / 10.0;
                    maxY = Constants.SPACE_SIZE_Y;
                    break;

                default:
                    throw new Exception($"Unhandled AI-index: {aiIndex}");
            }

            foreach(var droneInfo in swarmInfo.DroneInfos)
            {
                droneInfo.Position.X = Utils.rnd(minX, maxX);
                droneInfo.Position.Y = Utils.rnd(minY, maxY);
            }
        }

        /// <summary>
        /// Sets up intial values for the start of game for the properties
        /// of the swarm which are not set up by the AI.
        /// </summary>
        private void setupInitialValues(SwarmInfo swarmInfo)
        {
            foreach(var droneInfo in swarmInfo.DroneInfos)
            {
                droneInfo.InitialHealth = Constants.INITIAL_HEALTH;
                droneInfo.Health = droneInfo.InitialHealth;
                droneInfo.LaserStrength = droneInfo.InitialLaserStrength;
                droneInfo.Shields = droneInfo.InitialShields;
                droneInfo.Speed = droneInfo.InitialSpeed;
            }
        }

        /// <summary>
        /// Validates a collection of drone infos.
        /// Throws an exception if the swarm is not valid.
        /// </summary>
        private void validateSwarm(SwarmInfo swarmInfo)
        {
            // We check the number of drones...
            var droneInfos = swarmInfo.DroneInfos;
            var numDrones = droneInfos.Count;
            if(numDrones > m_maxDrones)
            {
                throw new Exception($"{swarmInfo.Name} has created too many drones ({numDrones} > {m_maxDrones})");
            }

            // We check the total points allocated...
            var totalPoints = droneInfos.Sum(x => x.InitialShields + x.InitialLaserStrength + x.InitialSpeed);
            if(totalPoints > m_totalPoints)
            {
                throw new Exception($"{swarmInfo.Name} has created allocated too many points ({totalPoints} > {m_totalPoints})");
            }

            // We check that no negative points have been allocated...
            if(droneInfos.Any(x => x.InitialShields < 0 || x.InitialLaserStrength < 0 || x.InitialSpeed < 0))
            {
                throw new Exception($"{swarmInfo.Name} has allocated negative values");
            }
        }

        #endregion

        #region Private data

        // Construction params...
        private readonly List<ISwarmAI> m_swarmAIs;
        private readonly int m_maxDrones;

        // The total number of points which each AI can allocate to its drones...
        private readonly int m_totalPoints;

        // The game state - includes the positions, strength etc of the drones in the game...
        private readonly GameState m_gameState = new GameState();

        // Colors to assign to AIs...
        private readonly List<Color> m_swarmColors = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        // Generates random values - such as the intial positions of drones...
        private readonly Random m_rnd = new Random();

        #endregion
    }
}
