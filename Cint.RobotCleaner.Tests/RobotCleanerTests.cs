using System;
using System.Collections.Generic;
using Xunit;

namespace Cint.RobotCleaner.Tests
{
    public class RobotCleanerTests
    {
        [Fact]
        public void CleanRoomTests(int numOfCommands, Tuple<int,int> initialPosition, List<Tuple<string, int>> commands)
        {
            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
        }
    }
}
