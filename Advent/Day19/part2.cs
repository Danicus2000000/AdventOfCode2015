/*Now that the machine is calibrated, you're ready to begin molecule fabrication.

Molecule fabrication always begins with just a single electron, e, and applying replacements one at a time, just like the ones during calibration.

For example, suppose you have the following replacements:

e => H
e => O
H => HO
H => OH
O => HH
If you'd like to make HOH, you start with e, and then make the following replacements:

e => O to get O
O => HH to get HH
H => OH (on the second H) to get HOH
So, you could make HOH after 3 steps. Santa's favorite molecule, HOHOHO, can be made in 6 steps.

How long will it take to make the medicine? Given the available replacements and the medicine molecule in your puzzle input, what is the fewest number of steps to go from e to the medicine molecule?*/
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Day19
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] lines = puzzleData.Split("\r\n");
            string targetMolecule = lines.Last();
            IEnumerable<string> replacements = lines.Take(lines.Length - 2);
            string initialMolecule = "e";
            int steps = 0;
            string currentMolecule = targetMolecule;
            string target = initialMolecule;
            while (currentMolecule != target)
            {
                HashSet<string> newMolecules = new HashSet<string>();
                foreach (string replacement in replacements)
                {
                    MatchCollection match = Regex.Matches(currentMolecule, replacement.Split(" => ")[1]);
                    for (int i = 0; i < match.Count; i++)
                    {
                        string newMolecule = currentMolecule.Remove(match[i].Index, match[i].Length).Insert(match[i].Index, replacement.Split(" => ")[0]);
                        newMolecules.Add(newMolecule);
                    }
                }
                steps++;
                if (newMolecules.Contains(target))
                {
                    currentMolecule = target;
                }
                else
                {
                    currentMolecule = newMolecules.First();
                }
            }
            watch.Stop();
            Console.WriteLine("The minimum number of steps to create the cure is {0} steps. Complted in {1}ms",steps,watch.ElapsedMilliseconds);
        }
    }
}
