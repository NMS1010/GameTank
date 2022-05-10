﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class BulletSpeedItem : Item
    {
        public int BulletSpeed { get; set; }
        public BulletSpeedItem(Point loc, int width, int height, string pathFile) : base(loc, width, height, pathFile)
        {
            BulletSpeed = 10;
        }
    }
}
