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
