using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2019.Day3
{
    public class Day3Solver : ISolver<int>
    {
        public int StepA()
        {
            var data = new Data();

            var wireOnePath = GetPath(data.WireOne);
            var wireTwoPath = GetPath(data.WireTwo);

            (int x, int y)[] intersectionPoints = wireOnePath.Intersect(wireTwoPath).ToArray();
            int closest = intersectionPoints.Min(p => Math.Abs(p.x) + Math.Abs(p.y));
            return closest;
        }

        private List<(int x, int y)> GetPath(IEnumerable<KeyValuePair<string, int>> wire)
        {
            var path = new List<(int x, int y)>();
            int currentX = 0;
            int currentY = 0;
            foreach (var step in wire)
            {
                for (int i = 0; i < step.Value; i++)
                {
                    switch (step.Key)
                    {
                        case "U": currentY++; break;
                        case "D": currentY--; break;
                        case "L": currentX--; break;
                        case "R": currentX++; break;
                    }
                    path.Add((currentX, currentY));
                }
            }

            return path;
        }

        public int StepB()
        {
            var data = new Data();

            var wireOnePath = GetPath(data.WireOne);
            var wireTwoPath = GetPath(data.WireTwo);
            (int x, int y)[] intersectionPoints = wireOnePath.Intersect(wireTwoPath).ToArray();
            int steps = int.MaxValue;

            foreach (var intersection in intersectionPoints)
            {
                int iStep = CalculateSteps(data.WireOne, data.WireTwo, intersection);
                if (iStep < steps)
                    steps = iStep;
            }

            return steps;
        }

        private int CalculateSteps(IEnumerable<KeyValuePair<string, int>> wireOnePath, IEnumerable<KeyValuePair<string, int>> wireTwoPath, (int x, int y) intersection)
        {
            int stepsPathOne = CalculateSteps(wireOnePath, intersection);
            int stepsPathTwo = CalculateSteps(wireTwoPath, intersection);

            return stepsPathOne + stepsPathTwo;

        }

        private int CalculateSteps(IEnumerable<KeyValuePair<string, int>> wirePath, (int x, int y) intersection)
        {
            int steps = 0;
            int currentX = 0;
            int currentY = 0;

            foreach (var step in wirePath)
            {
                for (int i = 0; i < step.Value; i++)
                {
                    steps++;
                    switch (step.Key)
                    {
                        case "U": currentY++; break;
                        case "D": currentY--; break;
                        case "L": currentX--; break;
                        case "R": currentX++; break;
                    }

                    if (intersection.x == currentX && intersection.y == currentY)
                        return steps;
                }

            }

            throw new Exception("Should never come here");
        }
    }
}
