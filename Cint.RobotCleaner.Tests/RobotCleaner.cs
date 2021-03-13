using System;
using System.Collections.Generic;
using System.Linq;

namespace Cint.RobotCleaner.Tests
{
    class RobotCleaner
    {
        internal int CleanRoom(int numOfCommands, Coordinates initialVortex, List<Command> commands)
        {
            var newVortexCalculator = new Dictionary<string, Func<Coordinates, int, Coordinates>>()
            {
                { "E", ( c, s)=> new Coordinates(c.X + s, c.Y ) },
                { "S", ( c, s)=> new Coordinates(c.X, c.Y - s ) },
                { "W", ( c, s)=> new Coordinates(c.X - s, c.Y ) },
                { "N", ( c, s)=> new Coordinates(c.X, c.Y + s) }
            };

            var visitedVertices = new List<Coordinates>();
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
                    visitedVertices.Add(newVortexCalculator[command.Direction](currentVortex, i));
                }

                currentVortex = visitedVertices[^1];
            }

            return visitedVertices.GroupBy(c => new { c.X, c.Y }).Select(g => g.First()).Count();
        }
    }
}
