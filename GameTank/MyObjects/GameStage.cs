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
        public static Panel MainGamePnl = null;
        public static List<Obstacle> ObstaclesStage = null;
        public static List<PartialObstacle> PartialObstacle = null;
        public static List<EnemyTank> EnemyTanks = null;
        public static List<EnemyTank> SampleEnemyTanks = null;
        public static PlayerTank PlayerTank;
        public static PictureBox TotalPlayerHealth;
        public static PictureBox CurrentPlayerHealth;
        public static int enemyPerTurn;
        public static int numberEnemy;
        public static int CurrentState;

        static GameStage()
        {
            SampleEnemyTanks = new List<EnemyTank>() {
                new EnemyTank(loc: new Point(30,30), isOfPlayer: false, bulletColor: Color.Red, bulletSpeed: 100, bulletDamage: 20, health: 100),
                new EnemyTank(loc: new Point(100,30), isOfPlayer: false, bulletColor: Color.Red, bulletSpeed: 100, bulletDamage: 20, health: 100),
                new EnemyTank(loc: new Point(400,30), isOfPlayer: false, bulletColor: Color.Red, bulletSpeed: 100, bulletDamage: 20, health: 100),
                new EnemyTank(loc: new Point(600,30), isOfPlayer: false, bulletColor: Color.Red, bulletSpeed: 100, bulletDamage: 20, health: 100)
            };
        }

        public static void Stage1()
        {
            CurrentState = 1;
            Bound.DrawBound();
            enemyPerTurn = 1;
            numberEnemy = 1;
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
            enemyPerTurn = 2;
            numberEnemy = 10;

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
        }
        public static void DrawStage(List<Obstacle> ObstaclesStage)
        {
            ObstaclesStage.ForEach(o => o.DrawObstacle());
        }
    }
}
