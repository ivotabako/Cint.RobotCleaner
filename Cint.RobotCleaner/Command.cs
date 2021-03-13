﻿namespace Cint.RobotCleaner
{
    public class Command
    {
        public Command(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
        public string Direction { get; }
        public int Steps { get; }
    }
}
