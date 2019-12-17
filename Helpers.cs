using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public static class Helpers
    {
        #region Manhatten Distance
        public static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
        #endregion

        public static int[] ToArray(this int num, bool reverse = true)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            if (!reverse)//because of above list is atomatically reverse
                listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        public static int ToNewDigit(this int[] values, int start, int length)
        {
            var result = 0;
            var s = values.ToList(); 
            s.Reverse();
            //1,2,3,4,5 start is position from right, start 0 = 5, start 1 = 4
            //using length: start 0 and length 1 =5; start 1 length 2=34 
            for (int i = start; i < values.Length && length > 0; i++)
            {
                result *= 10;
                result += s[i];
                length--;
            }
            return result.Reverse();
        }

        public static int Reverse(this int number)
        {
            int reverse = 0;
            while (number > 0)
            {
                int remainder = number % 10;
                reverse = (reverse * 10) + remainder;
                number = number / 10;
            }
            return reverse;
        }
    }
}
