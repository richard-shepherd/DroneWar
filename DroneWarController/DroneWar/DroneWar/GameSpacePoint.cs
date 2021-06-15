namespace DroneWar
{
    /// <summary>
    /// Represents a point in the game space.
    /// 
    /// The top-left corner of the game space is (0, 0)
    /// The bottom-right corner of the game space is (Constants.SPACE_SIZE_X, Constants.SPACE_SIZE_Y)
    /// </summary>
    public class GameSpacePoint
    {
        #region Properties

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public int X
        {
            get { return m_x; }
            set { setX(value); }
        }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public int Y
        {
            get { return m_y; }
            set { setY(value); }
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Sets the X coordinate, constraining it to the game space.
        /// </summary>
        private void setX(int value)
        {
            m_x = value;
            if (m_x < 0) m_x = 0;
            if (m_x > Constants.SPACE_SIZE_X) m_x = Constants.SPACE_SIZE_X;
        }

        /// <summary>
        /// Sets the Y coordinate, constraining it to the game space.
        /// </summary>
        private void setY(int value)
        {
            m_y = value;
            if (m_y < 0) m_y = 0;
            if (m_y > Constants.SPACE_SIZE_Y) m_y = Constants.SPACE_SIZE_Y;
        }

        #endregion

        #region Private data

        // The x and y coordinates...
        private int m_x = 0;
        private int m_y = 0;

        #endregion
    }
}
