/*Santa needs help mining some AdventCoins (very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.

To do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes. The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: 1, 2, 3, ...) that produces such a hash.

For example:

If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.
If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....*/
using System.Diagnostics;
using System.Security.Cryptography;

namespace Day4
{
    internal static class part1
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            string hex = "";
            int num = 0;
            while (!hex.StartsWith("00000")) 
            {
                using (MD5 md5 =MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(puzzleData+num.ToString());
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    hex=Convert.ToHexString(hashBytes); 
                }
                if (hex.StartsWith("00000"))
                {
                    break;
                }
                num++;
            }
            watch.Stop();
            Console.WriteLine("number required to get start with 5 0's in md5 hash is " + num+" completed in "+watch.ElapsedMilliseconds+"ms");
        }
    }
}
