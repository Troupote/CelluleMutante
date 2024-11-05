﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelluleMutante2
{
    public class Cell
    {
        public int size;
        public Color color;
        private Random rnd = new Random();

        public Cell()
        {
            size = 10;
            color = Color.Black;
        }

        public void Mutation()
        {
            size += 5;
            color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }
}
