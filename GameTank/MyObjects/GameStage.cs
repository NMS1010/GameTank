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
    internal static class GameStage
    {
        public static Panel MainGamePnl;

        public static List<Obstacle> ObstaclesStage;
        public static List<PartialObstacle> PartialObstacle;

        public static List<EnemyTank> EnemyTanks;
        public static List<Point> SpawEnemyPoint;

        public static PlayerTank PlayerTank;

        public static PictureBox TotalPlayerHealth;
        public static PictureBox CurrentPlayerHealth;
        public static Panel CurrentNumberEnemyContainer;

        public static int EnemyPerTurn;
        public static int NumberEnemy;
        public static int CurrentState = 1;
        public static Bitmap avatarTank;
        static GameStage()
        {
            SpawEnemyPoint = new List<Point>() {
                new Point(30,30), 
                new Point(100,30),
                new Point(400,30),
                new Point(600,30)
            };
            using (Image tankImg = Image.FromFile("../../Image/enemyScore.bmp"))
            {
                avatarTank = new Bitmap(tankImg);
            }
        }
        private static void DisplayCurrentNumberEnemy()
        {
            int nRow = (int)Math.Ceiling(NumberEnemy / 4.0);
            int nCol = 4;

            PictureBox PrePtrb = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, 0) };
            PictureBox CurrPtrb;
            for (int i = 0; i < nRow; i++)
            {
                for(int j = 0; j < nCol; j++)
                {
                    if (i * 4 + j >= NumberEnemy)
                        return;
                    CurrPtrb = new PictureBox()
                    {
                        Size = new Size(45, 45),
                        Location = new Point(PrePtrb.Location.X + PrePtrb.Size.Width + 5, PrePtrb.Location.Y),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = avatarTank
                    };
                    CurrentNumberEnemyContainer.Controls.Add(CurrPtrb);
                    PrePtrb = CurrPtrb;
                }
                PrePtrb = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, PrePtrb.Location.Y + 50) };
            }
        }
        public static void Stage1()
        {
            CurrentState = 1;
            Bound.DrawBound();
            EnemyPerTurn = 1;
            NumberEnemy = 1;
            DisplayCurrentNumberEnemy();
            ObstaclesStage = new List<Obstacle>();
            PartialObstacle = new List<PartialObstacle>();
            EnemyTanks = new List<EnemyTank>();
            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(80, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(200, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(320, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(360, 120), 80, 60, false),
                new Tuple<Point, int, int, bool>(new Point(440, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(560, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(680, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(20, 320), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(20, 340), 40, 20, false),
                new Tuple<Point, int, int, bool>(new Point(120, 320), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(320, 280), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(440, 280), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(560, 320), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(740, 320), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(740, 340), 40, 20, false),
            };
            for(int i = 0; i < obs.Count; i++)
            {
                Obstacle temp = new Obstacle(obs[i].Item1, obs[i].Item2, obs[i].Item3, obs[i].Item4);
                ObstaclesStage.Add(temp);
                PartialObstacle.AddRange(temp.Obs);
            }
            DrawStage(ObstaclesStage);
        }

        public static void Stage2()
        {
            CurrentState = 2;
            Bound.DrawBound();
            EnemyPerTurn = 2;
            NumberEnemy = 2;
            DisplayCurrentNumberEnemy();
            ObstaclesStage = new List<Obstacle>();
            PartialObstacle = new List<PartialObstacle>();
            EnemyTanks = new List<EnemyTank>();

            List<Tuple<Point, int, int, bool>> obs = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(80, 180), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(200, 180), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(320, 180), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(360, 220), 80, 60, false),
                new Tuple<Point, int, int, bool>(new Point(440, 180), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(560, 180), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(680, 180), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(20, 420), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(20, 440), 40, 20, false),
                new Tuple<Point, int, int, bool>(new Point(120, 420), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(320, 380), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(440, 380), 40, 40, true),
                new Tuple<Point, int, int, bool>(new Point(560, 420), 120, 40, true),
                new Tuple<Point, int, int, bool>(new Point(740, 420), 40, 20, true),
                new Tuple<Point, int, int, bool>(new Point(740, 440), 40, 20, false),
            };
            for (int i = 0; i < obs.Count; i++)
            {
                Obstacle temp = new Obstacle(obs[i].Item1, obs[i].Item2, obs[i].Item3, obs[i].Item4);
                ObstaclesStage.Add(temp);
                PartialObstacle.AddRange(temp.Obs);
            }
            DrawStage(ObstaclesStage);
        }
        public static void ClearStage()
        {
            MainGamePnl.Controls.Clear();
            CurrentNumberEnemyContainer.Controls.Clear();
            PartialObstacle = null;
            ObstaclesStage = null;
            EnemyTanks = null;
        }
        public static void DrawStage(List<Obstacle> ObstaclesStage)
        {
            ObstaclesStage.ForEach(o => o.DrawObstacle());
        }
    }
}
