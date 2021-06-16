using System;

namespace DroneWar
{
    /// <summary>
    /// REcords performance status for a game.
    /// </summary>
    public class PerformanceStats
    {
        #region Properties

        /// <summary>
        /// Gets the number of turns played in the game.
        /// </summary>
        public int TurnsPlayed { get; private set; } = 0;

        /// <summary>
        /// Gets the most recent turns-per-second.
        /// </summary>
        public double TurnsPerSecond { get; private set; } = 0.0;

        #endregion

        #region Public methods

        /// <summary>
        /// Called when a turn has been completed.
        /// </summary>
        public void onTurnCompleted()
        {
            // We update the number of turns played...
            TurnsPlayed++;

            // We calculate the turns played per second...
            var now = DateTime.UtcNow;
            var elapsedSeconds = (now - m_initialTime).TotalSeconds;
            if (elapsedSeconds >= 1.0)
            {
                var numTurns = TurnsPlayed - m_initialTurnsPlayed;
                TurnsPerSecond = numTurns / elapsedSeconds;

                m_initialTurnsPlayed = TurnsPlayed;
                m_initialTime = now;
            }
        }

        #endregion

        #region Private data

        // The time and number of turns played at the start of a one second interval.
        // (Used when calculating turns per second.)
        private int m_initialTurnsPlayed = 0;
        private DateTime m_initialTime = DateTime.UtcNow;

        #endregion
    }
}
