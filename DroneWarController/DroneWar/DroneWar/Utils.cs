using System;

namespace DroneWar
{
    /// <summary>
    /// Utility functions.
    /// </summary>
    public class Utils
    {
        #region Public methods

        /// <summary>
        /// Returns a random value between from and to.
        /// </summary>
        public static double rnd(double from, double to)
        {
            var diff = to - from;
            var offset = m_rnd.NextDouble() * diff;
            return from + offset;
        }

        #endregion

        #region Private data

        // Generates random values...
        private static Random m_rnd = new Random();

        #endregion
    }
}
