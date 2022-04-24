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
        private int damage = 20;
        private Color bulletColor = Color.Yellow;
        private Point loc;
        private int width = 7;
        private int height = 7;
        private DIRECTION direction;
        private bool isMoving = false;
        private bool isOfPlayer;
        Timer t;

        public Bullet(Point loc, DIRECTION direction, bool isOfPlayer)
        {
            Loc = loc;
            Direction = direction;
            IsOfPlayer = isOfPlayer;
            t = new Timer();
            t.Tick += T_Tick;
        }
        public Bullet(Point loc, DIRECTION direction, bool isOfPlayer, Color color)
        {
            Loc = loc;
            Direction = direction;
            IsOfPlayer = isOfPlayer;
            bulletColor = color;
            t = new Timer();
            t.Tick += T_Tick;
        }
        public Color BulletColor { get => bulletColor; set => bulletColor = value; }
        public Point Loc { get => loc; set => loc = value; }
        public DIRECTION Direction { get => direction; set => direction = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool IsOfPlayer { get => isOfPlayer; set => isOfPlayer = value; }

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
            if(GameStage.PlayerTank == null)
            {
                t.Stop();
                return;
            }
            Point temp = NextLocation();
            PartialObstacle ob = Utilities.IsCollisionObstacle(temp, Width, Height, Direction);
            if (ob != null)
            {
                if (ob.IsCanDestroy)
                {
                    ob.Health -= damage;
                    if (ob.Health <= 0)
                    {
                        GameStage.MainGamePnl.Controls.Remove(ob.Ob);
                        GameStage.PartialObstacle.Remove(ob);
                    }
                }
                IsMoving = false;
            }
            if (IsOfPlayer)
            {
                EnemyTank enemyTank = Utilities.IsCollisionEnemy(Loc, GameStage.EnemyTankStage, Width, Height);
                if (enemyTank != null)
                {
                    enemyTank.Health -= damage;
                    if(enemyTank.Health <= 0)
                        GameStage.EnemyTankStage.Remove(enemyTank);
                    IsMoving = false;
                }
            }
            else
            {
                if (Utilities.CheckHitTank(GameStage.PlayerTank, Loc, GameStage.PlayerTank.Width, GameStage.PlayerTank.Height))
                {
                    GameStage.PlayerTank.Health -= damage;
                    if (GameStage.PlayerTank.Health <= 0)
                    {
                        GameStage.PlayerTank = null;
                        MessageBox.Show("Lose");
                    }
                    IsMoving = false;
                }
            }
            if (Bound.IsCollisionBound(temp, width, height, direction))
            {
                IsMoving = false;
            }
            if (!IsMoving)
                t.Stop();
            else
                Loc = temp;
        }

        
        public void DrawBullet(Graphics grp)
        {
            grp.FillEllipse(new SolidBrush(BulletColor), new Rectangle(Loc, new Size(Width, Height)));
        }
    }
}
