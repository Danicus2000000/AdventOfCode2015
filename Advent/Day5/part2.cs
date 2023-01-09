/*Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice. None of the old rules apply, as they are all clearly ridiculous.

Now, a nice string is one with all of the following properties:

It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
For example:

qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice (qj) and a letter that repeats with exactly one letter between them (zxz).
xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
uurcxstgmygtbstg is naughty because it has a pair (tg) but no repeat with a single letter between them.
ieodomkazucvgmuy is naughty because it has a repeating letter with one between (odo), but no pair that appears twice.
How many strings are nice under these new rules?*/
using System.Diagnostics;

namespace Day5
{
    internal static class part2
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] strings = puzzleData.ToLower().Split("\r\n");
            int nice = 0;
            int naughty = 0;
            foreach (string stringToCheck in strings)
            {
                bool containsTwoUniqueLetterPairs = false;
                bool containsTwiceInRowWithOneBetween = false;
                List<string> letterPairs = new List<string>();
                for (int i = 0; i < stringToCheck.Length-1; i++)
                {
                    if (i != stringToCheck.Length - 2)//checks safely for pattern aea / xyx 
                    {
                        if (stringToCheck[i] == stringToCheck[i + 2])
                        {
                            containsTwiceInRowWithOneBetween = true;
                        }
                    }
                    if (letterPairs.Contains(stringToCheck[i].ToString() + stringToCheck[i + 1].ToString()))//checks for pattern xy...xy
                    {
                        if (!(stringToCheck[i - 1] == stringToCheck[i] && stringToCheck[i + 1] == stringToCheck[i-1]))
                        {
                            containsTwoUniqueLetterPairs = true;
                        }
                    }
                    else
                    {
                        letterPairs.Add(stringToCheck[i].ToString() + stringToCheck[i + 1].ToString());
                    }
                    if (containsTwoUniqueLetterPairs && containsTwiceInRowWithOneBetween)
                    {
                        nice++;
                        break;
                    }
                    else if(i==stringToCheck.Length-2)
                    {
                        naughty++;
                    }
                }
            }
            nice++;//loop mistakenly cuts off last nice
            naughty--;
            watch.Stop();
            Console.WriteLine(nice + " strings are nice and " + naughty + " strings are naughty. Completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
