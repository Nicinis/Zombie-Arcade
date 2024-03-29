namespace Zombie_Arcade
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
            tmrMovement = new System.Windows.Forms.Timer(components);
            zombieTimer = new System.Windows.Forms.Timer(components);
            lblZombieCnt = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // tmrMovement
            // 
            tmrMovement.Enabled = true;
            tmrMovement.Interval = 20;
            tmrMovement.Tick += timer1_Tick;
            // 
            // zombieTimer
            // 
            zombieTimer.Enabled = true;
            zombieTimer.Interval = 25;
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
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1729, 1183);
            Controls.Add(label1);
            Controls.Add(lblZombieCnt);
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
    }
}