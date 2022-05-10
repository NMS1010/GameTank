﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank.MyObjects
{
    internal class HealthItem : Item
    {
        public int Health { get; set; }
        public HealthItem(Point loc, int width, int height, string pathFile) : base(loc, width, height, pathFile)
        {
            Health = 10;
        }
    }
}
