using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class Obstacle: PartialObstacle
    {
        private List<PartialObstacle> obs;

        public Obstacle(Point start, int width, int height, bool isCanDestroy) :base(start, width, height, isCanDestroy)
        {
            Obs = new List<PartialObstacle>();
            CreateObstacle(isCanDestroy);
        }

        internal List<PartialObstacle> Obs { get => obs; set => obs = value; }

        public void CreateObstacle(bool isCanDestroy)
        {
            int m = Height / 10;
            int n = Width / 20;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    PartialObstacle p = new PartialObstacle(new Point(Loc.X + j * 20, Loc.Y + i * 10));
                    p.IsCanDestroy = isCanDestroy;
                    Obs.Add(p);
                }
            }
        }
        public void DrawObstacle()
        {
            Obs.ForEach(o => o.DrawPartialObstacle());
        }
    }
}
