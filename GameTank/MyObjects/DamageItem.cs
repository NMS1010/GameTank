using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class DamageItem : Item
    {
        public int Damage { get; set; }
        public DamageItem(Point loc, int width, int height, Image img) : base(loc, width, height, img)
        {
            Damage = 10;
        }
    }
}
