namespace MarsRoverChallenge
{
    public interface IRover
    {
        void TurnLeft();
        void TurnRight();
        void Move();
        Direction Direction { get; }
        int X { get; }
        int Y { get; }
    }
}