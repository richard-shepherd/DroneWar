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
        }

        /// <summary>
        /// Plays one turn of the game.
        /// </summary>
        public void playOneTurn()
        {

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
