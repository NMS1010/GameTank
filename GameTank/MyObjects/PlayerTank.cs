using GameTank.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class PlayerTank: Tank
    {
        public bool IsDestroy { get; set; } = false;
        public PlayerTank(Point loc, bool isOfPlayer, Color bulletColor, int bulletSpeed, int bulletDamage, int health) :base(loc, isOfPlayer, bulletColor, bulletSpeed, bulletDamage, health)
        {
            SrcFile = "../../Image/skin1player.png";
            using (Image imgTank = Image.FromFile(SrcFile))
            {
                TankAvatar = new Bitmap(imgTank);
            }
        }

        public void UpdateAvatar(string src)
        {
            SrcFile = src;
            using (Image imgTank = Image.FromFile(SrcFile))
            {
                TankAvatar = new Bitmap(imgTank);
            }
        }
    }
}
