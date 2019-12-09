using System;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //DayOne();
            //DayTwoA();
            //DayTwoB();
            //DayThreeA();
            DayFour();
        }
        private static void DayFour()
        {
            var day4 = new Day4.Day4Solver();
            Console.WriteLine($"Day 4 part A result = {day4.StepA()}");
            Console.WriteLine($"Day 4 part B result = {day4.StepB()}");
            var x = day4.CheckAdjecentSameDigitsMax2(new int[] { 1,1,1,1,2,2 });
        }
        private static void DayThreeA()
        {
            var day3 = new Day3.Day3Solver();
            Console.WriteLine($"Day 3 part A result = {day3.StepA()}");
            Console.WriteLine($"Day 3 part B result = {day3.StepB()}");
        }
  
        private static void DayTwoB()
        {
            var result = 19690720;
          
            int noun, verb;

            for (noun = 0; noun < 100; noun++)
            {
                for (verb = 0; verb < 100; verb++)
                {
                    var mem = new Data().Codes;
                    mem[1] = 12 + noun;
                    mem[2] = 2 + verb;
                    RunOpCode(mem);
                    if (mem[0] == result)
                        Console.WriteLine($"Noun: {mem[1]} & Verb: {mem[2]} return value {(100 * mem[1]) + mem[2]}");
                }
            }

            Console.WriteLine("done");
        }

        private static void DayTwoA()
        {
            var codes = new Data().Codes;
            codes[1] = 12;
            codes[2] = 2;
            RunOpCode(codes);
            Console.WriteLine(codes[0]);
        }

        private static void RunOpCode(int[] codes)
        {
            int i = 0;
            do
            {
                i = RunOpcode(codes, i);

            } while (codes[i] != 99);
        }

        private static int RunOpcode(int[] codes, int i)
        {
            var opcode = codes[i];
            var inputOne = codes[codes[i + 1]];
            var inputTwo = codes[codes[i + 2]];
            var pos = codes[i + 3];
            int result = 0;
            result = CalculateOp(opcode, inputOne, inputTwo);

            codes[pos] = result;
            return i + 4;
        }

        private static int CalculateOp(int opcode, int inputOne, int inputTwo)
        {
            int result;
            if (opcode == 1)
            {
                result = inputOne + inputTwo;
            }
            else if (opcode == 2)
            {
                result = inputOne * inputTwo;
            }
            else
            {
                throw new Exception("Opcode should be one or two");
            }

            return result;
        }


        private static void DayOne()
        {
            var fuel = 0m;
            foreach (var item in Fuel)
            {
                var i = item;
                do
                {
                    var f = CalculateFuel(i);
                    fuel += f;
                    i = f;

                } while (i > 0);

            }
            Console.WriteLine(fuel);
        }

        private static decimal CalculateFuel(decimal item)
        {
            var d = Math.Floor(item / 3) - 2;
            if (d > 0)
            {
                return d;
            }
            return 0m;
        }

        private static decimal[] Fuel = new decimal[] {
        142536,
103450,
101545,
133505,
112476,
62461,
108718,
93376,
149609,
147657,
120888,
85008,
82501,
122988,
109493,
91656,
70001,
130308,
140298,
104623,
103542,
129220,
67381,
143889,
105384,
139467,
129004,
89271,
123863,
108567,
95453,
109698,
139953,
107458,
69734,
106036,
126036,
84832,
68715,
51484,
92833,
50734,
58267,
109650,
137004,
77709,
95073,
84817,
55711,
95408,
148990,
51697,
129180,
56196,
72692,
77049,
124294,
85102,
124400,
75981,
135842,
119561,
79871,
98771,
134213,
141322,
131828,
65692,
113994,
104632,
129273,
118023,
54700,
148185,
61618,
132304,
88308,
121386,
119548,
115527,
76627,
63168,
137582,
113598,
100899,
100167,
134345,
90716,
55476,
113403,
52745,
78755,
73421,
93337,
71171,
122979,
134298,
123117,
111244,
122177

        };
    }
}
