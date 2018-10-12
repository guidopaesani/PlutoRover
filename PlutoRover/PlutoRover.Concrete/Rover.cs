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
            if (_position.X < 0) _position = new Position(_map.MaxX, _position.Y);
            if (_position.Y < 0) _position = new Position(_position.X, _map.MaxY);
            if (_position.X > _map.MaxX) _position = new Position(0, _position.Y);
            if (_position.Y > _map.MaxY) _position = new Position(_position.X, 0);
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

            if (_position.X < 0) _position = new Position(_map.MaxX, _position.Y);
            if (_position.Y < 0) _position = new Position(_position.X, _map.MaxY);
            if (_position.X > _map.MaxX) _position = new Position(0 , _position.Y);
            if (_position.Y > _map.MaxY) _position = new Position(_position.X,0);


        }


    }
}
