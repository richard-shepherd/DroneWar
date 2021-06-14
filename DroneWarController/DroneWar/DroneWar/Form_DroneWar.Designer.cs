
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DroneWar));
            this.ctrlGroupBox_Logs = new System.Windows.Forms.GroupBox();
            this.ctrlLogs = new System.Windows.Forms.ListBox();
            this.ctrlGroupBox_Space = new System.Windows.Forms.GroupBox();
            this.ctrlGameSpace = new DroneWar.Control_GameSpace();
            this.ctrlStartGame = new System.Windows.Forms.Button();
            this.ctrlGroupBox_Logs.SuspendLayout();
            this.ctrlGroupBox_Space.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlGroupBox_Logs
            // 
            this.ctrlGroupBox_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGroupBox_Logs.Controls.Add(this.ctrlLogs);
            this.ctrlGroupBox_Logs.Location = new System.Drawing.Point(12, 1156);
            this.ctrlGroupBox_Logs.Name = "ctrlGroupBox_Logs";
            this.ctrlGroupBox_Logs.Size = new System.Drawing.Size(2316, 357);
            this.ctrlGroupBox_Logs.TabIndex = 0;
            this.ctrlGroupBox_Logs.TabStop = false;
            this.ctrlGroupBox_Logs.Text = "Logs";
            // 
            // ctrlLogs
            // 
            this.ctrlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogs.FormattingEnabled = true;
            this.ctrlLogs.HorizontalScrollbar = true;
            this.ctrlLogs.ItemHeight = 41;
            this.ctrlLogs.Location = new System.Drawing.Point(3, 43);
            this.ctrlLogs.Name = "ctrlLogs";
            this.ctrlLogs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ctrlLogs.Size = new System.Drawing.Size(2310, 311);
            this.ctrlLogs.TabIndex = 0;
            // 
            // ctrlGroupBox_Space
            // 
            this.ctrlGroupBox_Space.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGroupBox_Space.Controls.Add(this.ctrlGameSpace);
            this.ctrlGroupBox_Space.Location = new System.Drawing.Point(15, 12);
            this.ctrlGroupBox_Space.Name = "ctrlGroupBox_Space";
            this.ctrlGroupBox_Space.Size = new System.Drawing.Size(1694, 1143);
            this.ctrlGroupBox_Space.TabIndex = 1;
            this.ctrlGroupBox_Space.TabStop = false;
            this.ctrlGroupBox_Space.Text = "Space";
            // 
            // ctrlGameSpace
            // 
            this.ctrlGameSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGameSpace.Location = new System.Drawing.Point(3, 43);
            this.ctrlGameSpace.Name = "ctrlGameSpace";
            this.ctrlGameSpace.Size = new System.Drawing.Size(1688, 1097);
            this.ctrlGameSpace.TabIndex = 0;
            // 
            // ctrlStartGame
            // 
            this.ctrlStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlStartGame.Location = new System.Drawing.Point(1755, 55);
            this.ctrlStartGame.Name = "ctrlStartGame";
            this.ctrlStartGame.Size = new System.Drawing.Size(534, 159);
            this.ctrlStartGame.TabIndex = 2;
            this.ctrlStartGame.Text = "Start game";
            this.ctrlStartGame.UseVisualStyleBackColor = true;
            this.ctrlStartGame.Click += new System.EventHandler(this.ctrlStartGame_Click);
            // 
            // Form_DroneWar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2340, 1525);
            this.Controls.Add(this.ctrlStartGame);
            this.Controls.Add(this.ctrlGroupBox_Space);
            this.Controls.Add(this.ctrlGroupBox_Logs);
            this.Name = "Form_DroneWar";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_DroneWar_Load);
            this.ctrlGroupBox_Logs.ResumeLayout(false);
            this.ctrlGroupBox_Space.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ctrlGroupBox_Logs;
        private System.Windows.Forms.ListBox ctrlLogs;
        private System.Windows.Forms.GroupBox ctrlGroupBox_Space;
        private Control_GameSpace ctrlGameSpace;
        private System.Windows.Forms.Button ctrlStartGame;
    }
}

