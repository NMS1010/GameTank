using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class GameStage
    {
        public static void State1(int numObstacle, Graphics grp)
        {
            List<Obstacle> obstacles = new List<Obstacle>();
            List<Tuple<Point, int, int, bool>> loc = new List<Tuple<Point, int, int, bool>>() {
                new Tuple<Point, int, int, bool>(new Point(80, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(200, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(320, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(440, 80), 40, 140, true),
                new Tuple<Point, int, int, bool>(new Point(560, 80), 40, 180, true),
                new Tuple<Point, int, int, bool>(new Point(680, 80), 40, 180, true),
            };
            for(int i = 0; i < numObstacle; i++)
            {
                obstacles.Add(new Obstacle(loc[i].Item1, loc[i].Item2, loc[i].Item3));
            }
            obstacles.ForEach(o => o.DrawObstacle(grp));
        }
    }
}
