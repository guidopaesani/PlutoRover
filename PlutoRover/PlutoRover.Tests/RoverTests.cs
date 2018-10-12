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
        public void Rover_Can_Move_Forward_From_0_0()
        {
            Position initialPosition = new Position(0, 0);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveForward();
            Assert.IsTrue(rover.Position.X == 0);
            Assert.IsTrue(rover.Position.Y == 1);
        }
        [Test]
        public void Rover_Can_Move_Forward_From_Other_Starting_Point()
        {
            Position initialPosition = new Position(10, 10);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveForward();
            Assert.IsTrue(rover.Position.X == 10);
            Assert.IsTrue(rover.Position.Y == 11);
        }

        [Test]
        public void Rover_Can_Move_BackWards()
        {
            Position initialPosition = new Position(10, 10);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveBackwards();
            Assert.IsTrue(rover.Position.X == 10);
            Assert.IsTrue(rover.Position.Y == 9);
        }

        [Test]
        public void Rover_Can_Move_BackWards_When_Facing_East()
        {
            Position initialPosition = new Position(5, 5);
            Direction initialDirection = Direction.East;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveBackwards();
            Assert.IsTrue(rover.Position.X == 4);
            Assert.IsTrue(rover.Position.Y == 5);
        }
        [Test]
        public void Rover_Can_Move_Forward_When_Facing_East()
        {
            Position initialPosition = new Position(5, 5);
            Direction initialDirection = Direction.East;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveForward();
            Assert.IsTrue(rover.Position.X == 6);
            Assert.IsTrue(rover.Position.Y == 5);
        }
        [Test]
        public void Rover_Can_Wrap_Plane_X_Forward()
        {
            Position initialPosition = new Position(99, 99);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(100, 100);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveForward();
            Assert.IsTrue(rover.Position.X == 99);
            Assert.IsTrue(rover.Position.Y == 0);
        }
        [Test]
        public void Rover_Can_Wrap_Plane_Y_Backwards()
        {
            Position initialPosition = new Position(0, 0);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(50, 50);
            IRover rover = new Rover(map, initialPosition, initialDirection);
            rover.MoveBackwards();
            Assert.IsTrue(rover.Position.X == 0);
            Assert.IsTrue(rover.Position.Y == 49);
        }
        [Test]
        public void Trying_to_move_to_position_where_obstacle_detected_throws_exception()
        {
            Position initialPosition = new Position(0, 0);
            Direction initialDirection = Direction.North;
            GridMap map = new GridMap(50, 50);
            map.Obstacles.Add(new Position(0, 1));
            IRover rover = new Rover(map, initialPosition, initialDirection);
            Assert.Throws<Exception>(() => { rover.MoveForward(); });            
            
        }






    }
}
