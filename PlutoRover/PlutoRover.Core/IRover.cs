using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Core
{
    public interface IRover
    {
        void MoveForward();
        Position Position { get; }
    }
}
