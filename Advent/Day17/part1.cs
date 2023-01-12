/*The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. You take an inventory of the capacities of the available containers.

For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters. If you need to store 25 liters, there are four ways to do it:

15 and 10
20 and 5 (the first 5)
20 and 5 (the second 5)
15, 5, and 5
Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?*/
using System.Diagnostics;
namespace Day17
{
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int target = 150;
            int count = 0;
            List<int> containers = new List<int>();
            foreach (string line in puzzleData.Split("\r\n"))
            {
                containers.Add(int.Parse(line));
            }

            for (int i = 1; i <= Math.Pow(2, containers.Count); i++)
            {
                List<int> chosen = new List<int>();
                for (int j = 0; j < containers.Count; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        chosen.Add(containers[j]);
                    }
                }
                if (chosen.Sum(c => c) == target)
                {
                    count++;
                }
            }
            watch.Stop();
            Console.WriteLine("The number of ways to store the 150 liters is {0}. Calculated in {1}ms",count,watch.ElapsedMilliseconds);
        }
    }
}
