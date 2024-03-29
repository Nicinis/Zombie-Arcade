using System;
using System.Collections.Generic;
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
        public int health = 3;

        public int ZombieX { get { return ZombiePic.Left; } }
        public int ZombieY { get { return ZombiePic.Top; } }

        public int ZombieWidth { get { return ZombiePic.Width; } }
        public int ZombieHeight { get { return ZombiePic.Height; } }

        public Zombie(int x, int y, Form zombieform)
        {
            ZombiePic = new PictureBox();
            ZombiePic.BackColor = Color.Red;
            ZombiePic.Width = 23;
            ZombiePic.Height = 42;
            ZombiePic.Left = x;
            ZombiePic.Top = y;
            zombieform.Controls.Add(ZombiePic);
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
        }

        public bool CollisionWith(Zombie otherZombie) 
        {
            return this.ZombiePic.Bounds.IntersectsWith(otherZombie.ZombiePic.Bounds);
        }

        public void ResovleCollision(Zombie zombie1, Zombie zombie2) 
        {
            zombie1.ZombiePic.Left -= 10;
            zombie2.ZombiePic.Left += 10;
            zombie1.ZombiePic.Top -= 5;
            zombie2.ZombiePic.Top += 5;
        }
    }
}
