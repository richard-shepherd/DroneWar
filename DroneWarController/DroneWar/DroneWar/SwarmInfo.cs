using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DroneWar
{
    /// <summary>
    /// Info for a drone swarm - ie, for one team of drones.
    /// </summary>
    public class SwarmInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the swarm - ie, the team name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the color used when showing the swarm.
        /// </summary>
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Gets info for each drone in the swarm.
        /// </summary>
        public List<DroneInfo> DroneInfos { get; set; } = new List<DroneInfo>();

        /// <summary>
        /// Gets the number of alive drones in the swarm.
        /// </summary>
        public int NumberAliveDrones => DroneInfos.Count(x => x.IsAlive);

        #endregion
    }
}
