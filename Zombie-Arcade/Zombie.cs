using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Arcade
{
    internal class Zombie
    {
        private PictureBox ZombiePic;
        private int zxSpeed = 3;
        private int zySpeed = 3;
        public int health = 0;
        private Form form;
        private Random rndHealth = new Random();
        private Random randX = new Random();
        private Random randY = new Random();

        public int ZombieX { get { return ZombiePic.Left; } }
        public int ZombieY { get { return ZombiePic.Top; } }

        public int ZombieWidth { get { return ZombiePic.Width; } }
        public int ZombieHeight { get { return ZombiePic.Height; } }

        public Zombie(int x, int y, Form zombieform)
        {
            ZombiePic = new PictureBox();
            ZombiePic.Width = 23;
            ZombiePic.Height = 42;
            ZombiePic.Left = x;
            ZombiePic.Top = y;
            zombieform.Controls.Add(ZombiePic);
            form = zombieform;
            health = rndHealth.Next(1, 6);
            ZombieHealth();
        }
        public void ZombieMoveUp()
        {
            ZombiePic.Top -= zySpeed;
        }
        public void ZombieMoveDown()
        {
            ZombiePic.Top += zySpeed;
        }
        public void ZombieMoveLeft()
        {
            ZombiePic.Left -= zxSpeed;
        }
        public void ZombieMoveRight()
        {
            ZombiePic.Left += zxSpeed;
        }

        public void ZombieDeath()
        {
            ZombiePic.Visible = false;
            form.Controls.Remove(ZombiePic);
            ZombiePic.Dispose();
        }
        public void ZombieHealth()
        {
            if (health == 5)
            {
                ZombiePic.BackColor = Color.Green;
            }
            else if (health == 4)
            {
                ZombiePic.BackColor = Color.Pink;
            }
            else if (health == 3)
            {
                ZombiePic.BackColor = Color.Purple;
            }
            else if (health == 2)
            {
                ZombiePic.BackColor = Color.Orange;
            }
            else if (health == 1)
            {
                ZombiePic.BackColor = Color.Red;
            }
        }

        public void ResovleCollision(Zombie zombie1, Zombie zombie2)//figuriing out the overlap of the picturboxs so i can then divide it and use it to push the pictureboxes away repsectively i added a +1 as a buffer to the pictureboxes
        {
            int overlap1X = zombie1.ZombiePic.Left - zombie2.ZombiePic.Right;
            int overlap2X = zombie1.ZombiePic.Right - zombie2.ZombiePic.Left;

            int overlap1Y = zombie1.ZombiePic.Top - zombie2.ZombiePic.Bottom;
            int overlap2Y = zombie1.ZombiePic.Bottom - zombie2.ZombiePic.Top;

            if (overlap1X > overlap2X)
            {
                int newoverlap = overlap1X / 2;
                zombie1.ZombiePic.Left -= newoverlap + 1;
                zombie2.ZombiePic.Left += newoverlap + 1;
            }
            else
            {
                int newoverlap = overlap2X / 2;
                zombie1.ZombiePic.Left -= newoverlap + 1;
                zombie2.ZombiePic.Left += newoverlap + 1;
            }

            if (overlap1Y > overlap2Y)
            {
                int newoverlap = overlap1Y / 2;
                zombie1.ZombiePic.Top -= newoverlap + 1;
                zombie2.ZombiePic.Top += newoverlap + 1;
            }
            else
            {
                int newoverlap = overlap2Y / 2;
                zombie1.ZombiePic.Top -= newoverlap + 1;
                zombie2.ZombiePic.Top += newoverlap + 1;
            }


        }
        public void MoveZombiesonDeath()
        {
            ZombiePic.Left = randX.Next(1, 1460);
            ZombiePic.Top = randY.Next(1, 720);
        }
    }
}
