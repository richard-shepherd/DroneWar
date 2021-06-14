﻿namespace DroneWar
{
    /// <summary>
    /// Info about one drone: speed, armour, laser etc.
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
        /// Gets or sets the initial armour of the drone, at the time it was created.
        /// </summary>
        public int InitialArmour { get; set; } = 0;

        /// <summary>
        /// Gets or sets the initial laser strength of the drone, at the time it was created.
        /// </summary>
        public int InitialLaserStrength { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current health of the drone.
        /// </summary>
        public int Health { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current armour of the drone.
        /// </summary>
        public int Armour { get; set; } = 0;

        /// <summary>
        /// Gets or sets the x-coordinate of the drone.
        /// </summary>
        public int X { get; set; } = 0;

        /// <summary>
        /// Gets or sets the y-coordinate of the drone.
        /// </summary>
        public int Y { get; set; } = 0;

        #endregion
    }
}