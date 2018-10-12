using System;
using System.Collections.Generic;
using System.Text;
using PlutoRover.Core;

namespace PlutoRover.Concrete
{
    public class Rover : IRover
    {
        public Rover(GridMap map, Position initialPosition, Direction initialDirection)
        {

        }

        public Position Position => throw new NotImplementedException();

        public void MoveForward()
        {
            throw new NotImplementedException();
        }
    }
}
