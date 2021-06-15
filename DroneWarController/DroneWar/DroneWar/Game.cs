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
        /// Gets the swarm-infos.
        /// </summary>
        public List<SwarmInfo> SwarmInfos { get; private set; } = new List<SwarmInfo>();

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

        }

        #endregion

        #region Private functions

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
                SwarmInfos.Add(swarmInfo);
            }
        }

        /// <summary>
        /// Sets up the swarm's intiial position in the game space.
        /// </summary>
        private void setupInitialPositions(SwarmInfo swarmInfo, int aiIndex)
        {
            // We set up the drones in random positions along the left, right,
            // top or bottom of the space depending on the AI number...
            int minX, maxX, minY, maxY;
            switch(aiIndex)
            {
                // AI 0 starts on the left...
                case 0:
                    minX = 0;
                    maxX = Constants.SPACE_SIZE_X / 10;
                    minY = 0;
                    maxY = Constants.SPACE_SIZE_Y;
                    break;

                // AI 1 starts on the right...
                case 1:
                    minX = Constants.SPACE_SIZE_X - Constants.SPACE_SIZE_X / 10;
                    maxX = Constants.SPACE_SIZE_X;
                    minY = 0;
                    maxY = Constants.SPACE_SIZE_Y;
                    break;

                default:
                    throw new Exception($"Unhandled AI-index: {aiIndex}");
            }

            foreach(var droneInfo in swarmInfo.DroneInfos)
            {
                droneInfo.Position.X = m_rnd.Next(minX, maxX);
                droneInfo.Position.Y = m_rnd.Next(minY, maxY);
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
                droneInfo.Shields = droneInfo.InitialShields;
                droneInfo.Health = Constants.INITIAL_HEALTH;
                droneInfo.InitialHealth = Constants.INITIAL_HEALTH;
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
