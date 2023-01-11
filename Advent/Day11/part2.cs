/*Santa's password expired again. What's the next one?*/
using System.Diagnostics;

namespace Day11
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string password = puzzleData;
            do//uses do while to skip fact password is passed in from part1 and is therefore already valid
            {
                password = part1.IncrementPassword(password);
            } while (!part1.IsValidPassword(password));
            watch.Stop();
            Console.WriteLine("New New password is: " + password + " completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
