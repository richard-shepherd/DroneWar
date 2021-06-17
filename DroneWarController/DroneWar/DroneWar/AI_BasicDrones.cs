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
        public List<MovementRequest> moveDrones(GameState gameState, int ourSwarmIndex)
        {
            var movementRequests = new List<MovementRequest>();

            // We find the our swarm and the enemy swarm...
            var ourSwarm = gameState.SwarmInfos[ourSwarmIndex];
            var enemySwarm = getEnemySwarm(gameState, ourSwarmIndex);

            // We move each of our drones towards the corresponding enemy drone...
            var ourDrones = ourSwarm.DroneInfos;
            var numDrones = ourDrones.Count;

            // Each drone targets a position randomly offset from its target - to make
            // the movement look more interesting. These offsets change at random intervals...
            --m_offsetCount;
            if (m_offsetCount <= 0)
            {
                var offsetAmount = m_rnd.Next(0, 30000);
                for (var i = 0; i <numDrones; ++i)
                {
                    m_offsets[i] = new Point(m_rnd.Next(-1 * offsetAmount, offsetAmount), m_rnd.Next(-1 * offsetAmount, offsetAmount)); ;
                }
                m_offsetCount = m_rnd.Next(20, 200);
            }

            for (var droneIndex=0; droneIndex<numDrones; ++droneIndex)
            {
                // We move towards the enemy...
                var enemyDrone = getEnemyDrone(enemySwarm, droneIndex);
                var movementRequest = new MovementRequest();
                movementRequest.DroneIndex = droneIndex;
                movementRequest.Target = enemyDrone.DroneInfo.Position.Clone();

                // We add a bit of random jiggle to the target direction,
                // to make it look more interesting...
                var offset = m_offsets[droneIndex];
                movementRequest.Target.X += offset.X;
                movementRequest.Target.Y += offset.Y;
                movementRequests.Add(movementRequest);
            }

            return movementRequests;
        }

        /// <summary>
        /// Returns which drones we want to launch an attack, and which
        /// enemy drones they are targeting.
        /// </summary>
        public List<AttackRequest> attack(GameState gameState, int ourSwarmIndex)
        {
            var attackRequests = new List<AttackRequest>();

            // We find the our swarm and the enemy swarm...
            var ourSwarm = gameState.SwarmInfos[ourSwarmIndex];
            var enemySwarm = getEnemySwarm(gameState, ourSwarmIndex);

            // Each drone attempts to fire at its opponent every turn...
            var ourDrones = ourSwarm.DroneInfos;
            var numDrones = ourDrones.Count;
            for (var droneIndex = 0; droneIndex < numDrones; ++droneIndex)
            {
                // We find the enemy drone...
                var enemyDrone = getEnemyDrone(enemySwarm, droneIndex);

                // We attack the enemy...
                var attackRequest = new AttackRequest();
                attackRequest.AttackingDroneIndex = droneIndex;
                attackRequest.TargetDroneIndex = enemyDrone.DroneIndex;
                attackRequest.TargetSwarmIndex = enemySwarm.SwarmIndex;
                attackRequests.Add(attackRequest);
            }

            return attackRequests;
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Returns the swarm we are attacking.
        /// </summary>
        private EnemySwarm getEnemySwarm(GameState gameState, int ourSwarmIndex)
        {
            // We find the index of the enemy swarm. If there are more than two players,
            // we always target the 'next' swarm...
            var swarmInfos = gameState.SwarmInfos;
            var enemyIndex = ourSwarmIndex + 1;
            if (enemyIndex >= swarmInfos.Count) enemyIndex = 0;

            // We make sure the enemy has alive drones...
            while(swarmInfos[enemyIndex].NumberAliveDrones == 0)
            {
                enemyIndex++;
                if (enemyIndex >= swarmInfos.Count) enemyIndex = 0;
            }

            return new EnemySwarm
            {
                SwarmInfo = swarmInfos[enemyIndex],
                SwarmIndex = enemyIndex
            };
        }

        /// <summary>
        /// Gets the enemy drone-info targeted by one of our drones.
        /// </summary>
        private EnemyDrone getEnemyDrone(EnemySwarm enemySwarm, int ourDroneIndex)
        {
            var enemyDrones = enemySwarm.SwarmInfo.DroneInfos;
            var numEnemyDrones = enemyDrones.Count;

            // We find the index of the enemy drone. We target the next drone in the enemy
            // collection. (This makes movement more interesting when playing two of these
            // AIs against each other, as they play follow-the-leader.)
            var enemyDroneIndex = ourDroneIndex + 1;  

            // We make sure the enemy drone is a valid target...
            while (!isValidTarget(enemySwarm, enemyDroneIndex))
            {
                ++enemyDroneIndex;
                if(enemyDroneIndex >= numEnemyDrones)
                {
                    enemyDroneIndex = 0;
                }
            }

            return new EnemyDrone
            {
                DroneInfo = enemyDrones[enemyDroneIndex],
                DroneIndex = enemyDroneIndex
            };
        }

        /// <summary>
        /// Returns true if the enemy drone specified is a valid target.
        /// </summary>
        private bool isValidTarget(EnemySwarm enemySwarm, int enemyDroneIndex)
        {
            var enemyDrones = enemySwarm.SwarmInfo.DroneInfos;
            if (enemyDroneIndex >= enemyDrones.Count) return false;
            if (enemyDrones[enemyDroneIndex].IsDead) return false;
            return true;
        }

        #endregion

        #region Private types

        // Info about the enemy swarm...
        private class EnemySwarm
        {
            public SwarmInfo SwarmInfo { get; set; }
            public int SwarmIndex { get; set; }
        }

        // Info about an enemy drone...
        private class EnemyDrone
        {
            public DroneInfo DroneInfo { get; set; }
            public int DroneIndex { get; set; }
        }

        #endregion

        #region Private data

        // Randomness...
        private Random m_rnd = new Random();

        // Random offsets for movement (to make it look more interesting)...
        private readonly Dictionary<int, Point> m_offsets = new Dictionary<int, Point>();
        private int m_offsetCount = 0;

        #endregion
    }
}
