using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class PartialObstacle
    {
        private int width = 20;
        private int height = 10;
        private Point location;
        private static Bitmap obstacleImg = new Bitmap(Image.FromFile("../../love.jpg"));

        public Point Location { get => location; set => location = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public PartialObstacle(Point start, int width, int height)
        {
            Location = start;
            Width = width;
            Height = height;
        }
        public PartialObstacle(Point start)
        {
            Location = start;
        }

        public void DrawPartialObstacle(Graphics grp)
        {
            grp.DrawImage(obstacleImg, new Rectangle(Location.X, Location.Y, Width, Height));
        }
    }
}
