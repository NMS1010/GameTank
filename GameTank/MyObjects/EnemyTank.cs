using GameTank.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class EnemyTank: Tank
    {
        public EnemyTank(Point loc, bool isOfPlayer) : base(loc, isOfPlayer)
        {

        }
        public EnemyTank(Point loc, bool isOfPlayer, Color color) : base(loc, isOfPlayer, color)
        {

        }
        public override void DrawTank(Graphics grp)
        {
            base.DrawTank(grp);
            grp.FillRectangle(new SolidBrush(Color.White), new Rectangle(Loc.X, Loc.Y + Height/2 - 10, Width, 10));
            grp.FillRectangle(new SolidBrush(Color.Red), new Rectangle(Loc.X, Loc.Y + Height/2 - 10, (Health * Width) / 100, 10));
        }
    }
}
