﻿using GameTank.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank.MyObjects
{
    internal static class Utilities
    {
        public static Tuple<Point, Point> GetAheadPoints(Point nextLoc, int width, int height, DIRECTION direction)
        {
            Tuple<Point, Point> aheadPoint = null;
            switch (direction)
            {
                case DIRECTION.UP:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y), new Point(nextLoc.X + width, nextLoc.Y));
                    break;
                case DIRECTION.RIGHT:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X + width, nextLoc.Y), new Point(nextLoc.X + width, nextLoc.Y + height));
                    break;
                case DIRECTION.DOWN:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y + height), new Point(nextLoc.X + width, nextLoc.Y + height));
                    break;
                case DIRECTION.LEFT:
                    aheadPoint = new Tuple<Point, Point>(new Point(nextLoc.X, nextLoc.Y), new Point(nextLoc.X, nextLoc.Y + height));
                    break;
            }
            return aheadPoint;
        }
        public static PartialObstacle CheckCollision(Point nextLoc, List<PartialObstacle> obstacles , int width, int height, DIRECTION direction)
        {
            if (direction == DIRECTION.UP || direction == DIRECTION.LEFT)
            {
                for(int i=obstacles.Count-1; i>=0; i--)
                {
                    if (obstacles[i].Ob.Bounds.IntersectsWith(new Rectangle(nextLoc, new Size(width, height))))
                    {
                        return obstacles[i];
                    }
                }
            }
            else
            {
                foreach (PartialObstacle obstacle in obstacles)
                {
                    if (obstacle.Ob.Bounds.IntersectsWith(new Rectangle(nextLoc, new Size(width, height))))
                    {
                        return obstacle;
                    }
                }
            }
            return null;
        }
        public static PartialObstacle IsCollisionObstacle(Point nextLoc, int width, int height, DIRECTION direction)
        {  
           return CheckCollision(nextLoc, GameStage.PartialObstacle, width, height, direction);
        }
        public static bool CheckHitTank(Tank tank, Point nextLoc, int width, int height)
        {
            PictureBox tankPtrb = new PictureBox() { Location = tank.Loc, Width = tank.Width, Height = tank.Height };
            if (tankPtrb.Bounds.IntersectsWith(new Rectangle(nextLoc, new Size(width, height))))
            {
                return true;
            }
            return false;
        }
        public static EnemyTank IsCollisionEnemy(Point nextLoc, List<EnemyTank> enemyTanks, int width, int height)
        {
            foreach (EnemyTank enemyTank in enemyTanks)
            {
                if(CheckHitTank(enemyTank, nextLoc, enemyTank.Width, enemyTank.Height))
                {
                    return enemyTank;
                }
            }
            return null;
        }

        public static int ChooseEnemyDirection(EnemyTank e)
        {
            if (IsCollisionObstacle(e.NextLoc, e.Width, e.Height, e.Direction) == null
                && !Bound.IsCollisionBound(e.NextLoc, e.Width, e.Height, e.Direction))
                return (int)e.Direction;
            return (new Random()).Next(0, 4);
        }
    }
}