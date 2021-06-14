using System;
using System.Drawing;
using System.Windows.Forms;

namespace DroneWar
{
    /// <summary>
    /// Control showing the game space, drones, laser-fire etc.
    /// </summary>
    public partial class Control_GameSpace : UserControl
    {
        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public Control_GameSpace()
        {
            InitializeComponent();
        }

        #endregion

        #region Control events

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
            }
            catch(Exception ex)
            {
                Logger.log(ex);
            }
        }

        #endregion
    }
}
