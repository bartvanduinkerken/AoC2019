using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public static class Helpers
    {
        public static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
}
