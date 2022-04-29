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
        static Timer t;

        static Utilities()
        {
            t = new Timer();
            t.Interval = 1000;
        }
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
        public static PartialObstacle CheckCollisionObstacle(Point nextLoc, List<PartialObstacle> obstacles , int width, int height, DIRECTION direction)
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
           return CheckCollisionObstacle(nextLoc, GameStage.PartialObstacle, width, height, direction);
        }

        public static bool CheckCollisionTank(Point nextLoc, List<EnemyTank> enemyTanks, Tank tank)
        {
            foreach(EnemyTank e in enemyTanks) { 
                if (e != tank && (new Rectangle(nextLoc, new Size(tank.Width, tank.Height))).IntersectsWith(new Rectangle(e.Loc, new Size(e.Width, e.Height))))
                {
                    return true;
                }
            }
            if (!tank.IsOfPlayer)
            {
                if ((new Rectangle(nextLoc, new Size(tank.Width, tank.Height))).IntersectsWith(new Rectangle(GameStage.PlayerTank.Loc, new Size(GameStage.PlayerTank.Width, GameStage.PlayerTank.Height))))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsCollisionTank(Point nextLoc, Tank tank)
        {
            return CheckCollisionTank(nextLoc, GameStage.EnemyTanks, tank);
        }
        public static bool CheckHitTank(Tank tank, Point nextLoc, int width, int height)
        {
            PictureBox tankPtrb = new PictureBox() { Location = tank.Loc, Width = tank.Width, Height = tank.Height, BackColor = Color.Red };
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
                && !Bound.IsCollisionBound(e.NextLoc, e.Width, e.Height, e.Direction)
                && !IsCollisionTank(e.NextLoc, e))
                return (int)e.Direction;
            if ((new Rectangle(e.NextLoc, new Size(e.Width, e.Height))).IntersectsWith(
                new Rectangle(GameStage.PlayerTank.Loc, new Size(GameStage.PlayerTank.Width, GameStage.PlayerTank.Height))))
            {
                return (int)e.Direction;
            }
            return (new Random()).Next(0, 4);
        }

        private static Point GetPointCollision(DIRECTION direction, Point bulletLoc)
        {
            Point p = new Point(0, 0);
            if (direction == DIRECTION.UP)
            {
                p.X = bulletLoc.X - 18;
                p.Y = bulletLoc.Y;
            }else if(direction == DIRECTION.DOWN)
            {
                p.X = bulletLoc.X - 18;
                p.Y = bulletLoc.Y - 20;
            }else if (direction == DIRECTION.LEFT)
            {
                p.X = bulletLoc.X;
                p.Y = bulletLoc.Y - 18;
            }else if (direction == DIRECTION.RIGHT)
            {
                p.X = bulletLoc.X - 20;
                p.Y = bulletLoc.Y - 18;
            }
            return p;
        }

        public static void HandleBulletCollision(Bullet bullet, Point bulletPoint)
        {
            PartialObstacle ob = IsCollisionObstacle(bulletPoint, bullet.Width, bullet.Height, bullet.Direction);
            if (ob != null)
            {
                bullet.ShowExplode(GetPointCollision(bullet.Direction, bulletPoint));
                t.Tick += new EventHandler((sender, e) => explode_tick(sender, e, bullet));
                t.Start();
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
                    bullet.ShowExplode(GetPointCollision(bullet.Direction, bulletPoint));
                    t.Tick += new EventHandler((sender, e) => explode_tick(sender, e, bullet));
                    t.Start();
                    if (!EnemySpawner.IsLockDamage)
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
                    bullet.ShowExplode(GetPointCollision(bullet.Direction, bulletPoint));
                    t.Tick += new EventHandler((sender, e) => explode_tick(sender, e, bullet));
                    t.Start();
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
                bullet.ShowExplode(GetPointCollision(bullet.Direction, bulletPoint));
                t.Tick += new EventHandler((sender, e) => explode_tick(sender, e, bullet));
                t.Start();
                bullet.IsMoving = false;
            }
        }
        private static void explode_tick(object sender, EventArgs e, Bullet bullet)
        {
            bullet.RemoveExplode();
            (sender as Timer).Stop();
        }
    }
}
