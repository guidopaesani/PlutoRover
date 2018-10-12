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
        private Direction _direction;

        public Rover(GridMap map, Position initialPosition, Direction initialDirection)
        {
            _position = initialPosition;
            _direction = initialDirection;
            _map = map;
        }

        public Position Position => _position;
        public Direction Direction => _direction;

        public void MoveBackwards()
        {
            Position newPosition = _position;
            switch (Direction)
            {
                case Direction.North:
                    newPosition = new Position(_position.X, _position.Y - 1);
                    break;
                case Direction.South:
                    newPosition = new Position(_position.X, _position.Y + 1);
                    break;
                case Direction.East:
                    newPosition = new Position(_position.X - 1, _position.Y);
                    break;
                case Direction.West:
                    newPosition = new Position(_position.X + 1, _position.Y);
                    break;
            }
            if (DetectObstacle(_map, newPosition)) throw new Exception("Can't move to that position! obstacle detected");
            
            _position = DetectBoundariesCrossing(newPosition, _map);

        }

        public void MoveForward()
        {
            Position newPosition = _position;

            switch (Direction)
            {
                case Direction.North:
                    newPosition = new Position(_position.X, _position.Y + 1);
                    break;
                case Direction.South:
                    newPosition = new Position(_position.X, _position.Y - 1);
                    break;
                case Direction.East:
                    newPosition = new Position(_position.X + 1, _position.Y);
                    break;
                case Direction.West:
                    newPosition = new Position(_position.X - 1, _position.Y);
                    break;
            }
            if (DetectObstacle(_map, newPosition)) throw new Exception("Can't move to that position! obstacle detected");

            _position = DetectBoundariesCrossing(newPosition, _map);


        }

        public void RotateLeft()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.North;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;

            }
        }

        private Position DetectBoundariesCrossing(Position position, GridMap map)
        {
            if (position.X < 0) return new Position(map.MaxX, position.Y);
            if (position.Y < 0) return new Position(position.X, map.MaxY);
            if (position.X > map.MaxX) return new Position(0, position.Y);
            if (position.Y > map.MaxY) return new Position(position.X, 0);
            return position;
        }

        private bool DetectObstacle(GridMap map, Position position)
        {
            if (map.Obstacles.Exists(obs => obs.X == position.X && obs.Y == position.Y)) return true;
            return false;
        }
        


    }
}
