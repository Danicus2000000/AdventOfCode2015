/*The unknown benefactor is very thankful for releasi-- er, helping little Jane Marie with her computer. Definitely not to distract you, what is the value in register b after the program is finished executing if register a starts as 1 instead?*/
using System.Diagnostics;

namespace Day23
{
    internal static class part2
    {
        static int[] registers = new int[2];
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            registers[0] = 1;
            string[] input = puzzleData.Split("\r\n");
            int instructionPointer = 0;
            while (instructionPointer < input.Length)
            {
                string[] instruction = input[instructionPointer].Split(' ');
                switch (instruction[0])
                {
                    case "hlf":
                        registers[instruction[1][0] - 'a'] /= 2;
                        instructionPointer++;
                        break;
                    case "tpl":
                        registers[instruction[1][0] - 'a'] *= 3;
                        instructionPointer++;
                        break;
                    case "inc":
                        registers[instruction[1][0] - 'a']++;
                        instructionPointer++;
                        break;
                    case "jmp":
                        instructionPointer += int.Parse(instruction[1]);
                        break;
                    case "jie":
                        if (registers[instruction[1][0] - 'a'] % 2 == 0)
                        {
                            instructionPointer += int.Parse(instruction[2]);
                        }
                        else
                        {
                            instructionPointer++;
                        }
                        break;
                    case "jio":
                        if (registers[instruction[1][0] - 'a'] == 1)
                        {
                            instructionPointer += int.Parse(instruction[2]);
                        }
                        else
                        {
                            instructionPointer++;
                        }
                        break;
                }
            }
            watch.Stop();
            Console.WriteLine("The value in register b on completion (when a starts as 1) is {0}. Completed in {1}ms", registers[1], watch.ElapsedMilliseconds);
            watch.Stop();
        }
    }
}
