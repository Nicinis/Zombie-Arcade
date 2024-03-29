using System.Drawing.Text;
using System.Reflection.Metadata;
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
        List<Bullet> RemoveBullets = new List<Bullet>();
        private Bullet bullets;
        private Zombie zombie;
        public double stepX = 0.00;
        public double stepY = 0.00;
        public double speed = 30.00;

        public Form1()
        {

            InitializeComponent();
            Width = 1500;
            Height = 800;
            Player1 = new Player(this.ClientSize.Width / 2, this.ClientSize.Height / 2, this);
            bullets = new Bullet(-1, -1, this);
            zombie = new Zombie(400, 300, this);
            zombieList.Add(zombie);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void zombieTimer_Tick(object sender, EventArgs e)
        {

            if (zombieCounter < 5)
            {
                for (int z = 0; z < 5; z++)
                {
                    zombie = new Zombie(randX.Next(-50, -1) | randX.Next(1501, 1551), randY.Next(-50, -1) | randY.Next(801, 851), this);
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

        private void Form1_MouseMove(object sender, MouseEventArgs e) //place i dumped some code to constantly be updated as long as the cuursosr is moving in the form
        {
            MouseLocX = e.Location.X;
            MouseLocY = e.Location.Y;
            label1.Text = "X: " + MouseLocX.ToString() + " " + "Y: " + MouseLocY.ToString();

            zombieCounter = zombieList.Count;
            lblZombieCnt.Text = "Zombies: " + zombieCounter.ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bullets = new Bullet(Player1.PlayerX + 12, Player1.PlayerY + 21, this);
            bulletList.Add(bullets);
            CalcTrajectory(Player1.PlayerX, Player1.PlayerY, MouseLocX, MouseLocY);
            bullets.bulletSpdX = stepX;
            bullets.bulletSpdY = stepY;
        }

        private void timer1_Tick(object sender, EventArgs e) //code provided from Steve on moving a control using binary values to check if multiple keys are being pressed 
        {
            if ((player1 & KeyMove.left) == KeyMove.left) Player1.MoveLeft();
            if ((player1 & KeyMove.right) == KeyMove.right) Player1.MoveRight();
            if ((player1 & KeyMove.up) == KeyMove.up) Player1.MoveUp();
            if ((player1 & KeyMove.down) == KeyMove.down) Player1.MoveDown();

            foreach (Bullet bullet in bulletList)
            {
                bullet.BulletMove();//in this method the CalcTrag method formulates step values to shoot the bullet in the location of the mouse crusor

                foreach (Zombie zombie in zombieList)
                {
                    if (ZombieBullletCollisionTest(zombie, bullet)) //getting the bullets and zombies form each foreach loop to be passed as arguments for my collision test
                    {
                        zombie.health -= 1;
                        RemoveBullets.Add(bullet); //needed a bullet list to add the used bullets that get detected for collision
                        if (zombie.health == 0)
                        {
                            zombieList.Remove(zombie);
                            zombie.ZombieDeath();
                        }
                        break; //here i need to break the loop after a collision is detected otherwise it continues to loop
                    }
                }
            }

            foreach (Bullet Rbullet in RemoveBullets) //using the new bullet list titled RemoveBullets i can remove the bullets from the form and list without crashing my program
            {
                bulletList.Remove(Rbullet);
                Rbullet.BulletRemove2();
            }

            foreach (Zombie tmpzombie in zombieList)
            {
                if (Player1.PlayerX < tmpzombie.ZombieX) tmpzombie.ZombieMoveLeft();
                else if (Player1.PlayerX > tmpzombie.ZombieX) tmpzombie.ZombieMoveRight();
                if (Player1.PlayerY < tmpzombie.ZombieY) tmpzombie.ZombieMoveUp();
                else if (Player1.PlayerY > tmpzombie.ZombieY) tmpzombie.ZombieMoveDown();
            }

            foreach (Zombie zombie1 in zombieList)
            {
                foreach (Zombie zombie2 in zombieList)
                {
                    if (zombie1 != zombie2)
                    {
                        if (zombie1.CollisionWith(zombie2))
                        {
                            zombie1.ResovleCollision(zombie1, zombie2);
                            zombie2.ResovleCollision(zombie1, zombie2);
                        }
                    }
                }
            }


        }
        protected virtual void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double angle = Math.Atan2(deltaY, deltaX);

            stepX = speed * Math.Cos(angle);
            stepY = speed * Math.Sin(angle);
        }

        private Boolean ZombieBullletCollisionTest(Zombie zombie, Bullet bullet) //returns true if collision has occured, false otherwise
        {
            if (zombie.ZombieX + zombie.ZombieWidth < bullet.BulletX)
                return false;
            if (bullet.BulletX < zombie.ZombieX)
                return false;
            if (zombie.ZombieY + zombie.ZombieHeight < bullet.BulletY)
                return false;
            if (bullet.BulletY < zombie.ZombieY)
                return false;

            return true;
        }
    }
}