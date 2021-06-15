namespace DroneWar
{
    /// <summary>
    /// A movement request for one drone.
    /// </summary><remarks>
    /// You specify:
    /// - The index of the drone to move
    /// - A point in the game space towards which you want the drone to move
    /// 
    /// Depending on the drone's speed, it will be moved some way towards 
    /// the requested point. If the drone is close enough, it will reach the
    /// point. Even if the drone's speed is high, it will not overshoot the 
    /// requested point.
    /// </remarks>
    public class MovementRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the index of the drone to be moved.
        /// </summary>
        public int DroneIndex { get; set; } = 0;

        /// <summary>
        /// Gets the target point towards which you the drone should move.
        /// </summary>
        public GameSpacePoint Target { get; } = new GameSpacePoint();

        #endregion
    }
}
