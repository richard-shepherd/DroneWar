using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DroneWar
{
    /// <summary>
    /// Control showing the game space, drones, laser-fire etc.
    /// </summary>
    public partial class Control_GameSpace : UserControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the swarm-infos we show.
        /// </summary>
        public List<SwarmInfo> SwarmInfos { get; set; } = new List<SwarmInfo>();

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public Control_GameSpace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the current state of the swarm-infos.
        /// </summary>
        public void show()
        {
            // We invalidate the control, forcing it to be repainted...
            Invalidate();
        }

        #endregion

        #region Control events

        /// <summary>
        /// Called when the control is resized.
        /// </summary>
        private void Control_GameSpace_Resize(object sender, EventArgs e)
        {
            try
            {
                Invalidate();
            }
            catch (Exception ex)
            {
                Logger.log(ex);
            }
        }

        /// <summary>
        /// Called when the control is repainted.
        /// </summary>
        private void Control_GameSpace_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // We clear the space to black...
                var graphics = e.Graphics;
                graphics.Clear(Color.Black);

                // We show each swarm...
                foreach(var swarmInfo in SwarmInfos)
                {
                    showSwarm(swarmInfo, graphics);
                }
            }
            catch(Exception ex)
            {
                Logger.log(ex);
            }
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Shows one swarm.
        /// </summary>
        private void showSwarm(SwarmInfo swarmInfo, Graphics graphics)
        {
            var brush = new SolidBrush(swarmInfo.Color);
            foreach(var droneInfo in swarmInfo.DroneInfos)
            {
                if (droneInfo.IsDead) continue;

                var screenPosition = toScreenPoint(droneInfo.Position);
                var droneStrength = 100.0 + droneInfo.Shields;
                var size = (int)(droneStrength / 20.0);
                var offset = size / 2;
                graphics.FillEllipse(brush, screenPosition.X-offset, screenPosition.Y-offset, size, size);
            }
        }

        /// <summary>
        /// Converts a point in game space to a point on the control.
        /// </summary>
        private Point toScreenPoint(GameSpacePoint gameSpacePoint)
        {
            var x = (gameSpacePoint.X / Constants.SPACE_SIZE_X) * Width;
            var y = (gameSpacePoint.Y  / Constants.SPACE_SIZE_Y) * Height;
            return new Point((int)x, (int)y);
        }

        #endregion
    }
}
