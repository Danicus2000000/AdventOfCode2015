/*Seeing how reindeer move in bursts, Santa decides he's not pleased with the old scoring system.

Instead, at the end of each second, he awards one point to the reindeer currently in the lead. (If there are multiple reindeer tied for the lead, they each get one point.) He keeps the traditional 2503 second time limit, of course, as doing otherwise would be entirely ridiculous.

Given the example reindeer from above, after the first second, Dancer is in the lead and gets one point. He stays in the lead until several seconds into Comet's second burst: after the 140th second, Comet pulls into the lead and gets his first point. Of course, since Dancer had been in the lead for the 139 seconds before that, he has accumulated 139 points by the 140th second.

After the 1000th second, Dancer has accumulated 689 points, while poor Comet, our old champion, only has 312. So, with the new scoring system, Dancer would win (if the race ended at 1000 seconds).

Again given the descriptions of each reindeer (in your puzzle input), after exactly 2503 seconds, how many points does the winning reindeer have?*/
using System.Diagnostics;

namespace Day14
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int winningPoints = 2503;

            string[] input = puzzleData.Split("\r\n");

            var reindeer = input.Select(line =>
            {
                string[] parts = line.Split(' ');
                return new
                {
                    Name = parts[0],
                    Speed = int.Parse(parts[3]),
                    Time = int.Parse(parts[6]),
                    Rest = int.Parse(parts[13])
                };
            }).ToArray();

            int maxDistance = 0;
            int[] scores = new int[reindeer.Length];
            for (int t = 1; t <= winningPoints; t++)
            {
                int[] distances = new int[reindeer.Length];
                for (int i = 0; i < reindeer.Length; i++)
                {
                    int fullCycles = t / (reindeer[i].Time + reindeer[i].Rest);
                    int remainingTime = t % (reindeer[i].Time + reindeer[i].Rest);
                    int traveled = fullCycles * reindeer[i].Speed * reindeer[i].Time;
                    if (remainingTime > reindeer[i].Time)
                    {
                        traveled += reindeer[i].Speed * reindeer[i].Time;
                    }
                    else
                    {
                        traveled += reindeer[i].Speed * remainingTime;
                    }
                    distances[i] = traveled;
                    maxDistance = Math.Max(maxDistance, traveled);
                }

                for (int i = 0; i < reindeer.Length; i++)
                {
                    if (distances[i] == maxDistance)
                    {
                        scores[i]++;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("The winning reindeer has {0} points. Calculated in {1} ms",scores.Max(),watch.ElapsedMilliseconds);
        }
    }
}
