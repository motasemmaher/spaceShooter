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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            //---------
            var q1 = from g in Program.gamelist select g;
            var q2 = from p in Program.playerlist select p;
            label11.Text = q1.Count().ToString();
            label12.Text = q2.Count().ToString();
            if (q1.Count() != 0)
            {
                var q3 = from g in Program.gamelist
                         orderby g.score
                         select g;
                var q4 = from g in Program.gamelist
                         orderby g.duration
                         select g.duration;
                label13.Text = q3.Last().score.ToString();
                label14.Text = q3.First().score.ToString();
                label15.Text = q4.First().ToString();
                label16.Text = q4.Last().ToString();
                label17.Text = q4.Sum().ToString();
            }
        }
    }
}
