using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace Zombie_Arcade
{

    public partial class Form1 : Form
    {
        private enum KeyMove { none = 0, up = 1, right = 2, down = 4, left = 8 }
        KeyMove player1 = KeyMove.none;
        private Player Player1;
        public int MouseLocX;
        public int MouseLocY;
        private int zombieCounter = 0;
        private Random randX = new Random();
        private Random randY = new Random();
        List<Zombie> zombieList = new List<Zombie>();
        List<Bullet> bulletList = new List<Bullet>();
        public double stepX = 0.00;
        public double stepY = 0.00;
        public double speed = 30.00;

        public Form1()
        {

            InitializeComponent();
            Width = 1500;
            Height = 800;
            Player1 = new Player(this.ClientSize.Width / 2, this.ClientSize.Height / 2, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void zombieTimer_Tick(object sender, EventArgs e)
        {

            zombieCounter = zombieList.Count;
            lblZombieCnt.Text = "Zombies: " + zombieCounter.ToString();
            if (zombieCounter < 10)
            {
                for (int z = 0; z < 10; z++)
                {
                    Zombie zombie = new Zombie(randX.Next(-50, -1) | randX.Next(1501, 1551), randY.Next(-50, -1) | randY.Next(801, 851), this);
                    zombieList.Add(zombie);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    player1 |= KeyMove.left;
                    break;
                case Keys.D:
                    player1 |= KeyMove.right;
                    break;
                case Keys.W:
                    player1 |= KeyMove.up;
                    break;
                case Keys.S:
                    player1 |= KeyMove.down;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.A:
                    player1 &= ~KeyMove.left;
                    break;
                case Keys.D:
                    player1 &= ~KeyMove.right;
                    break;
                case Keys.W:
                    player1 &= ~KeyMove.up;
                    break;
                case Keys.S:
                    player1 &= ~KeyMove.down;
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocX = e.Location.X;
            MouseLocY = e.Location.Y;
            label1.Text = "X: " + MouseLocX.ToString() + " " + "Y: " + MouseLocY.ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Bullet bullets = new Bullet(Player1.PlayerX + 12, Player1.PlayerY + 21, this);
            bulletList.Add(bullets);

            foreach (Bullet bullet in bulletList)
            {
                CalcTrajectory(Player1.PlayerX, Player1.PlayerY, MouseLocX, MouseLocY);
                bullet.bulletSpdX = stepX;
                bullet.bulletSpdY = stepY;
            }

        }

        private void timer1_Tick(object sender, EventArgs e) //code provided from Steve on moving a control using binary values to check if multiple keys are being pressed 
        {
            if ((player1 & KeyMove.left) == KeyMove.left) Player1.MoveLeft();
            if ((player1 & KeyMove.right) == KeyMove.right) Player1.MoveRight();
            if ((player1 & KeyMove.up) == KeyMove.up) Player1.MoveUp();
            if ((player1 & KeyMove.down) == KeyMove.down) Player1.MoveDown();

            foreach (Bullet bullet in bulletList) // need to fix the bullet system
            {
                bullet.BulletMove();
            }

            //foreach (Zombie tmpzombie in zombieList)
            //{
            //    if (Player1.PlayerX < tmpzombie.ZombieX) tmpzombie.ZombieMoveLeft();
            //    else if (Player1.PlayerX > tmpzombie.ZombieX) tmpzombie.ZombieMoveRight();
            //    if (Player1.PlayerY < tmpzombie.ZombieY) tmpzombie.ZombieMoveUp();
            //    else if (Player1.PlayerY > tmpzombie.ZombieY) tmpzombie.ZombieMoveDown();
            //}


        }
        protected virtual void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double angle = Math.Atan2(deltaY, deltaX);

            stepX = speed * Math.Cos(angle);
            stepY = speed * Math.Sin(angle);
        }
    }
}