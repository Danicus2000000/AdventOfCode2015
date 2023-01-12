/*As you're about to send the thank you note, something in the MFCSAM's instructions catches your eye. Apparently, it has an outdated retroencabulator, and so the output from the machine isn't exact values - some of them indicate ranges.

In particular, the cats and trees readings indicates that there are greater than that many (due to the unpredictable nuclear decay of cat dander and tree pollen), while the pomeranians and goldfish readings indicate that there are fewer than that many (due to the modial interaction of magnetoreluctance).

What is the number of the real Aunt Sue?*/
using System.Diagnostics;
namespace Day16
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] input = puzzleData.ToLower().Split("\r\n");

            Aunt[] aunts = new Aunt[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                string[] parts = input[i].Split(' ');
                aunts[i] = new Aunt(int.Parse(parts[1].Replace(":", "")));
                for (int j = 0; j < parts.Length - 1; j++)
                {
                    switch (parts[j])
                    {
                        case "children:":
                            aunts[i].Children = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "cats:":
                            aunts[i].Cats = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "samoyeds:":
                            aunts[i].Samoyeds = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "pomeranians:":
                            aunts[i].Pomeranians = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "akitas:":
                            aunts[i].Akitas = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "vizslas:":
                            aunts[i].Vizslas = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "goldfish:":
                            aunts[i].Goldfish = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "trees:":
                            aunts[i].Trees = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "cars:":
                            aunts[i].Cars = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                        case "perfumes:":
                            aunts[i].Perfumes = int.Parse(parts[j + 1].Replace(",", ""));
                            break;
                    }
                }
            }
            Aunt sue = new Aunt(-1)
            {
                Children = 3,
                Cats = 7,
                Samoyeds = 2,
                Pomeranians = 3,
                Akitas = 0,
                Vizslas = 0,
                Goldfish = 5,
                Trees = 3,
                Cars = 2,
                Perfumes = 1
            };
            for (int i = 0; i < aunts.Length; i++)
            {
                if (aunts[i].Children != -1 && aunts[i].Children != sue.Children)
                {
                    continue;
                }
                if (aunts[i].Cats != -1 && aunts[i].Cats <= sue.Cats)
                {
                    continue;
                }
                if (aunts[i].Samoyeds != -1 && aunts[i].Samoyeds != sue.Samoyeds)
                {
                    continue;
                }
                if (aunts[i].Pomeranians != -1 && aunts[i].Pomeranians >= sue.Pomeranians)
                {
                    continue;
                }
                if (aunts[i].Akitas != -1 && aunts[i].Akitas != sue.Akitas)
                {
                    continue;
                }
                if (aunts[i].Vizslas != -1 && aunts[i].Vizslas != sue.Vizslas)
                {
                    continue;
                }
                if (aunts[i].Goldfish != -1 && aunts[i].Goldfish >= sue.Goldfish)
                {
                    continue;
                }
                if (aunts[i].Trees != -1 && aunts[i].Trees <= sue.Trees)
                {
                    continue;
                }
                if (aunts[i].Cars != -1 && aunts[i].Cars != sue.Cars)
                {
                    continue;
                }
                if (aunts[i].Perfumes != -1 && aunts[i].Perfumes != sue.Perfumes)
                {
                    continue;
                }
                watch.Stop();
                Console.WriteLine("Real Aunt sue has been found! She is number {0}. Completed in {1} ms", aunts[i].Number, watch.ElapsedMilliseconds);
                break;
            }
        }
    }
}
