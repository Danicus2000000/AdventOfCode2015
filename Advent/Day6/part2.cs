/*You just finish implementing your winning light pattern when you realize you mistranslated Santa's message from Ancient Nordic Elvish.

The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more. The lights all start at zero.

The phrase turn on actually means that you should increase the brightness of those lights by 1.

The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.

The phrase toggle actually means that you should increase the brightness of those lights by 2.

What is the total brightness of all lights combined after following Santa's instructions?

For example:

turn on 0,0 through 0,0 would increase the total brightness by 1.
toggle 0,0 through 999,999 would increase the total brightness by 2000000.*/
using System.Diagnostics;

namespace Day6
{
    internal static class part2
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int[,] lights = new int[1000, 1000];
            string[] instructions = puzzleData.Split("\r\n");
            foreach (string instruction in instructions)
            {
                string[] instructionParts = instruction.Split(" ");
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
                for (int y = posYFrom; y <= posYTo; y++)
                {
                    for (int x = posXFrom; x <= posXTo; x++)
                    {
                        switch (toDo)
                        {
                            case "toggle":
                                lights[y, x]+=2;
                                break;
                            case "on":
                                lights[y, x] ++;
                                break;
                            case "off":
                                if (lights[y, x] != 0)
                                {
                                    lights[y, x]--;
                                }
                                break;

                        }
                    }
                }
            }
            int totalBrightness = 0;
            for (int i = 0; i < lights.GetLength(0); i++)
            {
                for (int j = 0; j < lights.GetLength(1); j++)
                {
                    totalBrightness += lights[i, j];
                }
            }
            watch.Stop();
            Console.WriteLine("The lights have a total brightness of " + totalBrightness + ". completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
