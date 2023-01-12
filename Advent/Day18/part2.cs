/*You flip the instructions over; Santa goes on to point out that this is all just an implementation of Conway's Game of Life. At least, it was, until you notice that something's wrong with the grid of lights you bought: four lights, one in each corner, are stuck on and can't be turned off. The example above will actually run like this:

Initial state:
##.#.#
...##.
#....#
..#...
#.#..#
####.#

After 1 step:
#.##.#
####.#
...##.
......
#...#.
#.####

After 2 steps:
#..#.#
#....#
.#.##.
...##.
.#..##
##.###

After 3 steps:
#...##
####.#
..##.#
......
##....
####.#

After 4 steps:
#.####
#....#
...#..
.##...
#.....
#.#..#

After 5 steps:
##.###
.##..#
.##...
.##...
#.#...
##...#
After 5 steps, this example now has 17 lights on.

In your grid of 100x100 lights, given your initial configuration, but with the four corners always in the on state, how many lights are on after 100 steps?*/
using System.Diagnostics;
namespace Day18
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] input = puzzleData.Split("\r\n");
            int size = input[0].Length;
            int steps = 100;
            bool[,] grid = new bool[size, size];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = input[i][j] == '#';
                }
            }
            for (int i = 0; i < steps; i++)
            {
                bool[,] newGrid = new bool[size, size];
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        int onCount = 0;
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                if (dx == 0 && dy == 0)
                                    continue;
                                int nx = x + dx;
                                int ny = y + dy;
                                if (nx >= 0 && ny >= 0 && nx < size && ny < size && grid[nx, ny])
                                    onCount++;
                            }
                        }
                        if (grid[x, y])
                        {
                            newGrid[x, y] = onCount == 2 || onCount == 3;
                        }
                        else
                        {
                            newGrid[x, y] = onCount == 3;
                        }
                    }
                }
                newGrid[0, 0] = true;//added to complete part 2
                newGrid[0, size - 1] = true;
                newGrid[size - 1, 0] = true;
                newGrid[size - 1, size - 1] = true;
                grid = newGrid;
            }
            int count = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (grid[x, y])
                        count++;
                }
            }
            watch.Stop();
            Console.WriteLine("There will be {0} lights on after 100 steps. Completed in {1}ms", count, watch.ElapsedMilliseconds);
        }
    }
}
