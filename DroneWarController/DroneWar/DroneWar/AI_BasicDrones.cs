using System;
using System.Collections.Generic;
using System.Drawing;

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
        /// Returns the AI's name.
        /// </summary>
        public string getAIName()
        {
            return "BasicDrones";
        }

        /// <summary>
        /// Sets up the swarm.
        /// </summary>
        public List<DroneInfo> setupDroneInfos(int maxDrones, int totalPoints)
        {
            // We allocate equal points to each drone property...
            var pointsPerProperty = totalPoints / (maxDrones * 3);

            // We set up the maximum number of drones, each with equal properties...
            var swarm = new List<DroneInfo>();
            for(var i=0; i<maxDrones; ++i)
            {
                var droneInfo = new DroneInfo();

                var offset = m_rnd.Next(-50, 50);
                droneInfo.InitialShields = pointsPerProperty + offset;
                droneInfo.InitialLaserStrength = pointsPerProperty;
                droneInfo.InitialSpeed = pointsPerProperty - offset;
                swarm.Add(droneInfo);
            }

            return swarm;
        }

        /// <summary>
        /// Moves the drones.
        /// </summary><remarks>
        /// Each drone targets the drone with the corresponding index in the enemy swarm.
        /// </remarks>
        public List<MovementRequest> moveDrones(GameState gameState, int swarmIndex)
        {
            var movementRequests = new List<MovementRequest>();

            // We find the index of the enemy swarm. If there are more than two players,
            // we always target the 'next' swarm...
            var swarmInfos = gameState.SwarmInfos;
            var enemyIndex = swarmIndex + 1;
            if(enemyIndex >= swarmInfos.Count)
            {
                enemyIndex = 0;
            }
            var enemySwarm = swarmInfos[enemyIndex];

            // We find the collection of enemy drones...
            var enemyDrones = enemySwarm.DroneInfos;
            var numEnemyDrones = enemyDrones.Count;

            // We move each of our drones towards the corresponding enemy drone...
            var ourSwarm = swarmInfos[swarmIndex];
            var ourDrones = ourSwarm.DroneInfos;
            var numDrones = ourDrones.Count;

            --m_offsetCount;
            if (m_offsetCount <= 0)
            {
                var offsetAmount = 200000;

                for (var i = 0; i <numDrones; ++i)
                {
                    m_offsets[i] = new Point(m_rnd.Next(-1 * offsetAmount, offsetAmount), m_rnd.Next(-1 * offsetAmount, offsetAmount)); ;
                }

                m_offsetCount = 5;
            }



            for (var droneIndex=0; droneIndex<numDrones; ++droneIndex)
            {
                // We find the index of the enemy drone (wrapping round the collection
                // of enemies if we have more drones than they do)...
                var enemyDroneIndex = droneIndex;
                while(enemyDroneIndex >= numEnemyDrones)
                {
                    enemyDroneIndex -= numEnemyDrones;
                }

                // We move towards the enemy...
                var enemyDrone = enemyDrones[enemyDroneIndex];
                var movementRequest = new MovementRequest();
                movementRequest.DroneIndex = droneIndex;
                movementRequest.Target = enemyDrone.Position.Clone();

                // We add a bit of random jiggle to the target direction,
                // to make it look more interesting...
                var offset = m_offsets[droneIndex];
                movementRequest.Target.X += offset.X;
                movementRequest.Target.Y += offset.Y;

                movementRequests.Add(movementRequest);
            }

            return movementRequests;
        }

        #endregion

        #region Private data

        // Randomness...
        private Random m_rnd = new Random();

        private readonly Dictionary<int, Point> m_offsets = new Dictionary<int, Point>();
        private int m_offsetCount = 0;

        #endregion
    }
}
