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
            // speed, armor and laser strength. 
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

                // We set up initial values for properties not specified by the AI...
                setupInitialValues(swarmInfo);
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
                droneInfo.Armor = droneInfo.InitialArmor;
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
            var totalPoints = droneInfos.Sum(x => x.InitialArmor + x.InitialLaserStrength + x.InitialSpeed);
            if(totalPoints > m_totalPoints)
            {
                throw new Exception($"{swarmInfo.Name} has created allocated too many points ({totalPoints} > {m_totalPoints})");
            }

            // We check that no negative points have been allocated...
            if(droneInfos.Any(x => x.InitialArmor < 0 || x.InitialLaserStrength < 0 || x.InitialSpeed < 0))
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

        #endregion
    }
}
