/*Santa needs help figuring out which strings in his text file are naughty or nice.

A nice string is one with all of the following properties:

It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
For example:

ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), and none of the disallowed substrings.
aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
jchzalrnumimnmhp is naughty because it has no double letter.
haegwjzuvuyypxyu is naughty because it contains the string xy.
dvszwmarrgswjxmb is naughty because it contains only one vowel.
How many strings are nice?*/
using System.Diagnostics;

namespace Day5
{
    internal static class part1
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            string[] strings = puzzleData.ToLower().Split("\r\n");
            int nice = 0;
            int naughty = 0;
            foreach (string stringToCheck in strings) 
            {
                bool containsThreeVowles = false;
                bool containsTwiceInRow = false;
                bool containsNoNaughtyStrings = false;
                if (!stringToCheck.Contains("ab") && !stringToCheck.Contains("cd") && !stringToCheck.Contains("pq") && !stringToCheck.Contains("xy"))
                {
                    containsNoNaughtyStrings = true;
                }
                int vowles = 0;
                for(int i=0;i<stringToCheck.Length;i++) 
                {
                    if (i != stringToCheck.Length - 1)
                    {
                        if (stringToCheck[i] == stringToCheck[i + 1])
                        {
                            containsTwiceInRow = true;
                        }
                    }
                    if (stringToCheck[i] == 'a' || stringToCheck[i] == 'e' || stringToCheck[i] == 'i' || stringToCheck[i] == 'o' || stringToCheck[i] == 'u') 
                    {
                        vowles++;
                    }
                    if (vowles == 3) 
                    {
                        containsThreeVowles = true;
                    }
                    if (containsThreeVowles && containsTwiceInRow) 
                    {
                        break;
                    }
                }
                if (containsThreeVowles && containsTwiceInRow && containsNoNaughtyStrings)
                {
                    nice++;
                }
                else 
                {
                    naughty++;
                }
            }
            watch.Stop();
            Console.WriteLine(nice + " strings are nice and " + naughty + " strings are naughty. Completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
