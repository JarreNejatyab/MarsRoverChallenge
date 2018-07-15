using System;
using System.Text;

namespace MarsRoverChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input instructions:");

            StringBuilder instructionsBuilder = new StringBuilder();

            instructionsBuilder.Append($"{Console.ReadLine()}\r\n");
            instructionsBuilder.Append($"{Console.ReadLine()}\r\n");
            instructionsBuilder.Append($"{Console.ReadLine()}\r\n");
            instructionsBuilder.Append($"{Console.ReadLine()}\r\n");
            instructionsBuilder.Append($"{Console.ReadLine()}\r\n");

            var roverController = new RoverController(instructionsBuilder.ToString());
            string result = roverController.Action();

            Console.WriteLine("###########");
            Console.WriteLine("output:");
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
