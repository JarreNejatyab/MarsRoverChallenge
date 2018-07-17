using System;

namespace MarsRoverChallenge
{
    public interface IRover : IDisposable
    {
        void TurnLeft();
        void TurnRight();
        void Move();
        Direction Direction { get; }
        int X { get; }
        int Y { get; }
    }
}