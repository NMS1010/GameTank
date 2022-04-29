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
    internal class Bullet
    {
        private int speed = 13;
        private int damage;
        private Point loc;
        private int width = 7;
        private int height = 7;
        private DIRECTION direction;
        private bool isOfPlayer;
        private bool isMoving = false;
        private Color bulletColor;
        Timer t;
        PictureBox explodePtrb;
        public Bullet(Point loc, DIRECTION direction, bool isOfPlayer, Color color, int bulletSpeed, int damage)
        {
            Loc = loc;
            Direction = direction;
            IsOfPlayer = isOfPlayer;
            bulletColor = color;
            Damage = damage;
            t = new Timer();
            t.Tick += T_Tick;
            t.Interval = bulletSpeed;
            explodePtrb = new PictureBox() {Width = 40, Height = 40, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Transparent };
            using (Image explodeImg = Image.FromFile("../../Image/explode.png"))
            {
                explodePtrb.Image = new Bitmap(explodeImg);
            }
        }
        public Color BulletColor { get => bulletColor; set => bulletColor = value; }
        public Point Loc { get => loc; set => loc = value; }
        public DIRECTION Direction { get => direction; set => direction = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool IsOfPlayer { get => isOfPlayer; set => isOfPlayer = value; }
        public int Damage { get => damage; set => damage = value; }

        public Point NextLocation()
        {
            Point nextLoc = new Point(0, 0);
            switch (direction)
            {
                case DIRECTION.UP:
                    nextLoc = new Point(loc.X, loc.Y - Speed);
                    break;
                case DIRECTION.RIGHT:
                    nextLoc = new Point(loc.X + Speed, loc.Y);
                    break;
                case DIRECTION.DOWN:
                    nextLoc = new Point(loc.X, loc.Y + Speed);
                    break;
                case DIRECTION.LEFT:
                    nextLoc = new Point(loc.X - Speed, loc.Y);
                    break;
            }
            return nextLoc;
        }
        public void Move()
        {
            IsMoving = true;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Point temp = NextLocation();
            if (GameStage.PlayerTank == null)
            {
                t.Stop();
                return;
            }  
            Utilities.HandleBulletCollision(this, Loc);
            if (!IsMoving)
                t.Stop();
            else
                Loc = temp;
        }

        
        public void DrawBullet(Graphics grp)
        {
            grp.FillEllipse(new SolidBrush(BulletColor), new Rectangle(Loc, new Size(Width, Height)));
        }

        public void ShowExplode(Point p)
        {
            explodePtrb.Location = p;
            GameStage.MainGamePnl.Controls.Add(explodePtrb);
            explodePtrb.SendToBack();
        }

        public void RemoveExplode()
        {
            if (GameStage.MainGamePnl.Controls.Contains(explodePtrb))
            {
                GameStage.MainGamePnl.Controls.Remove(explodePtrb);
            }
        }
    }
}
