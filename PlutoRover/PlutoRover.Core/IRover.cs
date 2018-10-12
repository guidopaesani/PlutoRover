using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Core
{
    public interface IRover
    {
        void MoveForward();
        void MoveBackwards();
        Position Position { get; }
    }
}
