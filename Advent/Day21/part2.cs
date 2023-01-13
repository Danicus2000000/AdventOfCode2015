/*Turns out the shopkeeper is working with the boss, and can persuade you to buy whatever items he wants. The other rules still apply, and he still only has one of each item.

What is the most amount of gold you can spend and still lose the fight?*/
using System.Diagnostics;
using static Day21.part1;

namespace Day21
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Player> losses = new List<Player>();
            for (int i = 0; i < weapons.Length; i++)
            {
                for (int j = -1; j < armor.Length; j++)
                {
                    for (int k = -1; k < rings.Length; k++)
                    {
                        for (int l = -1; l <= k; l++)
                        {
                            if (k >= 0 && k == l) 
                            {
                                continue; 
                            }
                            Player boss = new Player(100) { Damage = 8, Armor = 2 };
                            Player player = new Player(100);
                            player.Equip(weapons[i]);
                            if (j >= 0) { player.Equip(armor[j]); }
                            if (k >= 0) { player.Equip(rings[k]); }
                            if (l >= 0) { player.Equip(rings[l]); }

                            if (Shots(player, boss) < Shots(boss, player))
                            {
                                losses.Add(player);
                            }
                        }
                    }
                }
            }
            Player maxLoser = losses.OrderBy(p => p.Spent).Last();
            watch.Stop();
            Console.WriteLine("Max loser: " + maxLoser.Spent + " (" + String.Join(", ", maxLoser.Arsenal.Select(i => i.Name)) + ")");
            Console.WriteLine("Completed in: " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
