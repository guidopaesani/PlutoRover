using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Core
{
    public interface IRover
    {
        void MoveForward();
        void MoveBackwards();
        void RotateLeft();
        void RotateRight();
        Position Position { get; }
        Direction Direction { get; }
    }
}
