﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Core
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
