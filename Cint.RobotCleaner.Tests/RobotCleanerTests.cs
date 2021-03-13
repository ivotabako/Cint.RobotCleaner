using System;
using System.Collections.Generic;
using Xunit;

namespace Cint.RobotCleaner.Tests
{
    public class RobotCleanerTests
    {
        [Theory]     
        //[MemberData(nameof(Data))]
        [InlineData(0, null, null, 0)]
        //[InlineData(0, new Tuple<int, int>(0, 0), null, 1)]
        public void CleanRoomTests(int numOfCommands, Coordinate initialPosition, List<Tuple<string, int>> commands, int expectedNumOfPlaces)
        {
            var robot = new RobotCleaner();
            int numOfPlaces = robot.CleanRoom(numOfCommands, initialPosition, commands);
            Assert.Equal(expectedNumOfPlaces, numOfPlaces);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 0, null, null, 0 },
            new object[] { 0, new Tuple<int,int>(0,0), null, 1 },
        };
    }

    [Serializable]
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }

    public class RobotCleaner
    {
        internal int CleanRoom(int numOfCommands, Coordinate initialPosition, List<Tuple<string, int>> commands)
        {
            return 0;
        }
    }
}
