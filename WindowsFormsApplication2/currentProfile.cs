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
    public partial class currentProfile : Form
    {
        Player player;
        bool play = false;
        public currentProfile(bool p)
        {
            InitializeComponent();
            play = p;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            player = comboBox1.SelectedItem as Player;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (play)
            {
                Form1 f = new Form1(player);
                f.Show();
            }
            else
            {
                CreateProfile c = new CreateProfile(player);
                c.Show();
            }
            this.Dispose();
        }

        private void currentProfile_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Program.playerlist.ToArray());
        }
    }
}
