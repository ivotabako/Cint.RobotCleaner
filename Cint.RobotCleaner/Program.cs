using System;
using System.Collections.Generic;

namespace Cint.RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = Convert.ToInt32(Console.ReadLine());
            string[] initialCoordinates = Console.ReadLine().Split(" ");
            Coordinates initialPosition = new Coordinates(Convert.ToInt32(initialCoordinates[0]), Convert.ToInt32(initialCoordinates[1]));
            List<Command> commands = new List<Command>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                commands.Add(new Command((string)command[0], Convert.ToInt32(command[1])));
            }

            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
            Console.WriteLine($"=> Cleaned: {numOfPlaces}");
        }
    }
}
