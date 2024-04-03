namespace Zombie_Arcade
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LstScore = new ListBox();
            btnStart = new Button();
            btnDisplayScores = new Button();
            SuspendLayout();
            // 
            // LstScore
            // 
            LstScore.FormattingEnabled = true;
            LstScore.ItemHeight = 15;
            LstScore.Location = new Point(12, 12);
            LstScore.Name = "LstScore";
            LstScore.Size = new Size(332, 229);
            LstScore.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 247);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(156, 32);
            btnStart.TabIndex = 1;
            btnStart.Text = "Play";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnDisplayScores
            // 
            btnDisplayScores.Location = new Point(174, 247);
            btnDisplayScores.Name = "btnDisplayScores";
            btnDisplayScores.Size = new Size(170, 32);
            btnDisplayScores.TabIndex = 2;
            btnDisplayScores.Text = "Display Scores";
            btnDisplayScores.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 291);
            Controls.Add(btnDisplayScores);
            Controls.Add(btnStart);
            Controls.Add(LstScore);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            Text = "Zombie-Arcade";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox LstScore;
        private Button btnStart;
        private Button btnDisplayScores;
    }
}