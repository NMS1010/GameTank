using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal class PartialObstacle
    {
        private int width = 20;
        private int height = 10;
        private Point loc;
        private bool isCanDestroy = true;
        private static Bitmap obstacleImg = new Bitmap(Image.FromFile("../../Image/love.jpg"));

        public bool IsCanDestroy { get => isCanDestroy; set => isCanDestroy = value; }
        public Point Loc { get => loc; set => loc = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public PartialObstacle(Point start, int width, int height, bool isCanDestroy)
        {
            Loc = start;
            Width = width;
            Height = height;
            IsCanDestroy = isCanDestroy;
        }
        public PartialObstacle(Point start)
        {
            Loc = start;
        }

        public void DrawPartialObstacle()
        {
            PictureBox p;
            if (!IsCanDestroy)
            {
                p = new PictureBox() { Location = new Point(Loc.X, Loc.Y), Width = Width, Height = Height, BackColor = Color.White };
                //grp.FillRectangle(new SolidBrush(Color.White), new Rectangle(Loc.X, Loc.Y, Width, Height));
            }
            else
            {
                p = new PictureBox() { Location = new Point(Loc.X, Loc.Y), Width = Width, Height = Height, Image = obstacleImg };
                //grp.DrawImage(obstacleImg, new Rectangle(Loc.X, Loc.Y, Width, Height));
            }
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            GameStage.MainGamePnl.Controls.Add(p);
        }
    }
}
