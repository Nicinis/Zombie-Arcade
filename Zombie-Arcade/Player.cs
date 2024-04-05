using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Arcade
{
    internal class Player
    {
        private PictureBox PlayerPic;
        private int pxSpeed = 5;
        private int pySpeed = 5;
        private Form form;
        public int health = 100;
        

        public int PlayerX { get { return PlayerPic.Left; } }
        public int PlayerY { get { return PlayerPic.Top; } }

        public int PlayerWidth { get { return PlayerPic.Width; } }
        public int PlayerHeight { get { return PlayerPic.Height; } }

        public Player(int x, int y, Form mainform)
        {
            form = mainform;
            PlayerPic = new PictureBox();
            PlayerPic.BackColor = Color.Black;
            PlayerPic.Width = 23;
            PlayerPic.Height = 42;
            PlayerPic.Left = x;
            PlayerPic.Top = y;
            mainform.Controls.Add(PlayerPic);
        }

        public void MoveUp()
        {
            PlayerPic.Top -= pySpeed;
            if (PlayerPic.Top <= 0) PlayerPic.Top = 0;
        }
        public void MoveDown()
        {
            PlayerPic.Top += pySpeed;
            if (PlayerPic.Top + PlayerPic.Height >= form.ClientSize.Height) PlayerPic.Top = form.ClientSize.Height - PlayerPic.Height;
        }
        public void MoveLeft()
        {
            PlayerPic.Left -= pxSpeed;
            if (PlayerPic.Left <= 0) PlayerPic.Left = 0;
        }
        public void MoveRight()
        {
            PlayerPic.Left += pxSpeed;
            if (PlayerPic.Left + PlayerPic.Width >= form.ClientSize.Width) PlayerPic.Left = form.ClientSize.Width - PlayerPic.Width;
        }
               
    }






}
