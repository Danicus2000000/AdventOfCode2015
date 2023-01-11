/*Santa's previous password expired, and he needs help choosing a new one.

To help him remember his new password after the old one expires, Santa has devised a method of coming up with a password based on the previous one. Corporate policy dictates that passwords must be exactly eight lowercase letters (for security reasons), so he finds his new password by incrementing his old password string repeatedly until it is valid.

Incrementing is just like counting with numbers: xx, xy, xz, ya, yb, and so on. Increase the rightmost letter one step; if it was z, it wraps around to a, and repeat with the next letter to the left until one doesn't wrap around.

Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:

Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz. They cannot skip letters; abd doesn't count.
Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
For example:

hijklmmn meets the first requirement (because it contains the straight hij) but fails the second requirement requirement (because it contains i and l).
abbceffg meets the third requirement (because it repeats bb and ff) but fails the first requirement.
abbcegjk fails the third requirement, because it only has one double letter (bb).
The next password after abcdefgh is abcdffaa.
The next password after ghijklmn is ghjaabcc, because you eventually skip all the passwords that start with ghi..., since i is not allowed.
Given Santa's current password (your puzzle input), what should his next password be?*/
using System.Diagnostics;

namespace Day11
{
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string password = puzzleData;
            while (!IsValidPassword(password))
            {
                password = IncrementPassword(password);
            }
            watch.Stop();
            Console.WriteLine("New password is: " + password+" completed in "+watch.ElapsedMilliseconds+"ms");
            part2.solve(password);//starts part 2
        }
        internal static bool IsValidPassword(string password)
        {
            bool hasStraight = false;
            bool hasInvalidChars = false;
            bool hasPairs = false;
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] - 1 && password[i] == password[i + 2] - 2)
                {
                    hasStraight = true;
                }
            }
            hasInvalidChars = password.Any(c => "iol".Contains(c));
            int pairCount = 0;
            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                {
                    pairCount++;
                    i++;
                }
            }
            hasPairs = pairCount >= 2;
            return hasStraight && !hasInvalidChars && hasPairs;
        }

        internal static string IncrementPassword(string password)
        {
            char[] chars = password.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                if (chars[i] != 'z')
                {
                    chars[i]++;
                    break;
                }
                else
                {
                    chars[i] = 'a';
                }
            }
            return new string(chars);
        }
    }
}
