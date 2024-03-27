using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Arcade
{
    internal class Bullet
    {
        private PictureBox bulletPic;
        public double bulletSpdX = 0;
        public double bulletSpdY = 0;

        public Bullet(int x, int y, Form bulletfrom)
        {
            bulletPic = new PictureBox();
            bulletPic.Width = 5;
            bulletPic.Height = 5;
            bulletPic.BackColor = Color.Black;
            bulletPic.Left = x;
            bulletPic.Top = y;
            bulletfrom.Controls.Add(bulletPic);
        }

        public void BulletMove() 
        {
            bulletPic.Left += Convert.ToInt32(bulletSpdX);
            bulletPic.Top += Convert.ToInt32(bulletSpdY);
        }
        
    }
}
