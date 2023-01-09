/*Every year, Santa manages to deliver all of his presents in a single night.

This year, however, he has some new locations to visit; his elves have provided him the distances between every pair of locations. He can start and end at any two (different) locations he wants, but he must visit each location exactly once. What is the shortest distance he can travel to achieve this?

For example, given the following distances:

London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141
The possible routes are therefore:

Dublin -> London -> Belfast = 982
London -> Dublin -> Belfast = 605
London -> Belfast -> Dublin = 659
Dublin -> Belfast -> London = 659
Belfast -> Dublin -> London = 605
Belfast -> London -> Dublin = 982
The shortest of these is London -> Dublin -> Belfast = 605, and so the answer is 605 in this example.

What is the distance of the shortest route?

 Part 2: The next year, just to show off, Santa decides to take the route with the longest distance instead.

He can still start and end at any two (different) locations he wants, and he still must visit each location exactly once.

For example, given the distances above, the longest route would be 982 via (for example) Dublin -> London -> Belfast.

What is the distance of the longest route?*/
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day9
{
    internal static class solution
    {
        static List<List<string>> permutations = new List<List<string>>();
        static List<(string from,string to ,int cost)> paths=new List<(string, string, int)>();
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] input = puzzleData.Split("\r\n");
            foreach (string path in input)
            {
                string[] pathData = Regex.Split(path, "(to)|(=)");
                paths.Add((pathData[0].Trim(), pathData[2].Trim(), Convert.ToInt32(pathData[4])));
            }
            List<string> onlyToLoc = paths.Where(p => !paths.Any(p1 => p1.from == p.to)).GroupBy(p => p.to).Select(g => g.Key).ToList();
            foreach ((string from,string to ,int cost) in paths.Where(p => onlyToLoc.Contains(p.to)).ToList())
            {
                if (!paths.Any(p => p.from == to && p.to == from))
                {
                    paths.Add((to,from,cost));
                }
            }
            List<string> locations = paths.GroupBy(p => p.from).Select(g => g.Key).Union(paths.GroupBy(p => p.to).Select(g => g.Key)).ToList();
            permutations = GetPermutations(locations);
            var posibleRoutes = new Dictionary<string, int>();
            foreach (List<string> permutation in permutations)
            {
                int pathDistance = 0;
                for (int i = 0; i < permutation.Count() - 1; i++)
                {
                    if (paths.Any(p => p.from == permutation[i] && p.to == permutation[i + 1]))
                        pathDistance += paths.First(p => p.from == permutation[i] && p.to == permutation[i + 1]).cost;
                    else if (paths.Any(p => p.to == permutation[i] && p.from == permutation[i + 1]))
                        pathDistance += paths.First(p => p.to == permutation[i] && p.from== permutation[i + 1]).cost;
                    else
                    {
                        i = 10;
                        pathDistance = 0;
                    }
                }
                if (pathDistance > 0)
                    posibleRoutes.Add(String.Join(" -> ", permutation), pathDistance);
            }
            watch.Stop();
            Console.WriteLine("Shortest route: "+posibleRoutes.OrderBy(d => d.Value).First().Value);
            Console.WriteLine("longest route: "+posibleRoutes.OrderByDescending(d => d.Value).First().Value);
            Console.WriteLine("Elapssed time: " + watch.ElapsedMilliseconds + "ms");
        }
        private static void PopulatePosition<T>(List<List<T>> finalList, List<T> list, List<T> temp, int position)
        {
            foreach (T element in list)
            {
                List<T> currentTemp = temp.ToList();
                if (!currentTemp.Contains(element))
                    currentTemp.Add(element);
                else
                    continue;

                if (position == list.Count)
                    finalList.Add(currentTemp);
                else
                    PopulatePosition(finalList, list, currentTemp, position + 1);
            }
        }

        private static List<List<T>> GetPermutations<T>(List<T> list)
        {
            List<List<T>> results = new List<List<T>>();
            PopulatePosition(results, list, new List<T>(), 1);
            return results;
        }
    }
}
