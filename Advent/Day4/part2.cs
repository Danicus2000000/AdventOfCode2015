/*Now find one that starts with six zeroes.*/
using System.Diagnostics;
using System.Security.Cryptography;

namespace Day4
{
    internal static class part2
    {
        internal static void solve(string puzzleData) 
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string hex = "";
            int num = 0;
            while (!hex.StartsWith("000000"))
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(puzzleData + num.ToString());
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    hex = Convert.ToHexString(hashBytes);
                }
                if (hex.StartsWith("000 000"))
                {
                    break;
                }
                num++;
            }
            watch.Stop();
            Console.WriteLine("number required to get start with 6 0's in md5 hash is " + num + " completed in " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
