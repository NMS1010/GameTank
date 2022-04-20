using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    public static class Bound
    {
        public static Bitmap imgBound;
        public static Rectangle TopBound { get; set; }
        public static Rectangle LeftBound { get; set; }
        public static Rectangle BottomBound { get; set; }
        public static Rectangle RightBound { get; set; }
        static Bound()
        {
            Form1 f = new Form1();
            TopBound = new Rectangle(f.mainGamePnl.DisplayRectangle.Left, f.mainGamePnl.DisplayRectangle.Top, f.mainGamePnl.Width, 20);
            LeftBound = new Rectangle(f.mainGamePnl.DisplayRectangle.Left, f.mainGamePnl.DisplayRectangle.Top, 20, f.mainGamePnl.Height);
            BottomBound = new Rectangle(f.mainGamePnl.DisplayRectangle.Left, f.mainGamePnl.DisplayRectangle.Bottom - 20, f.mainGamePnl.Width, 20);
            RightBound = new Rectangle(f.mainGamePnl.DisplayRectangle.Right - 20, f.mainGamePnl.DisplayRectangle.Top, 20, f.mainGamePnl.Height);
            imgBound = new Bitmap(Image.FromFile("../../love.jpg"));
        }
        public static void DrawBound(Graphics grp)
        {
            grp.DrawImage(imgBound, TopBound);
            grp.DrawImage(imgBound, LeftBound);
            grp.DrawImage(imgBound, BottomBound);
            grp.DrawImage(imgBound, RightBound);
        }
    }
}
