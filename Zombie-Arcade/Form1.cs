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
        private int Score = 0;
        private int zombieCounter = 0;
        private Random randX = new Random();
        private Random randY = new Random();
        List<Zombie> zombieList = new List<Zombie>();
        List<Zombie> RemoveZombies = new List<Zombie>();
        List<Bullet> bulletList = new List<Bullet>();
        List<Bullet> RemoveBullets = new List<Bullet>();
        private Bullet bullets;
        private Zombie zombie;
        public double stepX = 0.00;
        public double stepY = 0.00;
        public double speed = 20.00;
        private int TimeSec = 0;
        //Form2 form2 = new Form2();

        public int Kills { get { return Score; } }
        public int Time { get { return TimeSec; } }

        public Form1()
        {

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            Width = 1500;
            Height = 800;
            Player1 = new Player(this.ClientSize.Width / 2, this.ClientSize.Height / 2, this);
            bullets = new Bullet(-1, -1, this);
            for (int z = 0; z < 2; z++) //2 random zombies to test with
            {
                zombie = new Zombie(randX.Next(1, 800), randY.Next(1, 400), this);
                zombieList.Add(zombie);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2.ShowDialog();

            if (form2.Visible == true)
            {
                zombieTimer.Enabled = false;
                tmrMovement.Enabled = false;
                TimerTimer.Enabled = false;
            }
            else if (form2.Visible == false)
            {
                zombieTimer.Enabled = true;
                tmrMovement.Enabled = true;
                TimerTimer.Enabled = true;
            }
        }


        private void zombieTimer_Tick(object sender, EventArgs e)
        {
            int leftsideX = randX.Next(-50, -1);
            int rightsideX = randX.Next(1501, 1551);
            int sideY = randY.Next(0, 800);
            int topsideY = randY.Next(-50, -1);
            int bottomsideY = randY.Next(801, 851);
            int sideX = randX.Next(0, 1500);

            if (zombieCounter < 6)
            {
                for (int z = 0; z < 2; z++)
                {
                    zombie = new Zombie(leftsideX, sideY, this);
                    zombieList.Add(zombie);
                }

                for (int z = 0; z < 2; z++)
                {
                    zombie = new Zombie(rightsideX, sideY, this);
                    zombieList.Add(zombie);
                }

                for (int z = 0; z < 2; z++)
                {
                    zombie = new Zombie(sideX, topsideY, this);
                    zombieList.Add(zombie);
                }

                for (int z = 0; z < 2; z++)
                {
                    zombie = new Zombie(sideX, bottomsideY, this);
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

        private void Form1_MouseMove(object sender, MouseEventArgs e) //place i dumped some code to constantly be updated as long as the cursor is moving in the form
        {
            MouseLocX = e.Location.X;
            MouseLocY = e.Location.Y;
            label1.Text = "X: " + MouseLocX.ToString() + " " + "Y: " + MouseLocY.ToString();

            zombieCounter = zombieList.Count;
            lblZombieCnt.Text = "Zombies: " + zombieCounter.ToString();

            progressBar1.Value = Player1.health;
            label2.Text = "Health: " + Player1.health.ToString();

            Score = RemoveZombies.Count;
            lblKills.Text = "Kills: " + Score.ToString();
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
                        zombie.ZombieHealth();
                        RemoveBullets.Add(bullet); //needed a bullet list to add the used bullets that get detected for collision
                        if (zombie.health == 0)
                        {
                            RemoveZombies.Add(zombie); //needed a zombie list to add the dead zombies to
                        }
                    }
                }
            }

            foreach (Bullet Rbullet in RemoveBullets) //using the bullet list titled RemoveBullets i can remove the bullets from the form and list without crashing my program
            {
                bulletList.Remove(Rbullet);
                Rbullet.BulletRemove2();
            }

            foreach (Zombie Rzombie in RemoveZombies) //using the RemoveZombies list i can remove the zombies without breaking my other foreach loop
            {
                zombieList.Remove(Rzombie);
                Rzombie.ZombieDeath();
            }

            foreach (Zombie tmpzombie in zombieList) //here the zombies just follow the player based on players loaction
            {
                if (Player1.PlayerX < tmpzombie.ZombieX) tmpzombie.ZombieMoveLeft();
                else if (Player1.PlayerX > tmpzombie.ZombieX) tmpzombie.ZombieMoveRight();
                if (Player1.PlayerY < tmpzombie.ZombieY) tmpzombie.ZombieMoveUp();
                else if (Player1.PlayerY > tmpzombie.ZombieY) tmpzombie.ZombieMoveDown();
            }

            foreach (Zombie zombie1 in zombieList)
            {
                if (ZombiePlayerCollisionTest(zombie1, Player1))
                {
                    Player1.health -= 1;
                    if (Player1.health == 0)
                    {
                        Player1.PlayerDeath();
                        tmrMovement.Enabled = false;
                        zombieTimer.Enabled = false;
                        MessageBox.Show("The zombies ate your brains!");
                        form2.Saving();
                    }
                }
                foreach (Zombie zombie2 in zombieList)
                {
                    if (zombie1 != zombie2 && ZombieZombieCollisionTest(zombie1, zombie2))
                    {
                        zombie1.ResovleCollision(zombie1, zombie2);
                    }
                }
            }
            BulletHandleing();
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

        private Boolean ZombieZombieCollisionTest(Zombie zombie1, Zombie zombie2) //returns true if collision has occured, false otherwise
        {
            if (zombie1.ZombieX + zombie1.ZombieWidth < zombie2.ZombieX)
                return false;
            if (zombie2.ZombieX + zombie2.ZombieWidth < zombie1.ZombieX)
                return false;
            if (zombie1.ZombieY + zombie1.ZombieHeight < zombie2.ZombieY)
                return false;
            if (zombie2.ZombieY + zombie2.ZombieHeight < zombie1.ZombieY)
                return false;

            return true;
        }

        private Boolean ZombiePlayerCollisionTest(Zombie zombie1, Player player) //returns true if collision has occured, false otherwise
        {
            if (zombie1.ZombieX + zombie1.ZombieWidth < player.PlayerX)
                return false;
            if (player.PlayerX + player.PlayerWidth < zombie1.ZombieX)
                return false;
            if (zombie1.ZombieY + zombie1.ZombieHeight < player.PlayerY)
                return false;
            if (player.PlayerY + player.PlayerHeight < zombie1.ZombieY)
                return false;

            return true;
        }

        private void BulletHandleing()
        {
            if (bullets.BulletX > this.ClientSize.Width)
            {
                bulletList.Remove(bullets);
                bullets.BulletRemove2();

            }
            else if (bullets.BulletX < 0)
            {
                bulletList.Remove(bullets);
                bullets.BulletRemove2();
            }

            if (bullets.BulletY < 0)
            {
                bulletList.Remove(bullets);
                bullets.BulletRemove2();
            }
            else if (bullets.BulletY > this.ClientSize.Height)
            {
                bulletList.Remove(bullets);
                bullets.BulletRemove2();
            }
        }

        private void TimerTimer_Tick(object sender, EventArgs e)
        {
            TimeSec++;
        }
    }
}