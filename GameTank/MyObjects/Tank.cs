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
        private int width = 40;
        private int height = 40;
        private int speed = 10;
        private Bitmap tankAvatar;
        private int direction = 0;
        private STAGE currStage;
        private List<Bullet> bullets = new List<Bullet>();
        private bool isFire = false;

        public bool IsFire { get => isFire; set => isFire = value; }
        internal List<Bullet> Bullets { get => bullets; set => bullets = value; }

        public Tank(Point loc, STAGE currStage)
        {
            this.loc = loc;
            this.currStage = currStage;
            using(Image imgTank = Image.FromFile("../../Image/playertank.bmp")){
                tankAvatar = new Bitmap(imgTank); 
            }
        }
        private void RotateTank()
        {
            using (Image imgTank = Image.FromFile("../../Image/playertank.bmp"))
            {
                using (Bitmap temp = new Bitmap(imgTank))
                {
                    switch (direction)
                    {
                        case 0:
                            break;
                        case 90:
                            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 180:
                            temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 270:
                            temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    tankAvatar.Dispose();
                    tankAvatar = new Bitmap(temp);
                }
            }
        }
        public Tuple<Point, Point> GetAheadTankPoints(Point nextLoc)
        {
            Tuple<Point, Point> aheadPoint = null;
            switch (direction)
            {
                case 0:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y), new Point(nextLoc.X + width, nextLoc.Y));
                    break;
                case 90:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X+ width, nextLoc.Y), new Point(nextLoc.X + width, nextLoc.Y + height));
                    break;
                case 180:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y + height), new Point(nextLoc.X + width, nextLoc.Y + height));
                    break;
                case 270:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y), new Point(nextLoc.X, nextLoc.Y + height));
                    break;
            }
            return aheadPoint;
        }
        public bool CheckCollision(Point nextLoc, List<Obstacle> obstacles)
        {
            Tuple<Point, Point> aheadPoints = GetAheadTankPoints(nextLoc);
            if (Bound.IsOutRange(Bound.TopBound, aheadPoints.Item1) || Bound.IsOutRange(Bound.BottomBound, aheadPoints.Item1)
                || Bound.IsOutRange(Bound.LeftBound, aheadPoints.Item1) || Bound.IsOutRange(Bound.RightBound, aheadPoints.Item1))
                return true;
            foreach (Obstacle obstacle in obstacles)
            {
                if (aheadPoints.Item1.X > obstacle.Loc.X && aheadPoints.Item1.X < obstacle.Loc.X + obstacle.Width
                   && aheadPoints.Item1.Y > obstacle.Loc.Y && aheadPoints.Item1.Y < obstacle.Loc.Y + obstacle.Height)
                    return true;
                if (aheadPoints.Item2.X > obstacle.Loc.X && aheadPoints.Item2.X < obstacle.Loc.X + obstacle.Width
                   && aheadPoints.Item2.Y > obstacle.Loc.Y && aheadPoints.Item2.Y < obstacle.Loc.Y + obstacle.Height)
                    return true;
                if(aheadPoints.Item1.Y == obstacle.Loc.Y && aheadPoints.Item2.Y == obstacle.Loc.Y + height)
                {
                    if (aheadPoints.Item1.X > obstacle.Loc.X && aheadPoints.Item1.X < obstacle.Loc.X + obstacle.Width
                   && aheadPoints.Item1.Y >= obstacle.Loc.Y && aheadPoints.Item1.Y <= obstacle.Loc.Y + obstacle.Height)
                        return true;
                }
                if (aheadPoints.Item1.X == obstacle.Loc.X && aheadPoints.Item2.X == obstacle.Loc.X + width)
                {
                    if (aheadPoints.Item1.X >= obstacle.Loc.X && aheadPoints.Item1.X <= obstacle.Loc.X + obstacle.Width
                   && aheadPoints.Item1.Y > obstacle.Loc.Y && aheadPoints.Item1.Y < obstacle.Loc.Y + obstacle.Height)
                        return true;
                }
            }
            return false;
        }
        public bool IsCollision(Point nextLoc)
        {
            switch (currStage)
            {
                case STAGE.STAGE1:
                    return CheckCollision(nextLoc, GameStage.ObstaclesStage1);
            }
            return false;
        }
        public void Move(ACTION action)
        {
            Point nextLoc;
            if (action == ACTION.UP)
            {
                nextLoc = new Point(loc.X, loc.Y - speed);
                direction = 0;
            }
            else if(action == ACTION.DOWN)
            {
                nextLoc = new Point(loc.X, loc.Y + speed);
                direction = 180;
            }
            else if (action == ACTION.LEFT)
            {
                nextLoc = new Point(loc.X - speed, loc.Y); 
                direction = 270;
            }
            else
            {
                nextLoc = new Point(loc.X + speed, loc.Y);
                direction = 90;
            }
            if (!IsCollision(nextLoc))
                loc = nextLoc;
            RotateTank();
        }
        public void DrawTank(Graphics grp)
        {
            grp.DrawImage(tankAvatar, new Rectangle(loc.X, loc.Y, width, height));
            
        }

        public void Fire()
        {
            Point bulletLoc = new Point(0,0);
            switch (direction)
            {
                case 0:
                    bulletLoc = new Point(loc.X + width/2, loc.Y);
                    break;
                case 90:
                    bulletLoc = new Point(loc.X + width, loc.Y + height / 2);
                    break;
                case 180:
                    bulletLoc = new Point(loc.X + width / 2, loc.Y + height);
                    break;
                case 270:
                    bulletLoc = new Point(loc.X, loc.Y + height / 2);
                    break;
            }
            Bullet b = new Bullet(bulletLoc, direction);
            Bullets.Add(b);
            IsFire = true;
            b.Move();
        }

        public void DrawBullets(Graphics grp)
        {
            Bullets.ForEach(b => {
                if (b.IsMoving) 
                    b.DrawBullet(grp);
            });
        }
    }
}
