/*Little Henry Case got a new video game for Christmas. It's an RPG, and he's stuck on a boss. He needs to know what equipment to buy at the shop. He hands you the controller.

In this game, the player (you) and the enemy (the boss) take turns attacking. The player always goes first. Each attack reduces the opponent's hit points by at least 1. The first character at or below 0 hit points loses.

Damage dealt by an attacker each turn is equal to the attacker's damage score minus the defender's armor score. An attacker always does at least 1 damage. So, if the attacker has a damage score of 8, and the defender has an armor score of 3, the defender loses 5 hit points. If the defender had an armor score of 300, the defender would still lose 1 hit point.

Your damage score and armor score both start at zero. They can be increased by buying items in exchange for gold. You start with no items and have as much gold as you need. Your total damage or armor is equal to the sum of those stats from all of your items. You have 100 hit points.

Here is what the item shop is selling:

Weapons:    Cost  Damage  Armor
Dagger        8     4       0
Shortsword   10     5       0
Warhammer    25     6       0
Longsword    40     7       0
Greataxe     74     8       0

Armor:      Cost  Damage  Armor
Leather      13     0       1
Chainmail    31     0       2
Splintmail   53     0       3
Bandedmail   75     0       4
Platemail   102     0       5

Rings:      Cost  Damage  Armor
Damage +1    25     1       0
Damage +2    50     2       0
Damage +3   100     3       0
Defense +1   20     0       1
Defense +2   40     0       2
Defense +3   80     0       3
You must buy exactly one weapon; no dual-wielding. Armor is optional, but you can't use more than one. You can buy 0-2 rings (at most one for each hand). You must use any items you buy. The shop only has one of each item, so you can't buy, for example, two rings of Damage +3.

For example, suppose you have 8 hit points, 5 damage, and 5 armor, and that the boss has 12 hit points, 7 damage, and 2 armor:

The player deals 5-2 = 3 damage; the boss goes down to 9 hit points.
The boss deals 7-5 = 2 damage; the player goes down to 6 hit points.
The player deals 5-2 = 3 damage; the boss goes down to 6 hit points.
The boss deals 7-5 = 2 damage; the player goes down to 4 hit points.
The player deals 5-2 = 3 damage; the boss goes down to 3 hit points.
The boss deals 7-5 = 2 damage; the player goes down to 2 hit points.
The player deals 5-2 = 3 damage; the boss goes down to 0 hit points.
In this scenario, the player wins! (Barely.)

You have 100 hit points. The boss's actual stats are in your puzzle input. What is the least amount of gold you can spend and still win the fight?*/
using System.Diagnostics;

namespace Day21
{
    internal static class part1
    {
        internal static Item[] weapons = new Item[]
{
                new Item("Dagger", 8, 4, 0),
                new Item("Shortsword", 10, 5, 0),
                new Item("Warhammer", 25, 6, 0),
                new Item("Longsword", 40, 7, 0),
                new Item("Greataxe", 74, 8, 0)
};

        internal static Item[] armor = new Item[]
        {
                new Item("Leather", 13, 0, 1),
                new Item("Chainmail", 31, 0, 2),
                new Item("Splintmail", 53, 0, 3),
                new Item("Bandedmail", 75, 0, 4),
                new Item("Platemail", 102, 0, 5)
        };

        internal static Item[] rings = new Item[]
        {
                new Item("Damage +1", 25, 1, 0),
                new Item("Damage +2", 50, 2, 0),
                new Item("Damage +3", 100, 3, 0),
                new Item("Defense +1", 20, 0, 1),
                new Item("Defense +2", 40, 0, 2),
                new Item("Defense +3", 80, 0, 3)
        };
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Player> wins = new List<Player>();

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

                            if (Shots(player, boss) >= Shots(boss, player))
                            {
                                wins.Add(player);
                            }
                        }
                    }
                }
            }

            Player minWinner = wins.OrderBy(p => p.Spent).First();
            watch.Stop();
            Console.WriteLine("Min winner: " + minWinner.Spent + " (" + String.Join(", ", minWinner.Arsenal.Select(i => i.Name)) + ")");
            Console.WriteLine("Completed in: " + watch.ElapsedMilliseconds+"ms");
        }
        internal static int Shots(Player a, Player b)
        {
            int shotDamage = Math.Max(b.Damage - a.Armor, 1);
            int shots = a.HitPoints / shotDamage;
            int rem = a.HitPoints % shotDamage;
            return shots + (rem > 0 ? 1 : 0);
        }

        internal class Player
        {
            internal int HitPoints;
            internal int Damage;
            internal int Armor;
            internal int Spent;
            internal List<Item> Arsenal;

            internal Player(int hitPoints)
            {
                HitPoints = hitPoints;
                Arsenal = new List<Item>();
            }

            internal void Equip(Item item)
            {
                Damage += item.Damage;
                Armor += item.Armor;
                Spent += item.Cost;
                Arsenal.Add(item);
            }
        }

        internal class Item
        {
            internal string Name { get; }
            internal int Cost { get; }
            internal int Damage { get; }
            internal int Armor { get; }

            internal Item(string name, int cost, int damage, int armor)
            {
                Name = name;
                Cost = cost;
                Damage = damage;
                Armor = armor;
            }
        }
    }
}
