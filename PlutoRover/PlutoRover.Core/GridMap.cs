using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Core
{
    public class GridMap
    {
        public GridMap(int sizeX, int sizeY)
        {
            MaxX = sizeX - 1;
            MaxY = sizeY - 1;
            Obstacles = new List<Position>();
        }

        public List<Position> Obstacles { get; set; }

        public int MaxX { get; }
        public int MaxY { get; }


    }
}
