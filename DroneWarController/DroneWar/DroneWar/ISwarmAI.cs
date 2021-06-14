using System.Collections.Generic;

namespace DroneWar
{
    /// <summary>
    /// Interface for swarm AIs.
    /// </summary>
    public interface ISwarmAI
    {
        /// <summary>
        /// Returns the name of the AI.
        /// </summary>
        public string getAIName();

        /// <summary>
        /// Called at the start of a game to set up the swarm of drones.
        /// </summary><remarks>
        /// Your return a DroneInfo object for each drone in your swarm.
        /// 
        /// You can create up to maxDrones drones, but you can create fewer 
        /// if you want to.
        /// 
        /// For each drone you should set:
        /// - InitialSpeed
        /// - IntialShields
        /// - InitialLaserStrength
        /// 
        /// You can set these to any values you like, but you cannot exceed
        /// the totalPoints provided as the total of all properties across
        /// the whole swarm of drones.
        /// 
        /// For example:
        /// - maxDrones = 100
        /// - points    = 30000
        /// 
        /// Swarm: 100 drones x (speed=100, shields=100, laser=100)
        /// OR
        /// Swarm: 50 drones x  (speed=100, shields=200, laser=300)
        /// 
        /// You can mix and match drones as you like, as long as the total points is
        /// no greater than the totalPoints provided. You do not need to create all drones
        /// the same as in the examples above. For example, you could create 10 powerful
        /// drones and 30 smaller drones.
        /// 
        /// You cannot create drones with negative values in any category.
        /// </remarks>
        public List<DroneInfo> setupDroneInfos(int maxDrones, int totalPoints);
    }
}
