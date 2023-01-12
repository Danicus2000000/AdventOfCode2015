/*After the million lights incident, the fire code has gotten stricter: now, at most ten thousand lights are allowed. You arrange them in a 100x100 grid.

Never one to let you down, Santa again mails you instructions on the ideal lighting configuration. With so few lights, he says, you'll have to resort to animation.

Start by setting your lights to the included initial configuration (your puzzle input). A # means "on", and a . means "off".

Then, animate your grid in steps, where each step decides the next configuration based on the current one. Each light's next state (either on or off) depends on its current state and the current states of the eight lights adjacent to it (including diagonals). Lights on the edge of the grid might have fewer than eight neighbors; the missing ones always count as "off".

For example, in a simplified 6x6 grid, the light marked A has the neighbors numbered 1 through 8, and the light marked B, which is on an edge, only has the neighbors marked 1 through 5:

1B5...
234...
......
..123.
..8A4.
..765.
The state a light should have next is based on its current state (on or off) plus the number of neighbors that are on:

A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
All of the lights update simultaneously; they all consider the same current state before moving to the next.

Here's a few steps from an example configuration of another 6x6 grid:

Initial state:
.#.#.#
...##.
#....#
..#...
#.#..#
####..

After 1 step:
..##..
..##.#
...##.
......
#.....
#.##..

After 2 steps:
..###.
......
..###.
......
.#....
.#....

After 3 steps:
...#..
......
...#..
..##..
......
......

After 4 steps:
......
......
..##..
..##..
......
......
After 4 steps, this example has four lights on.

In your grid of 100x100 lights, given your initial configuration, how many lights are on after 100 steps?*/
using System.Diagnostics;
namespace Day18
{
    internal static class part1
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
            Console.WriteLine("There will be {0} lights on after 100 steps. Completed in {1}ms",count,watch.ElapsedMilliseconds);
        }
    }
}
