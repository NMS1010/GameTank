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
        private Point loc;
        private int width;
        private int height;
        private PictureBox itemPtrb;
        private Bitmap itemAvatar;


        public Item(Point loc, int width, int height)
        {
            Loc = loc;
            Width = width;
            Height = height;
        }

        public Point Loc { get => loc; set => loc = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Bitmap ItemAvatar { get => itemAvatar; set => itemAvatar = value; }
    }
}
