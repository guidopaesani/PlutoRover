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
            Direction = initialDirection;
        }

        public Position Position => _position;
        public Direction Direction { get; }

        public void MoveBackwards()
        {
            switch (Direction)
            {
                case Direction.North:
                    _position = new Position(_position.X, _position.Y - 1);
                    break;
                case Direction.East:
                    _position = new Position(_position.X - 1, _position.Y);
                    break;
            }
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    _position = new Position(_position.X, _position.Y + 1);
                    break;
                case Direction.East:
                    _position = new Position(_position.X + 1, _position.Y);
                    break;
            }
        }
    }
}
