using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie_Arcade
{

    public partial class Form2 : Form
    {
        private string PlayerName;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PlayerName = txtPlayerName.Text;
            if (string.IsNullOrEmpty(PlayerName))
            {
                MessageBox.Show("Please put a name");
            }
            else
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnDisplayScores_Click(object sender, EventArgs e)
        {
            StreamReader inputfile = File.OpenText("scores.txt");

            while (!inputfile.EndOfStream)
            {
                string tmpstr = inputfile.ReadLine();
                string[] tmp = tmpstr.Split(',');
                string Name = tmp[0];
                string Score = tmp[1];
                string Time = tmp[2];
                LstScore.Items.Add("NAME: " + Name + " KILLS: " + Score + " TIME LIVED: " + Time + "seconds");
            }
            inputfile.Close();
        }

        public void Saving(int k, int s)
        {
            string Score = k.ToString();
            string Time = s.ToString();
            StreamWriter outputFile = File.AppendText("scores.txt");
            string str = $"{PlayerName},{Score},{Time}";
            outputFile.WriteLine(str);
            outputFile.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AWSD is used to move the black box, that is you. Use the mouse location to aim and click to fire. Now dont die!");
        }
    }
}
