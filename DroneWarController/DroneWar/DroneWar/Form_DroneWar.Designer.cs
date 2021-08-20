
namespace DroneWar
{
    partial class Form_DroneWar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctrlGroupBox_Logs = new System.Windows.Forms.GroupBox();
            this.ctrlLogs = new System.Windows.Forms.ListBox();
            this.ctrlGroupBox_Space = new System.Windows.Forms.GroupBox();
            this.ctrlGameSpace = new DroneWar.Control_GameSpace();
            this.ctrlStartGame = new System.Windows.Forms.Button();
            this.ctrlGraphicsRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTurnsPerSecond = new System.Windows.Forms.Label();
            this.ctrlTurnsPlayed = new System.Windows.Forms.Label();
            this.ctrlDronesInPlay = new System.Windows.Forms.Label();
            this.ctrlGroupBox_Logs.SuspendLayout();
            this.ctrlGroupBox_Space.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlGroupBox_Logs
            // 
            this.ctrlGroupBox_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGroupBox_Logs.Controls.Add(this.ctrlLogs);
            this.ctrlGroupBox_Logs.Location = new System.Drawing.Point(11, 577);
            this.ctrlGroupBox_Logs.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlGroupBox_Logs.Name = "ctrlGroupBox_Logs";
            this.ctrlGroupBox_Logs.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlGroupBox_Logs.Size = new System.Drawing.Size(1220, 131);
            this.ctrlGroupBox_Logs.TabIndex = 0;
            this.ctrlGroupBox_Logs.TabStop = false;
            this.ctrlGroupBox_Logs.Text = "Logs";
            // 
            // ctrlLogs
            // 
            this.ctrlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogs.FormattingEnabled = true;
            this.ctrlLogs.HorizontalScrollbar = true;
            this.ctrlLogs.ItemHeight = 15;
            this.ctrlLogs.Location = new System.Drawing.Point(1, 17);
            this.ctrlLogs.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlLogs.Name = "ctrlLogs";
            this.ctrlLogs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ctrlLogs.Size = new System.Drawing.Size(1218, 113);
            this.ctrlLogs.TabIndex = 0;
            // 
            // ctrlGroupBox_Space
            // 
            this.ctrlGroupBox_Space.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGroupBox_Space.Controls.Add(this.ctrlGameSpace);
            this.ctrlGroupBox_Space.Location = new System.Drawing.Point(10, 9);
            this.ctrlGroupBox_Space.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlGroupBox_Space.Name = "ctrlGroupBox_Space";
            this.ctrlGroupBox_Space.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlGroupBox_Space.Size = new System.Drawing.Size(998, 566);
            this.ctrlGroupBox_Space.TabIndex = 1;
            this.ctrlGroupBox_Space.TabStop = false;
            this.ctrlGroupBox_Space.Text = "Space";
            // 
            // ctrlGameSpace
            // 
            this.ctrlGameSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGameSpace.Game = null;
            this.ctrlGameSpace.Location = new System.Drawing.Point(1, 17);
            this.ctrlGameSpace.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.ctrlGameSpace.Name = "ctrlGameSpace";
            this.ctrlGameSpace.Size = new System.Drawing.Size(996, 548);
            this.ctrlGameSpace.TabIndex = 0;
            // 
            // ctrlStartGame
            // 
            this.ctrlStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlStartGame.Location = new System.Drawing.Point(1025, 26);
            this.ctrlStartGame.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlStartGame.Name = "ctrlStartGame";
            this.ctrlStartGame.Size = new System.Drawing.Size(205, 58);
            this.ctrlStartGame.TabIndex = 2;
            this.ctrlStartGame.Text = "Start game";
            this.ctrlStartGame.UseVisualStyleBackColor = true;
            this.ctrlStartGame.Click += new System.EventHandler(this.ctrlStartGame_Click);
            // 
            // ctrlGraphicsRefreshTimer
            // 
            this.ctrlGraphicsRefreshTimer.Enabled = true;
            this.ctrlGraphicsRefreshTimer.Interval = 1;
            this.ctrlGraphicsRefreshTimer.Tick += new System.EventHandler(this.ctrlGraphicsRefreshTimer_Tick);
            // 
            // lblTurnsPerSecond
            // 
            this.lblTurnsPerSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTurnsPerSecond.AutoSize = true;
            this.lblTurnsPerSecond.Location = new System.Drawing.Point(1025, 96);
            this.lblTurnsPerSecond.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTurnsPerSecond.Name = "lblTurnsPerSecond";
            this.lblTurnsPerSecond.Size = new System.Drawing.Size(61, 15);
            this.lblTurnsPerSecond.TabIndex = 3;
            this.lblTurnsPerSecond.Text = "Turns/sec:";
            // 
            // ctrlTurnsPlayed
            // 
            this.ctrlTurnsPlayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTurnsPlayed.AutoSize = true;
            this.ctrlTurnsPlayed.Location = new System.Drawing.Point(1107, 96);
            this.ctrlTurnsPlayed.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ctrlTurnsPlayed.Name = "ctrlTurnsPlayed";
            this.ctrlTurnsPlayed.Size = new System.Drawing.Size(13, 15);
            this.ctrlTurnsPlayed.TabIndex = 4;
            this.ctrlTurnsPlayed.Text = "0";
            // 
            // ctrlDronesInPlay
            // 
            this.ctrlDronesInPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlDronesInPlay.AutoSize = true;
            this.ctrlDronesInPlay.Location = new System.Drawing.Point(1025, 120);
            this.ctrlDronesInPlay.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ctrlDronesInPlay.Name = "ctrlDronesInPlay";
            this.ctrlDronesInPlay.Size = new System.Drawing.Size(90, 15);
            this.ctrlDronesInPlay.TabIndex = 6;
            this.ctrlDronesInPlay.Text = "(Drones in play)";
            // 
            // Form_DroneWar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 718);
            this.Controls.Add(this.ctrlDronesInPlay);
            this.Controls.Add(this.ctrlTurnsPlayed);
            this.Controls.Add(this.lblTurnsPerSecond);
            this.Controls.Add(this.ctrlStartGame);
            this.Controls.Add(this.ctrlGroupBox_Space);
            this.Controls.Add(this.ctrlGroupBox_Logs);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form_DroneWar";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_DroneWar_Load);
            this.ctrlGroupBox_Logs.ResumeLayout(false);
            this.ctrlGroupBox_Space.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ctrlGroupBox_Logs;
        private System.Windows.Forms.ListBox ctrlLogs;
        private System.Windows.Forms.GroupBox ctrlGroupBox_Space;
        private Control_GameSpace ctrlGameSpace;
        private System.Windows.Forms.Button ctrlStartGame;
        private System.Windows.Forms.Timer ctrlGraphicsRefreshTimer;
        private System.Windows.Forms.Label lblTurnsPerSecond;
        private System.Windows.Forms.Label ctrlTurnsPlayed;
        private System.Windows.Forms.Label ctrlDronesInPlay;
    }
}

