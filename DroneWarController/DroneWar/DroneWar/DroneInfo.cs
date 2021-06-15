﻿using System.Drawing;

namespace DroneWar
{
    /// <summary>
    /// Info about one drone: speed, shields, laser etc.
    /// </summary>
    public class DroneInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the initial speed of the drone, at the time it was created.
        /// </summary>
        public int InitialSpeed { get; set; } = 0;

        /// <summary>
        /// Gets or sets the initial health of the drone, at the time it was created.
        /// </summary>
        public int InitialHealth { get; set; } = 0;

        /// <summary>
        /// Gets or sets the initial shields of the drone, at the time it was created.
        /// </summary>
        public int InitialShields { get; set; } = 0;

        /// <summary>
        /// Gets or sets the initial laser strength of the drone, at the time it was created.
        /// </summary>
        public int InitialLaserStrength { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current speed of the drone.
        /// </summary>
        public int Speed { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current health of the drone.
        /// </summary>
        public int Health { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current shields of the drone.
        /// </summary>
        public int Shields { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current laser strength of the drone.
        /// </summary>
        public int LaserStrength { get; set; } = 0;

        /// <summary>
        /// Gets the position of the drone in game-space.
        /// </summary>
        public GameSpacePoint Position { get; set; } = new GameSpacePoint();

        #endregion
    }
}
