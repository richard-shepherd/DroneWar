using System;

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
        public double X
        {
            get { return m_x; }
            set { setX(value); }
        }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public double Y
        {
            get { return m_y; }
            set { setY(value); }
        }

        #endregion

        #region Public types

        public class DistanceInfo
        {
            public double DiffX { get; set; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameSpacePoint()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameSpacePoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a clone of the game space point.
        /// </summary>
        public GameSpacePoint Clone()
        {
            var clone = new GameSpacePoint();
            clone.X = X;
            clone.Y = Y;
            return clone;
        }

        /// <summary>
        /// Returns a new GameSpacePoint which is the specified distance away from this point 
        /// in the direction of the target point specified.
        /// 
        /// If the distance would take us past the target point, then the target point is returned.
        /// </summary>
        public GameSpacePoint moveTowards(GameSpacePoint target, int distance)
        {
            // We find the distance to the other point...
            var diffX = target.X - X;
            var diffY = target.Y - Y;
            var diffXSquared = diffX * diffX;
            var diffYSquared = diffY * diffY;
            var distanceToOther = Math.Sqrt(diffXSquared + diffYSquared);

            // If the distance specified takes us past the point, we return it...
            if(distance > distanceToOther)
            {
                return target;
            }

            // We are moving the distance along the line...
            var newPoint = new GameSpacePoint();
            var ratio = distance / distanceToOther;
            newPoint.X = X + ratio * diffX;
            newPoint.Y = Y + ratio * diffY;

            return newPoint;
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Sets the X coordinate, constraining it to the game space.
        /// </summary>
        private void setX(double value)
        {
            m_x = value;
            if (m_x < 0) m_x = 0;
            if (m_x > Constants.SPACE_SIZE_X) m_x = Constants.SPACE_SIZE_X;
        }

        /// <summary>
        /// Sets the Y coordinate, constraining it to the game space.
        /// </summary>
        private void setY(double value)
        {
            m_y = value;
            if (m_y < 0) m_y = 0;
            if (m_y > Constants.SPACE_SIZE_Y) m_y = Constants.SPACE_SIZE_Y;
        }

        #endregion

        #region Private data

        // The x and y coordinates...
        private double m_x = 0;
        private double m_y = 0;

        #endregion
    }
}
