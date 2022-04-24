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
        public static List<EnemyTank> EnemyTankStage = null;
        public static List<EnemyTank> SampleEnemyTankStage = null;
        public static PlayerTank PlayerTank;
        public static int enemyPerTurn;
        public static int numberEnemy;

        static GameStage()
        {
            SampleEnemyTankStage = new List<EnemyTank>() {
                new EnemyTank(new Point(30,30), isOfPlayer:  false, Color.Red),
                new EnemyTank(new Point(740,30), isOfPlayer:  false, Color.Red),
                new EnemyTank(new Point(600,500), isOfPlayer:  false, Color.Red),
                new EnemyTank(new Point(30,400), isOfPlayer:  false, Color.Red)
            };
        }
        public static void State1()
        {
            enemyPerTurn = 2;
            numberEnemy = 10;
            ObstaclesStage = new List<Obstacle>();
            PartialObstacle = new List<PartialObstacle>();
            EnemyTankStage = new List<EnemyTank>();
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
        public static void DrawStage(List<Obstacle> ObstaclesStage)
        {
            ObstaclesStage.ForEach(o => o.DrawObstacle());
        }
    }
}
