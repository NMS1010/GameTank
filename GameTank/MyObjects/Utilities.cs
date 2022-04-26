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
                for (int i = 0; i < obstacles.Count; i++)
                {
                    if (obstacles[i].Ob.Bounds.IntersectsWith(new Rectangle(nextLoc, new Size(width, height))))
                    {
                        return obstacles[i];
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
            PartialObstacle ob = IsCollisionObstacle(bulletPoint, bullet.Width, bullet.Height, bullet.Direction);
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
                }
                bullet.IsMoving = false;
            }
            if (bullet.IsOfPlayer)
            {
                EnemyTank enemyTank = IsCollisionEnemy(bullet.Loc, GameStage.EnemyTanks, bullet.Width, bullet.Height);
                if (enemyTank != null)
                {
                    if(!EnemySpawner.IsLockDamage)
                        enemyTank.Health -= bullet.Damage;
                    if (enemyTank.Health <= 0)
                    {
                        GameStage.EnemyTanks.Remove(enemyTank);
                        GameStage.NumberEnemy--;
                        GameStage.CurrentNumberEnemyContainer.Controls.RemoveAt(GameStage.CurrentNumberEnemyContainer.Controls.Count - 1);
                    }
                    bullet.IsMoving = false;
                }
            }
            else
            {
                if (CheckHitTank(GameStage.PlayerTank, bullet.Loc, bullet.Width, bullet.Height))
                {
                    GameStage.PlayerTank.Health -= bullet.Damage;
                    GameStage.CurrentPlayerHealth.Width = (GameStage.PlayerTank.Health * GameStage.TotalPlayerHealth.Width) / (int)TANK.PLAYER_HEALTH;
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
