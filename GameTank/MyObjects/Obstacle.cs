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
        private bool isCanDestroy = true;

        public Obstacle(Point start, int width, int height):base(start, width, height)
        {
            Obs = new List<PartialObstacle>();
            CreateObstacle();
        }

        public bool IsCanDestroy { get => isCanDestroy; set => isCanDestroy = value; }
        internal List<PartialObstacle> Obs { get => obs; set => obs = value; }

        public void CreateObstacle()
        {
            int m = Height / 10;
            int n = Width / 20;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    PartialObstacle p = new PartialObstacle(new Point(Location.X + j * 20, Location.Y + i * 10));
                    Obs.Add(p);
                }
            }
        }
        public void DrawObstacle(Graphics grp)
        {
            Obs.ForEach(o => o.DrawPartialObstacle(grp));
        }
    }
}
