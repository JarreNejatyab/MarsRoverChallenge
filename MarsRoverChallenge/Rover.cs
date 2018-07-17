using Stateless;

namespace MarsRoverChallenge
{
    /// <summary>
    /// a class presenting each rover on mission
    /// </summary>
    public class Rover : IRover
    {
        private StateMachine<Direction, Trigger> _stateMachine;

        public Direction Direction { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// constructs a rover based on location and position
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Rover(Direction direction,int x,int y)
        {
            InitStateMachine();

            Direction = direction;
            X = x;
            Y = y;
        }

        public void TurnLeft()
        {
            _stateMachine.Fire(Trigger.L);
        }

        public void TurnRight()
        {
            _stateMachine.Fire(Trigger.R);
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    Y++;
                    break;
                case Direction.S:
                    Y--;
                    break;
                case Direction.E:
                    X++;
                    break;
                case Direction.W:
                    X--;
                    break;
            }
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine<Direction, Trigger>(() => Direction, s => Direction = s);

            _stateMachine.Configure(Direction.N)
                .Permit(Trigger.L, Direction.W);

            _stateMachine.Configure(Direction.W)
                .Permit(Trigger.L, Direction.S);

            _stateMachine.Configure(Direction.S)
                .Permit(Trigger.L, Direction.E);

            _stateMachine.Configure(Direction.E)
                .Permit(Trigger.L, Direction.N);

            _stateMachine.Configure(Direction.N)
                .Permit(Trigger.R, Direction.E);

            _stateMachine.Configure(Direction.E)
                .Permit(Trigger.R, Direction.S);

            _stateMachine.Configure(Direction.S)
                .Permit(Trigger.R, Direction.W);

            _stateMachine.Configure(Direction.W)
                .Permit(Trigger.R, Direction.N);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _stateMachine = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}