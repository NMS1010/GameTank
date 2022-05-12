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
        private int health = 20;
        private int width = 20;
        private int height = 10;
        private Point loc;
        private Color obstacleColor = Color.Brown;
        private PictureBox ob;

        private bool isCanDestroy = true;

        public bool IsCanDestroy { get => isCanDestroy; set => isCanDestroy = value; }
        public Point Loc { get => loc; set => loc = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public PictureBox Ob { get => ob; set => ob = value; }
        public Color ObstacleColor { get => obstacleColor; set => obstacleColor = value; }
        public int Health { get => health; set => health = value; }

        public PartialObstacle(Point start, int width, int height, bool isCanDestroy)
        {
            Loc = start;
            Width = width;
            Height = height;
            IsCanDestroy = isCanDestroy;
        }
        public PartialObstacle(Point start, int width, int height, bool isCanDestroy, Color color, int health)
        {
            Loc = start;
            Width = width;
            Height = height;
            IsCanDestroy = isCanDestroy;
            Health = health;
            obstacleColor = color;
        }
        public PartialObstacle(Point start)
        {
            Loc = start; 
        }

        public void DrawPartialObstacle()
        {
            if (!IsCanDestroy)
            {
                Ob = new PictureBox() { Location = new Point(Loc.X, Loc.Y), Width = Width, Height = Height, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle};
            }
            else
            {
                Ob = new PictureBox() { Location = new Point(Loc.X, Loc.Y), Width = Width, Height = Height, BackColor = obstacleColor, BorderStyle = BorderStyle.FixedSingle };
            }
            
            Ob.SizeMode = PictureBoxSizeMode.StretchImage;
            GameStage.MainGamePnl.Controls.Add(Ob);
        }
    }
}
