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

        public static HashSet<int> RandomNotDup(int quantity, int min, int max)
        {
            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < quantity)
            {
                numbers.Add(random.Next(min, max + 1));
            }
            return numbers;
        }
        public static int ChooseEnemyDirection(EnemyTank e)
        {
            if (IsCollisionObstacle(e.NextLoc, e.Width, e.Height, e.Direction) == null
                && !Bound.IsCollisionBound(e.NextLoc, e.Width, e.Height, e.Direction))
                return (int)e.Direction;
            return (new Random()).Next(0, 4);
        }

        public static void HandleBulletCollision(Bullet bullet, Point bulletPoint)
        {
            PartialObstacle ob = Utilities.IsCollisionObstacle(bulletPoint, bullet.Width, bullet.Height, bullet.Direction);
            if (ob != null)
            {
                if (ob.IsCanDestroy)
                {
                    ob.Health -= bullet.Damage;
                    if (ob.Health <= 0)
                    {
                        GameStage.MainGamePnl.Controls.Remove(ob.Ob);
                        GameStage.PartialObstacle.Remove(ob);
                    }
                    ob = null;
                }
                bullet.IsMoving = false;
            }
            if (bullet.IsOfPlayer)
            {
                EnemyTank enemyTank = Utilities.IsCollisionEnemy(bullet.Loc, GameStage.EnemyTankStage, bullet.Width, bullet.Height);
                if (enemyTank != null)
                {
                    enemyTank.Health -= bullet.Damage;
                    if (enemyTank.Health <= 0)
                    {
                        GameStage.EnemyTankStage.Remove(enemyTank);
                        GameStage.numberEnemy--;
                        if (GameStage.numberEnemy == 0)
                        {
                            MessageBox.Show("Pass Stage");
                        }
                    }
                    bullet.IsMoving = false;
                    enemyTank = null;
                }
            }
            else
            {
                if (Utilities.CheckHitTank(GameStage.PlayerTank, bullet.Loc, GameStage.PlayerTank.Width, GameStage.PlayerTank.Height))
                {
                    GameStage.PlayerTank.Health -= bullet.Damage;
                    if (GameStage.PlayerTank.Health <= 0)
                    {
                        GameStage.PlayerTank = null;
                        MessageBox.Show("Lose");
                    }
                    bullet.IsMoving = false;
                }
            }
            if (Bound.IsCollisionBound(bulletPoint, bullet.Width, bullet.Height, bullet.Direction))
            {
                bullet.IsMoving = false;
            }
        }
    }
}
