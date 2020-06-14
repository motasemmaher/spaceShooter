using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class CreateProfile : Form
    {
        Player player;
        int playerBalance = 0;
        public CreateProfile(Player p)
        {
            InitializeComponent();
            player = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(player is null))
                Program.playerlist.Remove(player);
            player = new Player();
            player.Name = textBox1.Text;
            if (radioButton2.Checked)
                player.Gender = "Male";
            else
                player.Gender = "Female";
            int a;
            //MessageBox.Show((string)comboBox1.SelectedItem);
            int.TryParse((string)comboBox1.SelectedItem, out a);
            player.Age = a;
            if (radioButton3.Checked)
            {
                pictureBox1.BackgroundImage = Image.FromFile
                    (".\\space-ship-icon2.png");
                player.SpaceShooter = ".\\space-ship-icon2.png";
            }
            else if (radioButton6.Checked)
            {
                pictureBox2.BackgroundImage = Image.FromFile
                    (".\\space-shuttle-icon.png");
                player.SpaceShooter = ".\\space-shuttle-icon.png";
            }
            else if (radioButton4.Checked)
            {
                pictureBox3.BackgroundImage = Image.FromFile
                    (".\\space-shuttle-launch-icon.png");
                player.SpaceShooter = ".\\space-shuttle-launch-icon.png";
            }
            else
            {
                pictureBox4.BackgroundImage = Image.FromFile
                 (".\\space-rocket-icon.png");
                player.SpaceShooter = ".\\space-rocket-icon.png";
         
            }

            player.Balance = playerBalance;
            Program.playerlist.Add(player);
            this.Dispose();
        }
        private void CreateProfile_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (!(player is null))
            {
                playerBalance = player.Balance;
                textBox1.Text = player.Name;
                if (player.Gender == "Male")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                comboBox1.SelectedIndex = player.Age - 3;
                if (player.SpaceShooter == ".\\space-ship-icon2.png")
                {
                    pictureBox1.BackgroundImage = Image.FromFile
                        (".\\space-ship-icon2.png");
                    radioButton3.Checked = true;
                }
                else if (player.SpaceShooter == ".\\space-shuttle-icon.png")
                {
                    pictureBox2.BackgroundImage = Image.FromFile
                        (".\\space-shuttle-icon.png");
                    radioButton6.Checked = true;
                }
                else if (player.SpaceShooter == ".\\space-shuttle-launch-icon.png")
                {
                    pictureBox3.BackgroundImage = Image.FromFile
                        (".\\space-shuttle-launch-icon.png");
                    radioButton4.Checked = true;
                }
                else if (player.SpaceShooter == ".\\space-rocket-icon.png")
                {
                    pictureBox4.BackgroundImage = Image.FromFile
                     (".\\space-rocket-icon.png");
                    radioButton5.Checked = true;

                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                pictureBox5.Image = pictureBox1.Image;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                pictureBox5.Image = pictureBox2.Image;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                pictureBox5.Image = pictureBox3.Image;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                pictureBox5.Image = pictureBox4.Image;
        }
    }
}
