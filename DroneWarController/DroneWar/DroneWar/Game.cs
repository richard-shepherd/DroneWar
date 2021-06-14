using System.Collections.Generic;

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
            // speed, armour and laser strength. 
            //
            // So for example, they could give each drone 100 points in each category.
            // Or they give some drones greater values in some categories and less in
            // others.
            //
            // AIs do not have to create the maximum number of drones. They could choose
            // to create fewer drones and give them more 'tank-like' abilities.

        }

        #endregion

        #region Private data

        // Construction params...
        private readonly List<ISwarmAI> m_swarmAIs;
        private readonly int m_maxDrones;

        // The game state - includes the positions, strength etc of the drones in the game...
        private readonly GameState m_gameState = new GameState();

        #endregion
    }
}
