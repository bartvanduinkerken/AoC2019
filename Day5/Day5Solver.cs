using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019.Day5
{
    public class Day5Solver : ISolver<long>
    {
        public long StepA()
        {
            var codes = new Data().Day5Codes;
            return new IntCodeMachine(codes).Run(1).Last();
        }

        public long StepB()
        {
            var codes = new Data().Day5Codes;
            return new IntCodeMachine(codes).Run(5).Last();
        }

    }
}
