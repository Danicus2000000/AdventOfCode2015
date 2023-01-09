/*Today, the Elves are playing a game called look-and-say. They take turns making sequences by reading aloud the previous sequence and using that reading as the next sequence. For example, 211 is read as "one two, two ones", which becomes 1221 (1 2, 2 1s).

Look-and-say sequences are generated iteratively, using the previous value as input for the next step. For each step, take the previous value, and replace each run of digits (like 111) with the number of digits (3) followed by the digit itself (1).

For example:

1 becomes 11 (1 copy of digit 1).
11 becomes 21 (2 copies of digit 1).
21 becomes 1211 (one 2 followed by one 1).
1211 becomes 111221 (one 1, one 2, and two 1s).
111221 becomes 312211 (three 1s, two 2s, and one 1).
Starting with the digits in your puzzle input, apply this process 40 times. What is the length of the result?*/
using System.Diagnostics;
using System.Text;

namespace Day10
{
    internal static class part1
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            string toCalc = puzzleData;
            for (int i = 0; i < 40; i++) //run 40 times
            {
                toCalc=look(toCalc);  //runs look and say algorithm
            }
            watch.Stop();
            Console.WriteLine("String length after 40 itterations: "+toCalc.Length+" in "+watch.ElapsedMilliseconds+"ms");
        }
        internal static string look(string num)
        {
            StringBuilder result = new StringBuilder();
            char repeat = num[0];
            num = num.Substring(1, num.Length - 1) + " ";
            int goes = 1;
            foreach (char actual in num)
            {
                if (actual != repeat)
                {
                    result.Append(Convert.ToString(goes) + repeat);
                    goes = 1;
                    repeat = actual;
                }
                else
                {
                    goes += 1;
                }
            }
            return result.ToString();
        }
    }
}
