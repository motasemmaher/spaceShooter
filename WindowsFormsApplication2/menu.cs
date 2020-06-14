using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApplication2
{
    public partial class menu : Form
    {
        WindowsMediaPlayer music = new WindowsMediaPlayer();

        public menu()
        {
            InitializeComponent();
            music.URL = "y2mate.com - baby_shark_remixclick_more_NEos1DFp5sw.mp3";
            music.controls.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.SendToBack();
        }

        private void newp_Click(object sender, EventArgs e)
        {
            button5.BringToFront();
            CreateProfile c = new CreateProfile(null);
            c.Show();
        }

        private void editp_Click(object sender, EventArgs e)
        {
            button5.BringToFront();
            currentProfile c = new currentProfile(false);
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentProfile f = new currentProfile(true);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Statistics s = new Statistics();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            History h = new History();
            h.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
