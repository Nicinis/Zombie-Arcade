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
        private int bulletSpd = 7;

        public int BulletX { get { return bulletPic.Left; } }

        public int BulletY { get { return bulletPic.Top; } }


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

        public void BulletMoveDown()
        {
            bulletPic.Top += bulletSpd;
        }

        public void BulletMoveUp()
        {
            bulletPic.Top -= bulletSpd;
        }

        public void BulletMoveLeft()
        {
            bulletPic.Left -= bulletSpd;
        }
        public void BulletMoveRight()
        {
            bulletPic.Left += bulletSpd;
        }

    }
}
