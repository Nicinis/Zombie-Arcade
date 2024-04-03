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
        Form1 form1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Close();
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
                LstScore.Items.Add(tmp);
            }
            inputfile.Close();
        }

        public void Saving()
        {
            StreamWriter outputFile = File.AppendText("scores.txt");
            string str = $"{txtPlayerName.Text},{form1.Kills},{form1.Time}";
            outputFile.WriteLine(str);
            outputFile.Close();
        }
    }
}
