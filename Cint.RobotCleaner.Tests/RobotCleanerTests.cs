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
        public void CleanRoomTests(params object[] input)
        {
            int numOfCommands = (int)input[0];
            Coordinates initialPosition = new Coordinates((int)input[1], (int)input[2]);
            List<Tuple<string, int>> commands = new List<Tuple<string, int>>();

            for (int i = 0; i < numOfCommands; i++)
            {
                commands.Add(new Tuple<string, int>((string)input[i + 3], (int)input[i + 3 + 1]));
            }
            
            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
            Assert.Equal(input[input.Length-1], numOfPlaces);
        }
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
        internal int CleanRoom(int numOfCommands, Coordinates initialVortex, List<Tuple<string, int>> commands)
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
                for (int i = 1; i <= command.Item2; i++)
                {
                    if (command.Item1 == "E")
                    {
                        var newVortex = new Coordinates(currentVortex.X + i, currentVortex.Y);
                        visitedVertices.Add(newVortex);
                    }
                }
            }

            return visitedVertices.Count;
        }
    }
}
