/*In all the commotion, you realize that you forgot to seat yourself. At this point, you're pretty apathetic toward the whole thing, and your happiness wouldn't really go up or down regardless of who you sit next to. You assume everyone else would be just as ambivalent about sitting next to you, too.

So, add yourself to the list, and give all happiness relationships that involve you a score of 0.

What is the total change in happiness for the optimal seating arrangement that actually includes yourself?*/
using System.Diagnostics;
using System.Xml.Linq;

namespace Day13
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] inputLines = puzzleData.Split("\r\n");
            Dictionary<string, Dictionary<string, int>> happiness = new Dictionary<string, Dictionary<string, int>>();
            HashSet<string> names = new HashSet<string>();
            foreach (var line in inputLines)
            {
                string[] tokens = line.Split(' ');
                string name1 = tokens[0];
                string name2 = tokens[10].TrimEnd('.');
                int happinessChange = int.Parse(tokens[3]) * (tokens[2] == "gain" ? 1 : -1);
                names.Add(name1);
                if (!happiness.ContainsKey(name1))
                {
                    happiness[name1] = new Dictionary<string, int>();
                }
                happiness[name1][name2] = happinessChange;
            }

            //Add myself
            string me = "Me";
            names.Add(me);
            happiness[me] = new Dictionary<string, int>();
            foreach (string name in names)
            {
                if (!happiness.ContainsKey(name))
                {
                    happiness[name] = new Dictionary<string, int>();
                }
                happiness[name][me] = 0;
                happiness[me][name] = 0;
            }
            // Get permutations of names
            string[] namesToSolve = happiness.Keys.ToArray();
            IEnumerable<string[]> permutations = part1.GetPermutations(namesToSolve);

            // Find maximum happiness
            int maxHappiness = int.MinValue;
            foreach (string[] permutation in permutations)
            {
                int permutationHappiness = 0;
                for (int i = 0; i < permutation.Length; i++)
                {
                    string name1 = permutation[i];
                    string name2 = permutation[(i + 1) % permutation.Length];
                    permutationHappiness += happiness[name1][name2];
                    permutationHappiness += happiness[name2][name1];
                }
                maxHappiness = Math.Max(maxHappiness, permutationHappiness);
            }
            watch.Stop();
            Console.WriteLine("The max happiness is: " + maxHappiness + " completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
