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
        private Form form;

        public int BulletX { get { return bulletPic.Left + 2; } }
        public int BulletY { get { return bulletPic.Top + 2; } }

        public Bullet(int x, int y, Form bulletfrom)
        {
            bulletPic = new PictureBox();
            bulletPic.Width = 4;
            bulletPic.Height = 4;
            bulletPic.BackColor = Color.Black;
            bulletPic.Left = x;
            bulletPic.Top = y;
            bulletfrom.Controls.Add(bulletPic);
            form = bulletfrom;
        }

        public void BulletMove() 
        {
            bulletPic.Left += Convert.ToInt32(bulletSpdX);
            bulletPic.Top += Convert.ToInt32(bulletSpdY);
            bulletRemove();
        }

        public void bulletRemove()
        {
            if(bulletPic.Left > form.ClientSize.Width) bulletPic.Visible = false;
            if(bulletPic.Left < 0) bulletPic.Visible = false;
            if(bulletPic.Top > form.ClientSize.Height) bulletPic.Visible = false;
            if(bulletPic.Top < 0) bulletPic.Visible = false;
        }

        public void BulletRemove2() 
        {
            bulletPic.Visible = false;
        }
        
    }
}
