using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class playback : Form
    {
        List<Bitmap> images;
        public playback(List<Bitmap> imgs)
        {
            InitializeComponent();
            images = imgs;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i >= images.Count)
            {
                timer1.Enabled = false;
                this.Dispose();
                return;
            }
            pictureBox1.Image = images[i++];
        }
    }
}
