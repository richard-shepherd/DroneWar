using System.Collections.Generic;

namespace DroneWar
{
    /// <summary>
    /// Holds the game state, including the position, size and strength of the drones.
    /// </summary>
    public class GameState
    {
        #region Properties

        /// <summary>
        /// Gets info for each drone-swarm in the game.
        /// </summary>
        public List<SwarmInfo> SwarmInfos { get; } = new List<SwarmInfo>();

        #endregion
    }
}
