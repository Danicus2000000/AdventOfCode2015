/*Little Henry Case decides that defeating bosses with swords and stuff is boring. Now he's playing the game with a wizard. Of course, he gets stuck on another boss and needs your help again.

In this version, combat still proceeds with the player and the boss taking alternating turns. The player still goes first. Now, however, you don't get any equipment; instead, you must choose one of your spells to cast. The first character at or below 0 hit points loses.

Since you're a wizard, you don't get to wear armor, and you can't attack normally. However, since you do magic damage, your opponent's armor is ignored, and so the boss effectively has zero armor as well. As before, if armor (from a spell, in this case) would reduce damage below 1, it becomes 1 instead - that is, the boss' attacks always deal at least 1 damage.

On each of your turns, you must select one of your spells to cast. If you cannot afford to cast any spell, you lose. Spells cost mana; you start with 500 mana, but have no maximum limit. You must have enough mana to cast a spell, and its cost is immediately deducted when you cast it. Your spells are Magic Missile, Drain, Shield, Poison, and Recharge.

Magic Missile costs 53 mana. It instantly does 4 damage.
Drain costs 73 mana. It instantly does 2 damage and heals you for 2 hit points.
Shield costs 113 mana. It starts an effect that lasts for 6 turns. While it is active, your armor is increased by 7.
Poison costs 173 mana. It starts an effect that lasts for 6 turns. At the start of each turn while it is active, it deals the boss 3 damage.
Recharge costs 229 mana. It starts an effect that lasts for 5 turns. At the start of each turn while it is active, it gives you 101 new mana.
Effects all work the same way. Effects apply at the start of both the player's turns and the boss' turns. Effects are created with a timer (the number of turns they last); at the start of each turn, after they apply any effect they have, their timer is decreased by one. If this decreases the timer to zero, the effect ends. You cannot cast a spell that would start an effect which is already active. However, effects can be started on the same turn they end.

For example, suppose the player has 10 hit points and 250 mana, and that the boss has 13 hit points and 8 damage:

-- Player turn --
- Player has 10 hit points, 0 armor, 250 mana
- Boss has 13 hit points
Player casts Poison.

-- Boss turn --
- Player has 10 hit points, 0 armor, 77 mana
- Boss has 13 hit points
Poison deals 3 damage; its timer is now 5.
Boss attacks for 8 damage.

-- Player turn --
- Player has 2 hit points, 0 armor, 77 mana
- Boss has 10 hit points
Poison deals 3 damage; its timer is now 4.
Player casts Magic Missile, dealing 4 damage.

-- Boss turn --
- Player has 2 hit points, 0 armor, 24 mana
- Boss has 3 hit points
Poison deals 3 damage. This kills the boss, and the player wins.
Now, suppose the same initial conditions, except that the boss has 14 hit points instead:

-- Player turn --
- Player has 10 hit points, 0 armor, 250 mana
- Boss has 14 hit points
Player casts Recharge.

-- Boss turn --
- Player has 10 hit points, 0 armor, 21 mana
- Boss has 14 hit points
Recharge provides 101 mana; its timer is now 4.
Boss attacks for 8 damage!

-- Player turn --
- Player has 2 hit points, 0 armor, 122 mana
- Boss has 14 hit points
Recharge provides 101 mana; its timer is now 3.
Player casts Shield, increasing armor by 7.

-- Boss turn --
- Player has 2 hit points, 7 armor, 110 mana
- Boss has 14 hit points
Shield's timer is now 5.
Recharge provides 101 mana; its timer is now 2.
Boss attacks for 8 - 7 = 1 damage!

-- Player turn --
- Player has 1 hit point, 7 armor, 211 mana
- Boss has 14 hit points
Shield's timer is now 4.
Recharge provides 101 mana; its timer is now 1.
Player casts Drain, dealing 2 damage, and healing 2 hit points.

-- Boss turn --
- Player has 3 hit points, 7 armor, 239 mana
- Boss has 12 hit points
Shield's timer is now 3.
Recharge provides 101 mana; its timer is now 0.
Recharge wears off.
Boss attacks for 8 - 7 = 1 damage!

-- Player turn --
- Player has 2 hit points, 7 armor, 340 mana
- Boss has 12 hit points
Shield's timer is now 2.
Player casts Poison.

-- Boss turn --
- Player has 2 hit points, 7 armor, 167 mana
- Boss has 12 hit points
Shield's timer is now 1.
Poison deals 3 damage; its timer is now 5.
Boss attacks for 8 - 7 = 1 damage!

-- Player turn --
- Player has 1 hit point, 7 armor, 167 mana
- Boss has 9 hit points
Shield's timer is now 0.
Shield wears off, decreasing armor by 7.
Poison deals 3 damage; its timer is now 4.
Player casts Magic Missile, dealing 4 damage.

-- Boss turn --
- Player has 1 hit point, 0 armor, 114 mana
- Boss has 2 hit points
Poison deals 3 damage. This kills the boss, and the player wins.
You start with 50 hit points and 500 mana points. The boss's actual stats are in your puzzle input. What is the least amount of mana you can spend and still win the fight? (Do not include mana recharge effects as "spending" negative mana.)*/
using System.Diagnostics;

namespace Day22
{
    internal static class part1
    {
        static int playerHP = 50;
        static int bossHP = 58;
        static int bossDamage = 9;
        static int turns = 20;
        static int minMana = int.MaxValue;
        static HashSet<string> visitedStates = new HashSet<string>();
        static Queue<GameState> queue = new Queue<GameState>();
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            queue.Enqueue(new GameState(playerHP, 500, bossHP, 0, 0, 0, 0, turns));
            while (queue.Count > 0)
            {
                GameState current = queue.Dequeue();

                if (visitedStates.Contains(current.ToString()))
                {
                    continue;
                }
                visitedStates.Add(current.ToString());

                if (current.bossHP <= 0)
                {
                    minMana = current.playerMana;
                    break;
                }
                if (current.playerHP <= 0 || current.remainingTurns <= 0)
                {
                    continue;
                }
                // Magic Missile
                if (current.playerMana >= 53)
                {
                    queue.Enqueue(new GameState(current.playerHP, current.playerMana - 53, current.bossHP - 4, current.playerArmor, current.shieldTimer, current.poisonTimer, current.rechargeTimer, current.remainingTurns - 1));
                }

                // Drain
                if (current.playerMana >= 73)
                {
                    queue.Enqueue(new GameState(current.playerHP + 2, current.playerMana - 73, current.bossHP - 2, current.playerArmor, current.shieldTimer, current.poisonTimer, current.rechargeTimer, current.remainingTurns - 1));
                }

                // Shield
                if (current.playerMana >= 113 && current.shieldTimer <= 0)
                {
                    queue.Enqueue(new GameState(current.playerHP, current.playerMana - 113, current.bossHP, current.playerArmor + 7, 6, current.poisonTimer, current.rechargeTimer, current.remainingTurns - 1));
                }

                // Poison
                if (current.playerMana >= 173 && current.poisonTimer <= 0)
                {
                    queue.Enqueue(new GameState(current.playerHP, current.playerMana - 173, current.bossHP - 3, current.playerArmor, current.shieldTimer, 6, current.rechargeTimer, current.remainingTurns - 1));
                }

                // Recharge
                if (current.playerMana >= 229 && current.rechargeTimer <= 0)
                {
                    queue.Enqueue(new GameState(current.playerHP, current.playerMana - 229, current.bossHP, current.playerArmor, current.shieldTimer, current.poisonTimer, 5, current.remainingTurns - 1));
                }

                // Boss' turn
                int damage = bossDamage - current.playerArmor;
                if (damage < 1)
                {
                    damage = 1;
                }

                queue.Enqueue(new GameState(current.playerHP - damage, current.playerMana, current.bossHP, current.playerArmor, current.shieldTimer > 0 ? current.shieldTimer - 1 : 0, current.poisonTimer > 0 ? current.poisonTimer - 1 : 0, current.rechargeTimer > 0 ? current.rechargeTimer - 1 : 0, current.remainingTurns - 1));
            }
            watch.Stop();
            if (minMana != int.MaxValue)
            {
                Console.WriteLine("The minimum mana spent to win is {0}. Completed in {1}ms", minMana, watch.ElapsedMilliseconds);
            }
            else
            {
                Console.WriteLine("Player can't win!");
            }
        }
        class GameState
        {
            public int playerHP;
            public int playerMana;
            public int bossHP;
            public int playerArmor;
            public int shieldTimer;
            public int poisonTimer;
            public int rechargeTimer;
            public int remainingTurns;
            public GameState(int playerHP, int playerMana, int bossHP, int playerArmor, int shieldTimer, int poisonTimer, int rechargeTimer, int remainingTurns)
            {
                this.playerHP = playerHP;
                this.playerMana = playerMana;
                this.bossHP = bossHP;
                this.playerArmor = playerArmor;
                this.shieldTimer = shieldTimer;
                this.poisonTimer = poisonTimer;
                this.rechargeTimer = rechargeTimer;
                this.remainingTurns = remainingTurns;
            }
            public override string ToString()
            {
                return $"{playerHP},{playerMana},{bossHP},{playerArmor},{shieldTimer},{poisonTimer},{rechargeTimer},{remainingTurns}";
            }
        }
    }
}
