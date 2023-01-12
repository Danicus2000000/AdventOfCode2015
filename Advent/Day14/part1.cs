/*This year is the Reindeer Olympics! Reindeer can fly at high speeds, but must rest occasionally to recover their energy. Santa would like to know which of his reindeer is fastest, and so he has them race.

Reindeer can only either be flying (always at their top speed) or resting (not moving at all), and always spend whole seconds in either state.

For example, suppose you have the following Reindeer:

Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
After one second, Comet has gone 14 km, while Dancer has gone 16 km. After ten seconds, Comet has gone 140 km, while Dancer has gone 160 km. On the eleventh second, Comet begins resting (staying at 140 km), and Dancer continues on for a total distance of 176 km. On the 12th second, both reindeer are resting. They continue to rest until the 138th second, when Comet flies for another ten seconds. On the 174th second, Dancer flies for another 11 seconds.

In this example, after the 1000th second, both reindeer are resting, and Comet is in the lead at 1120 km (poor Dancer has only gotten 1056 km by that point). So, in this situation, Comet would win (if the race ended at 1000 seconds).

Given the descriptions of each reindeer (in your puzzle input), after exactly 2503 seconds, what distance has the winning reindeer traveled?*/
using System.Diagnostics;

namespace Day14
{
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] inputLines = puzzleData.Split("\r\n");
            List<Reindeer> reindeer = new List<Reindeer>();
            //parse input 
            foreach (string line in inputLines)
            {
                string[] s = line.Split(" ");
                reindeer.Add(new Reindeer(s[0], int.Parse(s[3]), int.Parse(s[6]), int.Parse(s[13])));
            }

            int raceTime = 2503;
            int maxDistance = 0;

            // find distance traveled for each reindeer
            foreach (var r in reindeer)
            {
                int distance = 0;
                int time = 0;
                while (time < raceTime)
                {
                    int flyDistance = r.speed * Math.Min(r.flyTime, raceTime - time);
                    distance += flyDistance;
                    time += r.flyTime;
                    time += r.restTime;
                }
                maxDistance = Math.Max(maxDistance, distance);
            }
            watch.Stop();
            Console.WriteLine("The winning reindeer traveled a distance of {0} km. Calculated in {1} ms", maxDistance,watch.ElapsedMilliseconds);
        }
    }
    internal class Reindeer
    {
        public string name;
        public int speed;
        public int flyTime;
        public int restTime;

        public Reindeer(string name, int speed, int flyTime, int restTime)
        {
            this.name = name;
            this.speed = speed;
            this.flyTime = flyTime;
            this.restTime = restTime;
        }
    }
}
