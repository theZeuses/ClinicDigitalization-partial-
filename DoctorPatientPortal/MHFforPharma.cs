using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class MHFforPharma : Form
    {
        Button b1,b2;
        Image img;
        public MHFforPharma(Image img,Button b1,Button b2)
        {
            InitializeComponent();
            this.img = img;
            this.b1 = b1;
            this.b2 = b2;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.pictureBox1.Image = img;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MHFforPharma_FormClosed(object sender, FormClosedEventArgs e)
        {
            b1.Enabled = true;
            b2.Enabled = true;
        }
    }
}
