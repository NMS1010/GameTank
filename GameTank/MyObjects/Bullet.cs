using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal class Bullet
    {
        private int speed;
        private Color bulletColor = Color.Yellow;
        private Point loc;
        private int width;
        private int height;
        private int direction;
        private bool isMoving;
        public Bullet(Point loc, int direction)
        {
            Loc = loc;
            Direction = direction;
            Speed = 5;
            width = 5;
            height = 5;
            IsMoving = false;
        }

        public Color BulletColor { get => bulletColor; set => bulletColor = value; }
        public Point Loc { get => loc; set => loc = value; }
        public int Direction { get => direction; set => direction = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public int Speed { get => speed; set => speed = value; }
        public void SetLocationBullet()
        {
            Point nextLoc = new Point(0, 0);
            switch (direction)
            {
                case 0:
                    nextLoc = new Point(loc.X, loc.Y - Speed);
                    break;
                case 90:
                    nextLoc = new Point(loc.X + Speed, loc.Y);
                    break;
                case 180:
                    nextLoc = new Point(loc.X, loc.Y + Speed);
                    break;
                case 270:
                    nextLoc = new Point(loc.X - Speed, loc.Y);
                    break;
            }
            Loc = nextLoc;
        }
        public void Move()
        {
            Timer t = new Timer();
            t.Tick += T_Tick;
            t.Start();
            IsMoving = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            SetLocationBullet();
        }

        public void DrawBullet(Graphics grp)
        {
            grp.FillEllipse(new SolidBrush(BulletColor), new Rectangle(Loc, new Size(Width, Height)));
        }
    }
}
