/*The Elves decide they don't want to visit an infinite number of houses. Instead, each Elf will stop after delivering presents to 50 houses. To make up for it, they decide to deliver presents equal to eleven times their number at each house.

With these changes, what is the new lowest house number of the house to get at least as many presents as the number in your puzzle input?*/
using System.Diagnostics;
namespace Day20
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int presents=int.Parse(puzzleData);
            int min = int.MaxValue;
            int[] houses = new int[200000000];
            for (int i = 1; i < int.MaxValue; ++i)
            {
                for (int j = i, c = 0; c < 50 && j < houses.Length && j < min; j = unchecked(j + i), ++c)
                {
                    if ((houses[j] += i * 11) >= presents)
                    {
                        min = Math.Min(min, j);
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("The lowest house number that has {1} presents with the new rules is {0}. Completed in {2}ms", min, presents, watch.ElapsedMilliseconds);

        }
    }
}
