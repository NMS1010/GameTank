using GameTank.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    public static class Bound
    {
        public static Bitmap ImgBound = new Bitmap(Properties.Resources.tree);
        public static PictureBox TopBound { get; set; }
        public static PictureBox LeftBound { get; set; }
        public static PictureBox BottomBound { get; set; }
        public static PictureBox RightBound { get; set; }
        static Bound()
        {
            TopBound = new PictureBox() { Location = new Point(GameStage.MainGamePnl.DisplayRectangle.Left, GameStage.MainGamePnl.DisplayRectangle.Top), Width = GameStage.MainGamePnl.Width, Height = 20, Image = ImgBound, SizeMode = PictureBoxSizeMode.StretchImage };
            LeftBound = new PictureBox() { Location = new Point(GameStage.MainGamePnl.DisplayRectangle.Left, GameStage.MainGamePnl.DisplayRectangle.Top), Width = 20, Height = GameStage.MainGamePnl.Height, Image = ImgBound, SizeMode = PictureBoxSizeMode.StretchImage };
            BottomBound = new PictureBox() { Location = new Point(GameStage.MainGamePnl.DisplayRectangle.Left, GameStage.MainGamePnl.DisplayRectangle.Bottom - 20), Width = GameStage.MainGamePnl.Width, Height = 20, Image = ImgBound, SizeMode = PictureBoxSizeMode.StretchImage };
            RightBound = new PictureBox() { Location = new Point(GameStage.MainGamePnl.DisplayRectangle.Right - 19, GameStage.MainGamePnl.DisplayRectangle.Top), Width = 20, Height = GameStage.MainGamePnl.Height, Image = ImgBound, SizeMode = PictureBoxSizeMode.StretchImage };
            
        }
        public static void DrawBound()
        {
            GameStage.MainGamePnl.Controls.Add(TopBound);
            GameStage.MainGamePnl.Controls.Add(LeftBound);
            GameStage.MainGamePnl.Controls.Add(BottomBound);
            GameStage.MainGamePnl.Controls.Add(RightBound);
        }

        private static bool IsOutRange(PictureBox ptrb, Point p)
        {
            if (p.X > ptrb.Location.X && p.X < ptrb.Location.X + ptrb.Width
                && p.Y > ptrb.Location.Y && p.Y < ptrb.Location.Y + ptrb.Height)
                return true;
            return false;
        }

        public static bool IsCollisionBound(Point nextLoc, int width, int height, DIRECTION direction)
        {
            Tuple<Point, Point> aheadPoints = Utilities.GetAheadPoints(nextLoc, width, height, direction);
            if (Bound.IsOutRange(Bound.TopBound, aheadPoints.Item1) || Bound.IsOutRange(Bound.BottomBound, aheadPoints.Item1)
                || Bound.IsOutRange(Bound.LeftBound, aheadPoints.Item1) || Bound.IsOutRange(Bound.RightBound, aheadPoints.Item1))
                return true;
            return false;
        }
    }
}
