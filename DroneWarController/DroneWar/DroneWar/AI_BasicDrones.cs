﻿using System.Collections.Generic;

namespace DroneWar
{
    /// <summary>
    /// An Ai which creates a swarm of identical drones, which
    /// always try to attack.
    /// </summary>
    public class AI_BasicDrones : ISwarmAI
    {
        #region ISwarmAI implementation

        /// <summary>
        /// Sets up the swarm.
        /// </summary>
        public List<DroneInfo> setupSwarm(int maxDrones, int totalPoints)
        {
            // We allocate equal points to each drone property...
            var pointsPerProperty = totalPoints / (maxDrones * 3);

            // We set up the maximum number of drones, each with equal properties...
            var swarm = new List<DroneInfo>();
            for(var i=0; i<maxDrones; ++i)
            {
                var droneInfo = new DroneInfo();
                droneInfo.InitialArmour = pointsPerProperty;
                droneInfo.InitialLaserStrength = pointsPerProperty;
                droneInfo.InitialSpeed = pointsPerProperty;
                swarm.Add(droneInfo);
            }

            return swarm;
        }

        #endregion
    }
}