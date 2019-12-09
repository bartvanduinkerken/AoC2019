using AoC2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019.Day4
{
    public class Day4Solver : ISolver<int>
    {
        private const int StartRange = 240298;
        private const int EndRange = 784956;
        public int StepA()
        {
            int result = 0;
            //It is a six - digit number.
            //The value is within the range given in your puzzle input.
            //Two adjacent digits are the same(like 22 in 122345).
            //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).

            for (int i = StartRange; i < EndRange + 1; i++)
            {
                var a = GetIntArray(i);
                if (CheckAdjecentSameDigits(a) && CheckDigitsNeverDecrease(a))
                    result++;
            }
            return result;
        }

        private bool CheckAdjecentSameDigits(int[] resultArray)
        {
            var valid = false;
            int prev = 0;
            foreach (var n in resultArray)
            {
                if (prev == n)
                {
                    valid = true;
                }
               
                prev = n;
            }
            return valid;
        }

        private bool CheckDigitsNeverDecrease(int[] resultArray)
        {
            var valid = true;
            int prev = 0;
            foreach (var n in resultArray)
            {
                if (prev > n)
                    valid = false;
                prev = n;
            }
            return valid;
        }
        private static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
        public int StepB()
        {
            //It is a six - digit number.
            //The value is within the range given in your puzzle input.
            //Two adjacent digits are the same(like 22 in 122345).
            //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
            //An Elf just remembered one more important detail: the two adjacent matching digits are not part of a larger group of matching digits.

            //112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
            //123444 no longer meets the criteria(the repeated 44 is part of a larger group of 444).
            //111122 meets the criteria(even though 1 is repeated more than twice, it still contains a double 22).
            var result = 0;
            for (int i = StartRange; i < EndRange + 1; i++)
            {
                var a = GetIntArray(i);
                if (CheckAdjecentSameDigitsMax2(a) && CheckDigitsNeverDecrease(a))
                    result++;
            }
            return result;
        }

        public bool CheckAdjecentSameDigitsMax2(int[] resultArray)
        {
            var valid = false;
            int prev = 0;
            var list = new List<Adjacent>();
            var item = new Adjacent();
            foreach (var n in resultArray)
            {
                if (prev == n)
                {
                    item.Count++;
                    valid = true;
                }
                else
                {
                    if (item.Count > 1)
                        list.Add(item);
                    item = new Adjacent();
                }
                prev = n;
            }
            if (item.Count > 1)
                list.Add(item); 
            return valid && list.Count() > 0 && list.Any(c => c.Count == 2);
        }

        private class Adjacent
        {
            public int Count { get; set; } = 1;
        }
    }
}
