/*To keep the Elves busy, Santa has them deliver some presents by hand, door-to-door. He sends them down a street with infinite houses numbered sequentially: 1, 2, 3, 4, 5, and so on.

Each Elf is assigned a number, too, and delivers presents to houses based on that number:

The first Elf (number 1) delivers presents to every house: 1, 2, 3, 4, 5, ....
The second Elf (number 2) delivers presents to every second house: 2, 4, 6, 8, 10, ....
Elf number 3 delivers presents to every third house: 3, 6, 9, 12, 15, ....
There are infinitely many Elves, numbered starting with 1. Each Elf delivers presents equal to ten times his or her number at each house.

So, the first nine houses on the street end up like this:

House 1 got 10 presents.
House 2 got 30 presents.
House 3 got 40 presents.
House 4 got 70 presents.
House 5 got 60 presents.
House 6 got 120 presents.
House 7 got 80 presents.
House 8 got 150 presents.
House 9 got 130 presents.
The first house gets 10 presents: it is visited only by Elf 1, which delivers 1 * 10 = 10 presents. The fourth house gets 70 presents, because it is visited by Elves 1, 2, and 4, for a total of 10 + 20 + 40 = 70 presents.

What is the lowest house number of the house to get at least as many presents as the number in your puzzle input?*/
using System.Diagnostics;
namespace Day20
{
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int target = int.Parse(puzzleData);
            int n = 1;
            while (true)
            {
                int presents = 0;
                int sqrt = (int)Math.Sqrt(n);
                for (int i = 1; i <= sqrt; i++)
                {
                    if (n % i == 0)
                    {
                        presents += i * 10;
                        if (i * i != n)
                        {
                            presents += (n / i) * 10;
                        }
                    }
                }
                if (presents >= target)
                {
                    watch.Stop();
                    Console.WriteLine("The lowest house number that has {1} presents is {0}. Completed in {2}ms",n,target,watch.ElapsedMilliseconds);
                    break;
                }
                n++;
            }
        }
    }
}
