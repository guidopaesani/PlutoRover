using System;
using System.Collections.Generic;
using System.Text;
using PlutoRover.Core;

namespace PlutoRover.Concrete
{
    public class Rover : IRover
    {
        private Position _position;
        private GridMap _map;

        public Rover(GridMap map, Position initialPosition, Direction initialDirection)
        {
            _position = initialPosition;
            Direction = initialDirection;
            _map = map;
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
                case Direction.South:
                    _position = new Position(_position.X, _position.Y + 1);
                    break;
                case Direction.East:
                    _position = new Position(_position.X - 1, _position.Y);
                    break;
                case Direction.West:
                    _position = new Position(_position.X + 1, _position.Y);
                    break;
            }
            _position = DetectBoundariesCrossing(_position, _map);

        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    _position = new Position(_position.X, _position.Y + 1);
                    break;
                case Direction.South:
                    _position = new Position(_position.X, _position.Y - 1);
                    break;
                case Direction.East:
                    _position = new Position(_position.X + 1, _position.Y);
                    break;
                case Direction.West:
                    _position = new Position(_position.X - 1, _position.Y);
                    break;
            }
            _position = DetectBoundariesCrossing(_position, _map);
           


        }

        private Position DetectBoundariesCrossing(Position position, GridMap map)
        {
            if (position.X < 0) return new Position(map.MaxX, position.Y);
            if (position.Y < 0) return new Position(position.X, map.MaxY);
            if (position.X > map.MaxX) return new Position(0, position.Y);
            if (position.Y > map.MaxY) return new Position(position.X, 0);
            return position;
        }


    }
}
