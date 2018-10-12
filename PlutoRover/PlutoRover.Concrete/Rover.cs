using System;
using System.Collections.Generic;
using System.Text;
using PlutoRover.Core;

namespace PlutoRover.Concrete
{
    public class Rover : IRover
    {
        private Position _position;
        public Rover(GridMap map, Position initialPosition, Direction initialDirection)
        {
            _position = initialPosition;
        }

        public Position Position => _position;

        public void MoveForward()
        {
            _position = new Position(0, 1);
        }
    }
}
