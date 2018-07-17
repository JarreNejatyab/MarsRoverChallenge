using System;

namespace MarsRoverChallenge
{
    public class RoverController : IRoverController
    {
        private readonly string[] _instructions;
        private readonly IRover _rover1;
        private readonly IRover _rover2;
        private readonly int _upperRight;
        private readonly int _upperTop;


        /// <summary>
        /// A controller to parse and instruct rovers
        /// </summary>
        /// <param name="instructions"></param>
        public RoverController(string instructions)
        {
            _instructions = instructions.Split("\r\n");

            _upperRight = Convert.ToInt32(_instructions[0].Split(" ")[0]);
            _upperTop = Convert.ToInt32(_instructions[0].Split(" ")[1]);

            _rover1 = GetRover(_instructions[1]);
            _rover2 = GetRover(_instructions[3]);
        }

        /// <summary>
        /// runs instructions once initialized
        /// </summary>
        /// <returns>return the result of rovers movements</returns>
        /// <remarks>error in result of instructions will be returned</remarks>
        public string Action()
        {
            var result1 = ParseInstruct(_instructions[2].ToCharArray(), _rover1);
            var result2 = ParseInstruct(_instructions[4].ToCharArray(), _rover2);

            var result = $"{result1}{_rover1.X} {_rover1.Y} {_rover1.Direction}\r\n{result2}{_rover2.X} {_rover2.Y} {_rover2.Direction}";

            _rover1.Dispose();
            _rover2.Dispose();

            return result;
        }

        private string ParseInstruct(char[] t, IRover rover)
        {
            foreach (var c in t)
            {
                switch (c)
                {
                    case 'M':
                        if (!CanMove(rover)) return "invalid instructions:";

                        rover.Move();
                        break;
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                }
            }

            return "";
        }

        private bool CanMove(IRover rover)
        {
            if (rover.Y == _upperTop && rover.Direction == Direction.N)
                return false;

            if (rover.Y == 0 && rover.Direction == Direction.S)
                return false;

            if (rover.X == _upperRight && rover.Direction == Direction.E)
                return false;

            if (rover.X == 0 && rover.Direction == Direction.W)
                return false;

            return true;
        }

        private IRover GetRover(string location)
        {
            var value = location.Split(" ");

            Enum.TryParse(value[2], out Direction direction);
            int.TryParse(value[0], out var x);
            int.TryParse(value[1], out var y);

            var rover = new Rover(direction, x, y);

            return rover;
        }
    }
}