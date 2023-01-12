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
        public class Reindeer
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public int FlyTime { get; set; }
            public int RestTime { get; set; }
            public int Points { get; set; } // added property to hold the points
            public int Distance { get; set; }
            public int Remaining { get; set; }
            public int totalTime { get; set; }
            public int state { get; set; }
            public int FlyCycle { get; set; }
        }
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Reindeer[] reindeer = new Reindeer[] {
            new Reindeer { Name = "Comet", Speed = 14, FlyTime = 10, RestTime = 127 },
            new Reindeer { Name = "Dancer", Speed = 16, FlyTime = 11, RestTime = 162 }
        };

            int raceTime = 2503;

            // simulate the race
            for (int i = 1; i <= raceTime; i++)
            {
                // update the distance and state for each reindeer
                foreach (var r in reindeer)
                {
                    if (r.state < r.FlyTime)
                    {
                        r.Distance += r.Speed;
                        r.state++;
                    }
                    else if (r.state == r.FlyTime + r.RestTime)
                    {
                        r.state = 0;
                        r.FlyCycle++;
                    }
                    else
                    {
                        r.state++;
                    }
                    if (r.FlyCycle > 0)
                    {
                        r.Points += r.FlyCycle;
                    }
                }
                var max = reindeer.OrderByDescending(x => x.Distance).First();
                max.Points++;
            }
            int maxPoints = reindeer.Max(r => r.Points);
            watch.Stop();
            Console.WriteLine("The winning reindeer has {0} points.", maxPoints);
        }
    }
}
