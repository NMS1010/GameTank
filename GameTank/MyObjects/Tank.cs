using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTank.Constants;

namespace GameTank.MyObjects
{
    internal class Tank
    {
        private Point loc;
        private Point nextLoc;
        private int width = 40;
        private int height = 40;
        private int speed = 10;
        private int health = 100;
        private Bitmap tankAvatar;
        private DIRECTION direction = 0;
        private List<Bullet> bullets = new List<Bullet>();
        private bool isOfPlayer;
        private Color bulletColor = Color.Yellow;

        internal List<Bullet> Bullets { get => bullets; set => bullets = value; }
        public Point Loc { get => loc; set => loc = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public bool IsOfPlayer { get => isOfPlayer; set => isOfPlayer = value; }
        public Point NextLoc { get => nextLoc; set => nextLoc = value; }
        public DIRECTION Direction { get => direction; set => direction = value; }
        public int Health { get => health; set => health = value; }

        public Tank(Point loc, bool isOfPlayer)
        {
            IsOfPlayer = isOfPlayer;
            Loc = loc;
            using(Image imgTank = Image.FromFile("../../Image/playertank.bmp")){
                tankAvatar = new Bitmap(imgTank); 
            }
        }
        public Tank(Point loc, bool isOfPlayer, Color color)
        {
            IsOfPlayer = isOfPlayer;
            Loc = loc;
            using (Image imgTank = Image.FromFile("../../Image/playertank.bmp"))
            {
                tankAvatar = new Bitmap(imgTank);
            }
            bulletColor = color;
        }
        private void RotateTank()
        {
            using (Image imgTank = Image.FromFile("../../Image/playertank.bmp"))
            {
                using (Bitmap temp = new Bitmap(imgTank))
                {
                    switch (Direction)
                    {
                        case DIRECTION.UP:
                            break;
                        case DIRECTION.RIGHT:
                            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case DIRECTION.DOWN:
                            temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case DIRECTION.LEFT:
                            temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    tankAvatar.Dispose();
                    tankAvatar = new Bitmap(temp);
                }
            }
        }
        
        public void Move(ACTION action)
        {
            if (action == ACTION.MOVEUP)
            {
                NextLoc = new Point(Loc.X, Loc.Y - speed);
                Direction = DIRECTION.UP;
            }
            else if(action == ACTION.MOVEDOWN)
            {
                NextLoc = new Point(Loc.X, Loc.Y + speed);
                Direction = DIRECTION.DOWN;
            }
            else if (action == ACTION.MOVELEFT)
            {
                NextLoc = new Point(Loc.X - speed, Loc.Y); 
                Direction = DIRECTION.LEFT;
            }
            else
            {
                NextLoc = new Point(Loc.X + speed, Loc.Y);
                Direction = DIRECTION.RIGHT;
            }
            if (Utilities.IsCollisionObstacle(NextLoc, Width, Height, Direction) == null && !Bound.IsCollisionBound(NextLoc, Width, Height, Direction))
            {
                Loc = NextLoc;
            }
            RotateTank();
        }
        public virtual void DrawTank(Graphics grp)
        {
            grp.DrawImage(tankAvatar, new Rectangle(Loc.X, Loc.Y, Width, Height));
        }

        public void Fire()
        {
            Point bulletLoc = new Point(0,0);
            switch (Direction)
            {
                case DIRECTION.UP:
                    bulletLoc = new Point(Loc.X + Width / 2 - 5, Loc.Y);
                    break;
                case DIRECTION.RIGHT:
                    bulletLoc = new Point(Loc.X + Width, Loc.Y + Height / 2 - 5);
                    break;
                case DIRECTION.DOWN:
                    bulletLoc = new Point(Loc.X + Width / 2 - 5, Loc.Y + Height);
                    break;
                case DIRECTION.LEFT:
                    bulletLoc = new Point(Loc.X, Loc.Y + Height / 2 - 5);
                    break;
            }
            Bullet b = new Bullet(bulletLoc, Direction, isOfPlayer, bulletColor);
            Bullets.Add(b);
            Timer t = new Timer();
            t.Tick += T_Tick;
            t.Start();
            b.Move();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            List<Bullet> rm = new List<Bullet>();
            Bullets.ForEach(b => {
                if (!b.IsMoving)
                    rm.Add(b);
            });
            foreach (Bullet b in rm)
            {
                Bullets.Remove(b);
            }
            rm.Clear();
        }

        public void DrawBullets(Graphics grp)
        {
            Bullets.ForEach(b => {
                b.DrawBullet(grp);
            });
        }
    }
}
