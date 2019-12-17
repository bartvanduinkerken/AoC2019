using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019.Day2
{
    public class Day2Solver : ISolver<int>
    {
        public int StepA()
        {
            var codes = new Data().Codes;
            codes[1] = 12;
            codes[2] = 2;
            RunOpCode(codes);
            return codes[0];
        }

        public int StepB()
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
                        return (100 * mem[1]) + mem[2];
                }
            }
            throw new Exception("Op code invalid");
        }
        #region Intcode
        public static void RunOpCode(int[] codes)
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
            else if (opcode == 3)
            {
                //Opcode 3 takes a single integer as input and saves it to the position given by its only parameter. 
                //For example, the instruction 3,50 would take an input value and store it at address 50.
                throw new NotImplementedException();
            }
            else if (opcode == 4)
            {
                //Opcode 4 outputs the value of its only parameter. 
                //For example, the instruction 4,50 would output the value at address 50.
                throw new NotImplementedException();
            }
            else
            {
                throw new Exception("Opcode should be one or two");
            }

            return result;
        }
        #endregion

    }
}
