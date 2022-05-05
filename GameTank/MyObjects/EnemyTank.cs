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
        private bool lockMove = true;

        public EnemyTank(Point loc, bool isOfPlayer, Color bulletColor, int bulletSpeed, int bulletDamage, int health, string srcFile) : base(loc, isOfPlayer, bulletColor, bulletSpeed, bulletDamage, health)
        {
            SrcFile = srcFile;
            using (Image imgTank = Image.FromFile(SrcFile))
            {
                TankAvatar = new Bitmap(imgTank);
            }
        }

        public bool LockMove { get => lockMove; set => lockMove = value; }

        public override void DrawTank(Graphics grp)
        {
            base.DrawTank(grp);
            grp.FillRectangle(new SolidBrush(Color.White), new Rectangle(Loc.X, Loc.Y + Height / 2 - 10, Width, 10));
            grp.FillRectangle(new SolidBrush(Color.Red), new Rectangle(Loc.X, Loc.Y + Height/2 - 10, (Health * Width) / ((int)TANK.ENEMY_HEALTH * GameStage.CurrentState), 10));
        }
    }
}
