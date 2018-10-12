using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PlutoRover.Core;
using PlutoRover.Concrete;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Rover_Can_Move_Forward()
        {
            Position initialPosition = new Position(0, 0);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(100, 100); 
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveForward();
            Assert.IsTrue(rover.Position.X == 0);
            Assert.IsTrue(rover.Position.Y == 1);
        }
    }
}
