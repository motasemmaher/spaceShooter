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
    public partial class History : Form
    {
        Game selectedgame;
        public History()
        {
            InitializeComponent();
            foreach(Game g in Program.gamelist)
            {
                string[] items = new string[5];
                items[0] = g.playerName;
                items[1] = g.date;
                items[2] = g.duration.ToString();
                items[3] = g.score.ToString();
                items[4] = g.coins.ToString();

                foreach (string s in items)
                {
                    Label l = new Label();
                    l.Text = s;
                    l.Size = new Size(95, 30);
                    l.Font = new Font("Ink Free", 13.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    l.BackColor = Color.Indigo;
                    l.ForeColor = Color.White;
                    l.Margin = new Padding(0, 4, 0, 4);
                    l.Tag = g;
                    l.Click += new EventHandler(label_Click);
                    l.BorderStyle = BorderStyle.Fixed3D;

                    flowLayoutPanel1.Controls.Add(l);
                }
            }
            
        }
        
        private void label_Click(object sender, EventArgs e)
        {
            Game g = (sender as Label).Tag as Game;
            selectedgame = g;
            flowLayoutPanel2.Controls.Clear();
            for (int i = 0; i < g.moves.Count; i++)
            {
                Label l1 = new Label();
                l1.Text = "" + (i + 1);
                l1.AutoSize = false;
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Size = new Size(flowLayoutPanel2.Width/2 - 20, 30);
                l1.Font = new Font("Ink Free", 13.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                l1.BackColor = Color.Indigo;
                l1.ForeColor = Color.White;
                l1.BorderStyle = BorderStyle.Fixed3D;
                flowLayoutPanel2.Controls.Add(l1);

                Label l2 = new Label();
                l2.Text = g.moves[i];
                l2.AutoSize = false;
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.Size = new Size(flowLayoutPanel2.Width/2 - 10, 30);
                l2.Font = new Font("Ink Free", 13.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                l2.BackColor = Color.Indigo;
                l2.ForeColor = Color.White;
                l2.BorderStyle = BorderStyle.Fixed3D;
                flowLayoutPanel2.Controls.Add(l2);
            }
            tableLayoutPanel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playback p = new playback(selectedgame.screens);
            p.Show();
        }
    }
}
