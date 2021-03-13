using System;
using System.Collections.Generic;
using Xunit;

namespace Cint.RobotCleaner.Tests
{
    public class RobotCleanerTests
    {
        [Theory]
        [InlineData(1, null, null, 0)]
        public void CleanRoomTests(int numOfCommands, Tuple<int,int> initialPosition, List<Tuple<string, int>> commands, int expectedNumOfPlaces)
        {
            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
            Assert.Equal(expectedNumOfPlaces, numOfPlaces);
        }
    }

    class RobotCleaner
    {
        internal int CleanRoom(int numOfCommands, Tuple<int, int> initialPosition, List<Tuple<string, int>> commands)
        {
            return 0;
        }
    }
}
