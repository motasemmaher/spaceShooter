using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer soundplayer = new System.Media.SoundPlayer("coin.wav");
        //-------------------------------------
        private Player player;
        private List<PictureBox> bullets = new List<PictureBox>();
        private List<PictureBox> listghost = new List<PictureBox>();
        private List<PictureBox> listhuman = new List<PictureBox>();
        private List<PictureBox> bulletshuman = new List<PictureBox>();
        private List<Bitmap> screens = new List<Bitmap>();
        private List<string> actions = new List<string>();
        //-------------------------------------

        bool acceptinput = true;
        int level = 1;
        int time = 0;
        Random rand = new Random();
        //private int alienspeed = 10;
        private int score = 0;
        private int coins;
        int totalkills = 0;
        PictureBox chosenAlien = new PictureBox { Tag = "10", BackgroundImage = Properties.Resources.alien_2_icon };

        public Form1(Player p)
        {
            InitializeComponent();
            
            player = p;
            
        }


        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProfile f = new CreateProfile(null);
            f.Show();
        }

        private void currentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentProfile c = new currentProfile(false);
            c.Show();
        }

        string dir = "none";
        int rep = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (acceptinput == false)
            {
                return;
            }

            int w = spaceshooter.Location.X; //spaceshooter.x

            if (e.KeyCode == Keys.Right)
            {
                if (w >= Width - 240 - spaceshooter.Width)
                {
                    return;
                }
                spaceshooter.Location = new Point(spaceshooter.Location.X + 20, spaceshooter.Location.Y);
                if (dir != "Right")
                {
                    if (dir != "none")
                    {
                        actions.Add(dir + " " + rep);
                        rep = 0;
                    }
                    dir = "Right";
                    rep++;
                }
                else
                {
                    rep++;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (w <= 20)
                {
                    return;
                }
                spaceshooter.Location = new Point(spaceshooter.Location.X - 20, spaceshooter.Location.Y);
                if (dir != "Left")
                {
                    if (dir != "none")
                    {
                        actions.Add(dir + " " + rep);
                        rep = 0;
                    }
                    dir = "Left";
                    rep++;
                }
                else
                {
                    rep++;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = chosenAlien.BackgroundImage;
                bullet.Size = new Size(35, 35);
                bullet.Location = new Point(spaceshooter.Location.X + 20, 465);
                bullet.SizeMode = PictureBoxSizeMode.Zoom;
                bullet.Tag = chosenAlien.Tag;

                Form.ActiveForm.Controls.Add(bullet);
                bullets.Add(bullet);
                score -= 10;
                scorelabel.Text = score.ToString();
                if (dir != "Shoot")
                {
                    if (dir != "none")
                    {
                        actions.Add(dir + " " + rep);
                        rep = 0;
                    }
                    dir = "Shoot";
                    rep++;
                }
            }
        }
        int enemycount = 10;
        private void alientimer_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox bullet in bullets)
            {
                bullet.Location = new Point(bullet.Location.X, bullet.Location.Y - int.Parse((string)bullet.Tag));
                if (level == 1)
                {
                    foreach (PictureBox enemy in listghost)
                    {
                        if (enemy.Visible)
                        {
                            if (doesHit(bullet, enemy))
                            {
                                soundplayer.Play();
                                score += 50;
                                scorelabel.Text = score.ToString();
                                enemycount--;
                                totalkills++;
                                enemy.Visible = false;
                                coins += 25;
                                balancegame.Text = coins.ToString();

                                if (enemycount == 0)
                                {
                                    acceptinput = false;
                                    actions.Add(dir + " " + rep);
                                    dir = "none";
                                    rep = 0;
                                    timer.Enabled = false;
                                    winmessage.Text = "Level up: 2";
                                    panel77.Visible = true;
                                }
                            }
                        }
                    }
                }
                else if (level == 2)
                {
                    foreach (PictureBox enemy in listhuman)
                    {
                        if (enemy.Visible)
                        {
                            if (doesHit(bullet, enemy))
                            {
                                soundplayer.Play();
                                score += 50;
                                scorelabel.Text = score.ToString();
                                enemycount--;
                                totalkills++;
                                enemy.Visible = false;
                                coins += 25;
                                balancegame.Text = coins.ToString();

                                if (enemycount == 0)
                                {
                                    acceptinput = false;
                                    timer.Enabled = false;
                                    winmessage.Text = "Level up: 3";
                                    panel77.Visible = true;
                                }
                            }
                        }
                    }
                }
                else if (level == 3)
                {
                    foreach (PictureBox enemy in listhuman)
                    {
                        if (enemy.Visible)
                        {
                            if (doesHit(bullet, enemy))
                            {
                                soundplayer.Play();
                                score += 50;
                                scorelabel.Text = score.ToString();
                                enemycount--;
                                totalkills++;
                                enemy.Visible = false;
                                coins += 25;
                                balancegame.Text = coins.ToString();

                                if (enemycount == 0)
                                {
                                    acceptinput = false;
                                    timer.Enabled = false;
                                    winmessage.Text = "YOU WIN!";
                                    panel77.Visible = true;
                                    foreach (PictureBox b in bulletshuman)
                                        b.Dispose();
                                    bulletshuman.Clear();
                                }
                            }
                        }
                    }
                }
            }
            if (totalkills == 3)
            {
                alien2.Visible = true;
                label6.Visible = true;
            }
            else if (totalkills == 6)
            {
                alien3.Visible = true;
                label7.Visible = true;
            }
            else if (totalkills == 9)
            {
                alien4.Visible = true;
                label8.Visible = true;
            }
            else if (totalkills == 12)
            {
                alien5.Visible = true;
                label9.Visible = true;
            }
            else if (totalkills == 15)
            {
                alien6.Visible = true;
                label10.Visible = true;
            }
        }


        bool doesHit(PictureBox bullet, Control target)
        {
            int bX = bullet.Location.X;
            int bY = bullet.Location.Y;
            int eX = target.Location.X;
            int eY = target.Location.Y;
            if (bX >= eX && bX <= eX + target.Width)
            {
                if (bY >= eY && bY <= eY + target.Height)
                {
                    return true;
                }
            }
            return false;
        }
        void levelUp()
        {
            level++;
            spaceshooter.Location = new Point(362, 492);
            foreach (PictureBox b in bullets)
                b.Dispose();
            bullets.Clear();
            
            levelgame.Text = level.ToString();
            if (level == 2)
            {
                enemycount = 9;
                foreach (PictureBox human in listhuman)
                {
                    human.Visible = true;
                }
                humanstimer.Enabled = true;
            }
            if (level == 3)
            {
                enemycount = 9;
                foreach (PictureBox human in listhuman)
                {
                    human.Visible = true;
                }
                movehumanbullets.Enabled = true;
            }
        }
        private void timerleft_Tick(object sender, EventArgs e)
        {
            time++;
            label4.Text = time + "s";
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics s = new Statistics();
            s.Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History h = new History();
            h.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToShortDateString();
            name.Text = player.Name;
            scorelabel.Text = "Score: " + score.ToString();
            coins = player.Balance;
            balancegame.Text = coins.ToString();
            spaceshooter.BackgroundImage = Image.FromFile(player.SpaceShooter);

            listghost.Add(ghost1);
            listghost.Add(ghost2);
            listghost.Add(ghost3);
            listghost.Add(ghost4);
            listghost.Add(ghost5);
            listghost.Add(ghost6);
            listghost.Add(ghost7);
            listghost.Add(ghost8);
            listghost.Add(ghost9);
            listghost.Add(ghost10);

            listhuman.Add(pictureBox1);
            listhuman.Add(pictureBox2);
            listhuman.Add(pictureBox3);
            listhuman.Add(pictureBox4);
            listhuman.Add(pictureBox5);
            listhuman.Add(pictureBox6);
            listhuman.Add(pictureBox7);
            listhuman.Add(pictureBox8);
            listhuman.Add(pictureBox9);
        }

        int sign = 1;
        int moves = 0;
        int shoottimer = 5;
        private void humanstimer_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox human in listhuman)
            {
                human.Location = new Point(human.Location.X + 10 * sign, human.Location.Y);
            }
            moves++;
            if (moves == 10)
            {
                moves = 0;
                sign *= -1;
            }

            if (level == 3)
            {
                if (shoottimer >= 5)
                {
                    int shooter = rand.Next(0, 9);
                    if (listhuman[shooter].Visible)
                    {
                        shoottimer = 0;
                        PictureBox bullet = new PictureBox();
                        bullet.Image = Properties.Resources.beachball;
                        bullet.Size = new Size(40, 40);
                        bullet.Location = new Point(listhuman[shooter].Location.X + 11, 117);
                        bullet.SizeMode = PictureBoxSizeMode.Zoom;

                        Form.ActiveForm.Controls.Add(bullet);
                        bulletshuman.Add(bullet);
                    }
                }
                shoottimer++;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (enemycount > 0)
            {
                Game g = new Game();
                g.playerName = player.Name;
                g.date = label11.Text;
                g.coins = coins;
                g.score = score;
                g.duration = time;
                g.moves = actions;
                g.screens = screens;
                Program.gamelist.Add(g);
                this.Dispose();
                return;
            }

            if (level == 1 || level == 2)
            {
                levelUp();
                timer.Enabled = true;
                acceptinput = true;
            }
            else if (level == 3)
            {
                player.Balance = coins;

                Game g = new Game();
                g.playerName = player.Name;
                g.date = label11.Text;
                g.coins = coins;
                g.score = score;
                g.duration = time;
                g.moves = actions;
                g.screens = screens;
                Program.gamelist.Add(g);
                this.Dispose();
            }

            panel77.Visible = false;
        }

        private void alien2_Click(object sender, EventArgs e)
        {
            chosenAlien = alien2;
            coins -= 50;
            balancegame.Text = coins.ToString();

        }

        private void alien3_Click(object sender, EventArgs e)
        {
            chosenAlien = alien3;
            coins -= 100;
            balancegame.Text = coins.ToString();
        }

        private void alien4_Click(object sender, EventArgs e)
        {
            chosenAlien = alien4;
            coins -= 200;
            balancegame.Text = coins.ToString();
        }

        private void alien5_Click(object sender, EventArgs e)
        {
            chosenAlien = alien5;
            coins -= 300;
            balancegame.Text = coins.ToString();
        }

        private void alien6_Click(object sender, EventArgs e)
        {
            chosenAlien = alien6;
            coins -= 500;
            balancegame.Text = coins.ToString();
        }

        private void movehumanbullets_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox bullet in bulletshuman)
            {
                bullet.Location = new Point(bullet.Location.X, bullet.Location.Y + 20);

                if (bullet.Tag != null)
                    continue;

                if (doesHit(bullet, spaceshooter))
                {
                    score -= 100;
                    scorelabel.Text = score.ToString();
                    bullet.Tag = "hit";
                    if (life3.Visible)
                    {
                        life3.Visible = false;
                    }
                    else if (life2.Visible)
                    {
                        life2.Visible = false;
                    }
                    else
                    {
                        life1.Visible = false;
                        winmessage.Text = "You Lost.";
                        panel77.Visible = true;
                        acceptinput = false;
                        foreach (PictureBox b in bulletshuman)
                            b.Dispose();
                        bulletshuman.Clear();
                        break;
                    }
                }
            }
        }

        Graphics g;
        private void takescreenshots_Tick(object sender, EventArgs e)
        {
            Point loc = DesktopLocation;
            loc.Y += 30;
            Bitmap img = new Bitmap(Width, Height);
            g = Graphics.FromImage(img);
            g.CopyFromScreen(loc, new Point(0, 0), new Size(Width, Height));
            screens.Add(img);
        }
    }
}
