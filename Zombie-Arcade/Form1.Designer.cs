﻿namespace Zombie_Arcade
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tmrMovement = new System.Windows.Forms.Timer(components);
            zombieTimer = new System.Windows.Forms.Timer(components);
            lblZombieCnt = new Label();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            lblKills = new Label();
            TimerTimer = new System.Windows.Forms.Timer(components);
            lblTime = new Label();
            SuspendLayout();
            // 
            // tmrMovement
            // 
            tmrMovement.Interval = 25;
            tmrMovement.Tick += timer1_Tick;
            // 
            // zombieTimer
            // 
            zombieTimer.Interval = 15000;
            zombieTimer.Tick += zombieTimer_Tick;
            // 
            // lblZombieCnt
            // 
            lblZombieCnt.AutoSize = true;
            lblZombieCnt.Location = new Point(1071, 15);
            lblZombieCnt.Margin = new Padding(4, 0, 4, 0);
            lblZombieCnt.Name = "lblZombieCnt";
            lblZombieCnt.Size = new Size(0, 25);
            lblZombieCnt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(501, 15);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(626, 12);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 33);
            progressBar1.TabIndex = 3;
            // 
            // lblKills
            // 
            lblKills.AutoSize = true;
            lblKills.Location = new Point(983, 15);
            lblKills.Margin = new Padding(4, 0, 4, 0);
            lblKills.Name = "lblKills";
            lblKills.Size = new Size(0, 25);
            lblKills.TabIndex = 4;
            // 
            // TimerTimer
            // 
            TimerTimer.Interval = 1000;
            TimerTimer.Tick += TimerTimer_Tick;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(1303, 15);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(0, 25);
            lblTime.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1729, 1062);
            Controls.Add(lblTime);
            Controls.Add(lblKills);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblZombieCnt);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Wasteland";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            MouseClick += Form1_MouseClick;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tmrMovement;
        private System.Windows.Forms.Timer zombieTimer;
        private Label lblZombieCnt;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Label lblKills;
        private System.Windows.Forms.Timer TimerTimer;
        private Label lblTime;
    }
}