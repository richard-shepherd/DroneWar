namespace DroneWar
{
    /// <summary>
    /// A request to fire a laser.
    /// </summary>
    public class AttackRequest
    {
        #region Properties

        /// <summary>
        /// The index of the drone from your swarm which is firing its laser.
        /// </summary>
        public int AttackingDroneIndex { get; set; } = 0;

        /// <summary>
        /// The index of the swarm being targeted.
        /// </summary>
        public int TargetSwarmIndex { get; set; } = 0;

        /// <summary>
        /// The index of the drone being targeted.
        /// </summary>
        public int TargetDroneIndex { get; set; } = 0;

        #endregion
    }
}
