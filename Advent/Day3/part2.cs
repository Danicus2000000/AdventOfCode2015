/*The next year, to speed up the process, Santa creates a robot version of himself, Robo-Santa, to deliver presents with him.

Santa and Robo-Santa start at the same location (delivering two presents to the same starting house), then take turns moving based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.

This year, how many houses receive at least one present?

For example:

^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
^>v< now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.*/
using System.Diagnostics;
namespace Day3
{
    internal static class part2
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            List<List<int>> grid = new List<List<int>>();
            for (int i = 0; i < 9999; i++) //populate large grid
            {
                grid.Add(new List<int>());
                for (int j = 0; j < 9999; j++)
                {
                    grid[i].Add(0);
                }
            }
            grid[4444][4444]+=2;
            char[] instructions = puzzleData.ToCharArray();
            int santaPosX = 4444;
            int santaPosY = 4444;
            int roboPosX = 4444;
            int roboPosY = 4444;
            int instruct = 0;
            foreach (char instruction in instructions) //drop presents at each destination
            {
                if (instruct == 0 || instruct % 2 == 0)
                {
                    switch (instruction)
                    {
                        case '<':
                            santaPosX--;
                            break;
                        case '>':
                            santaPosX++;
                            break;
                        case '^':
                            santaPosY++;
                            break;
                        case 'v':
                            santaPosY--;
                            break;

                    }
                    grid[santaPosY][santaPosX]++;
                }
                else 
                {
                    switch (instruction)
                    {
                        case '<':
                            roboPosX--;
                            break;
                        case '>':
                            roboPosX++;
                            break;
                        case '^':
                            roboPosY++;
                            break;
                        case 'v':
                            roboPosY--;
                            break;

                    }
                    grid[roboPosY][roboPosX]++;
                }
                instruct++;
            }
            int totalHousesWithOnePresent = 0;
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] >= 1)
                    {
                        totalHousesWithOnePresent++;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine(totalHousesWithOnePresent + " have gifts Calculated in "+watch.ElapsedMilliseconds+"ms");
        }
    }
}
