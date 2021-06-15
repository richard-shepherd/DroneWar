using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DroneWar
{
    /// <summary>
    /// Form hosting the game-space and controlling DroneWar games 
    /// and tournaments.
    /// </summary>
    public partial class Form_DroneWar : Form
    {
        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form_DroneWar()
        {
            InitializeComponent();
        }

        #endregion

        #region Form events

        /// <summary>
        /// Called when the form is loaded.
        /// </summary>
        private void Form_DroneWar_Load(object sender, EventArgs e)
        {
            try
            {
                // We hook up the logger...
                Logger.onMessageLogged += onMessageLogged;
            }
            catch(Exception ex)
            {
                Logger.log(ex);
            }
        }

        /// <summary>
        /// Called when the "Start game" button is pressed.
        /// </summary>
        private void ctrlStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                // We start a new game, and add AIs...
                var swarmAIs = new List<ISwarmAI>();
                swarmAIs.Add(new AI_BasicDrones());
                swarmAIs.Add(new AI_BasicDrones());
                m_game = new Game(swarmAIs, 100);

                // We set up the game-space to show the swarms, and show the 
                // intial game state...
                ctrlGameSpace.SwarmInfos = m_game.GameState.SwarmInfos;
                ctrlGameSpace.show();
            }
            catch (Exception ex)
            {
                Logger.log(ex);
            }
        }


        /// <summary>
        /// Called when the graphics-refersh timer ticks.
        /// </summary>
        private void ctrlGraphicsRefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // If there is no active game, there is nothing to do...
                if(m_game == null)
                {
                    return;
                }

                // For the moment, this is running the game loop...
                m_game.playOneTurn();
                ctrlGameSpace.show();
            }
            catch(Exception ex)
            {
                Logger.log(ex);
            }
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Called when a message is logged.
        /// </summary>
        private void onMessageLogged(object sender, Logger.Args e)
        {
            try
            {
                ctrlLogs.Items.Insert(0, e.Message);
            }
            catch(Exception)
            {
                // If we get an exception here, we ignore it, as this is the logger(!)
            }
        }

        #endregion

        #region Private data

        // The current game...
        private Game m_game = null;

        #endregion
    }
}
