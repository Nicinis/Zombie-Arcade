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
            txtPlayerName = new TextBox();
            label1 = new Label();
            btnInfo = new Button();
            SuspendLayout();
            // 
            // LstScore
            // 
            LstScore.FormattingEnabled = true;
            LstScore.ItemHeight = 25;
            LstScore.Location = new Point(17, 20);
            LstScore.Margin = new Padding(4, 5, 4, 5);
            LstScore.Name = "LstScore";
            LstScore.Size = new Size(473, 379);
            LstScore.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(17, 460);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(223, 53);
            btnStart.TabIndex = 1;
            btnStart.Text = "Play";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnDisplayScores
            // 
            btnDisplayScores.Location = new Point(249, 460);
            btnDisplayScores.Margin = new Padding(4, 5, 4, 5);
            btnDisplayScores.Name = "btnDisplayScores";
            btnDisplayScores.Size = new Size(243, 53);
            btnDisplayScores.TabIndex = 2;
            btnDisplayScores.Text = "Display Scores";
            btnDisplayScores.UseVisualStyleBackColor = true;
            btnDisplayScores.Click += btnDisplayScores_Click;
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(249, 412);
            txtPlayerName.Margin = new Padding(4, 5, 4, 5);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(241, 31);
            txtPlayerName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 417);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 4;
            label1.Text = "Player Name:";
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(17, 412);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(88, 34);
            btnInfo.TabIndex = 5;
            btnInfo.Text = "Info";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 538);
            Controls.Add(btnInfo);
            Controls.Add(label1);
            Controls.Add(txtPlayerName);
            Controls.Add(btnDisplayScores);
            Controls.Add(btnStart);
            Controls.Add(LstScore);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form2";
            Text = "Zombie-Arcade";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LstScore;
        private Button btnStart;
        private Button btnDisplayScores;
        private TextBox txtPlayerName;
        private Label label1;
        private Button btnInfo;
    }
}