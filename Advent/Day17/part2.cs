/*While playing with all the containers in the kitchen, another load of eggnog arrives! The shipping and receiving department is requesting as many containers as you can spare.

Find the minimum number of containers that can exactly fit all 150 liters of eggnog. How many different ways can you fill that number of containers and still hold exactly 150 litres?

In the example above, the minimum number of containers was two. There were three ways to use that many containers, and so the answer there would be 3.*/
using System.Diagnostics;
namespace Day17
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int target = 150;
            int count = 0;
            int minContainer = int.MaxValue;
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
                if(chosen.Sum(c => c) == target && chosen.Count()<minContainer) 
                {
                    count = 0;
                    minContainer = chosen.Count();
                }
                if (chosen.Sum(c => c) == target && minContainer==chosen.Count())
                {
                    count++;
                }
            }
            watch.Stop();
            Console.WriteLine("The minimum number of containers to store 150 liters is {0},The number of ways to store the 150 liters that way is {1}. Calculated in {2}ms",minContainer, count, watch.ElapsedMilliseconds);
        }
    }
}
