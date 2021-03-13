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
            Tuple<int, int> initialPosition = new Tuple<int, int>((int)input[1], (int)input[2]);
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

    class RobotCleaner
    {
        internal int CleanRoom(int numOfCommands, Tuple<int, int> initialVortex, List<Tuple<string, int>> commands)
        {
            var visitedVertices = new HashSet<Tuple<int, int>>();
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
                        var newVortex = new Tuple<int, int>(currentVortex.Item1 + i, currentVortex.Item2);
                        visitedVertices.Add(newVortex);
                    }
                }
            }

            return visitedVertices.Count;
        }
    }
}
