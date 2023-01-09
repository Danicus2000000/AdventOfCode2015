/*Santa is delivering presents to an infinite two-dimensional grid of houses.

He begins by delivering a present to the house at his starting location, and then an elf at the North Pole calls him via radio and tells him where to move next. Moves are always exactly one house to the north (^), south (v), east (>), or west (<). After each move, he delivers another present to the house at his new location.

However, the elf back at the north pole has had a little too much eggnog, and so his directions are a little off, and Santa ends up visiting some houses more than once. How many houses receive at least one present?

For example:

> delivers presents to 2 houses: one at the starting location, and one to the east.
^>v< delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.*/
using System.Diagnostics;
namespace Day3
{
    internal static class part1
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            List<List<int>> grid=new List<List<int>>();
            for (int i = 0; i < 9999; i++) //populate large grid
            {
                grid.Add(new List<int>());
                for (int j = 0; j < 9999; j++) 
                {
                    grid[i].Add(0);
                }
            }
            grid[4444][4444]++;
            char[] instructions = puzzleData.ToCharArray();
            int posX = 4444;
            int posY=4444;
            foreach (char instruction in instructions) //drop presents at each destination
            {
                switch(instruction) 
                {
                    case '<':
                        posX--;
                        break;
                    case '>':
                        posX++;
                        break;
                    case '^':
                        posY++;
                        break;
                    case 'v':
                        posY--;
                        break;

                }
                grid[posY][posX]++;
            }
            int totalHousesWithOnePresent = 0;
            for(int i=0;i<grid.Count;i++) 
            {
                for(int j = 0; j < grid[i].Count;j++) 
                {
                    if (grid[i][j] >= 1) 
                    {
                        totalHousesWithOnePresent++;
                    }
                }
            }
            watch.Stop(); 
            Console.WriteLine(totalHousesWithOnePresent + " have gifts Completed in "+watch.ElapsedMilliseconds+"ms");
        }
    }
}
