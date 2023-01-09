/*Now, starting again with the digits in your puzzle input, apply this process 50 times. What is the length of the new result?*/
using System.Diagnostics;
using System.Text;

namespace Day10
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string toCalc = puzzleData;
            for (int i = 0; i < 50; i++) //run 40 times
            {
                toCalc = part1.look(toCalc);  //runs look and say algorithm
            }
            watch.Stop();
            Console.WriteLine("String length after 50 itterations: " + toCalc.Length + " in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
