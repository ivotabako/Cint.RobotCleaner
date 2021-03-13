using System;
using System.Collections.Generic;
using Xunit;

namespace Cint.RobotCleaner.Tests
{
    public class RobotCleanerTests
    {
        [Theory]
        [InlineData(0, 0, 0, 1)]
        [InlineData(1, 0, 0, "E", 1, 2)]
        [InlineData(1, 0, 0, "E", 5, 6)]
        [InlineData(1, 0, 0, "S", 5, 6)]
        [InlineData(1, 0, 0, "W", 3, 4)]
        [InlineData(1, 0, 0, "N", 7, 8)]
        [InlineData(2, 10, 22, "E", 2, "N", 1, 4)]
        public void CleanRoomTests(params object[] input)
        {
            int numOfCommands = (int)input[0];
            Coordinates initialPosition = new Coordinates((int)input[1], (int)input[2]);
            List<Command> commands = new List<Command>();

            for (int i = 0; i < numOfCommands; i++)
            {
                commands.Add(new Command((string)input[i*2 + 3], (int)input[i*2 + 3 + 1]));
            }
            
            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
            Assert.Equal(input[input.Length-1], numOfPlaces);
        }
    }

    class Command
    {
        public Command(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
        public string Direction { get; }
        public int Steps { get; }
    }

    class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }

    class RobotCleaner
    {
        internal int CleanRoom(int numOfCommands, Coordinates initialVortex, List<Command> commands)
        {
            var visitedVertices = new HashSet<Coordinates>();
            visitedVertices.Add(initialVortex);

            if (numOfCommands == 0)
            {
                return visitedVertices.Count;
            }
            var currentVortex = initialVortex; 
            foreach (var command in commands)
            {
                for (int i = 1; i <= command.Steps; i++)
                {
                    if (command.Direction == "E")
                    {
                        var newVortex = new Coordinates(currentVortex.X + i, currentVortex.Y);
                        visitedVertices.Add(newVortex);
                    }

                    if (command.Direction == "S")
                    {
                        var newVortex = new Coordinates(currentVortex.X, currentVortex.Y - i);
                        visitedVertices.Add(newVortex);
                    }

                    if (command.Direction == "W")
                    {
                        var newVortex = new Coordinates(currentVortex.X - i, currentVortex.Y);
                        visitedVertices.Add(newVortex);
                    }

                    if (command.Direction == "N")
                    {
                        var newVortex = new Coordinates(currentVortex.X, currentVortex.Y + i);
                        visitedVertices.Add(newVortex);
                    }
                }
            }

            return visitedVertices.Count;
        }
    }
}
