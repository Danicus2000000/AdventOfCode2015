/*Because your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.

Furthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.

Lights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs. Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square. The lights all start turned off.

To defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.

For example:

turn on 0,0 through 999,999 would turn on (or leave on) every light.
toggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.
turn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.
After following the instructions, how many lights are lit?*/
using System.Diagnostics;

namespace Day6
{
    internal static class part1
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            bool[,] lights = new bool[1000, 1000];
            string[] instructions = puzzleData.Split("\r\n");
            foreach(string instruction in instructions) 
            {
                string[] instructionParts= instruction.Split(" ");
                string toDo = instructionParts[0];
                int posXFrom = 0;
                int posYFrom = 0;
                int posXTo = 0;
                int posYTo = 0;
                if (toDo == "turn")
                {
                    toDo = instructionParts[1];
                    posXFrom = int.Parse(instructionParts[2].Split(",")[0]);
                    posYFrom = int.Parse(instructionParts[2].Split(",")[1]);
                    posXTo = int.Parse(instructionParts[4].Split(",")[0]);
                    posYTo = int.Parse(instructionParts[4].Split(",")[1]);
                }
                else 
                {
                    posXFrom = int.Parse(instructionParts[1].Split(",")[0]);
                    posYFrom = int.Parse(instructionParts[1].Split(",")[1]);
                    posXTo = int.Parse(instructionParts[3].Split(",")[0]);
                    posYTo = int.Parse(instructionParts[3].Split(",")[1]);
                }
                for(int y=posYFrom; y<=posYTo; y++) 
                {
                    for(int x=posXFrom; x<=posXTo; x++) 
                    {
                        switch (toDo) 
                        {
                            case "toggle":
                                lights[y, x] =!lights[y,x];
                                break;
                            case "on":
                                lights[y, x] = true;
                                break;
                            case "off":
                                lights[y, x] = false;
                                break;

                        }
                    }
                }
            }
            int on = 0;
            for (int i = 0; i < lights.GetLength(0); i++)
            {
                for (int j = 0; j < lights.GetLength(1); j++)
                {
                    if (lights[i, j])
                    {
                        on++;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine(on + " lights are on. Completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
