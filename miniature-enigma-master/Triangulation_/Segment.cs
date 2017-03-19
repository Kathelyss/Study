using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Triangulation_
{
    public partial class Segment : Form
    {
        public Segment(Bitmap image1)
        {
            InitializeComponent();
            this.zoomedImage = image1;
            newSegPictureBox.Image = zoomedImage;
        }
        Bitmap zoomedImage;
    }
}
