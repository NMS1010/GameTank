using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal class Item
    {
        public Point Loc { get; set; }
        public PictureBox avatarItem;
        public int Width { get; set; }
        public int Height { get; set; }
        public string PathFile { get; set; }

        public Item(Point loc, int width, int height, string pathFile)
        {
            Loc = loc;
            Width = width;
            Height = height;
            PathFile = pathFile;
            using (Image img = Image.FromFile(pathFile))
            {
                Bitmap bmp = new Bitmap(img);
                avatarItem = new PictureBox() { Location = Loc, Width = Width, Height = Height, Image = bmp, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Black };
            }
        }
    }
}
