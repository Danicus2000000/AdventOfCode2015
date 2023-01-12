/*Today, you set out on the task of perfecting your milk-dunking cookie recipe. All you have to do is find the right balance of ingredients.

Your recipe leaves room for exactly 100 teaspoons of ingredients. You make a list of the remaining ingredients you could use to finish the recipe (your puzzle input) and their properties per teaspoon:

capacity (how well it helps the cookie absorb milk)
durability (how well it keeps the cookie intact when full of milk)
flavor (how tasty it makes the cookie)
texture (how it improves the feel of the cookie)
calories (how many calories it adds to the cookie)
You can only measure ingredients in whole-teaspoon amounts accurately, and you have to be accurate so you can reproduce your results in the future. The total score of a cookie can be found by adding up each of the properties (negative totals become 0) and then multiplying together everything except calories.

For instance, suppose you have these two ingredients:

Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
Then, choosing to use 44 teaspoons of butterscotch and 56 teaspoons of cinnamon (because the amounts of each ingredient must add up to 100) would result in a cookie with the following properties:

A capacity of 44*-1 + 56*2 = 68
A durability of 44*-2 + 56*3 = 80
A flavor of 44*6 + 56*-2 = 152
A texture of 44*3 + 56*-1 = 76
Multiplying these together (68 * 80 * 152 * 76, ignoring calories for now) results in a total score of 62842880, which happens to be the best score possible given these ingredients. If any properties had produced a negative total, it would have instead become zero, causing the whole score to multiply to zero.

Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make?*/
using System.Diagnostics;
namespace Day15
{
    internal class Ingredient
    {
        internal string Name;
        internal int Capacity;
        internal int Durability;
        internal int Flavor;
        internal int Texture;
        internal int Calories;
        internal Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            Name = name;
            Capacity = capacity;
            Durability = durability;
            Flavor = flavor;
            Texture = texture;
            Calories = calories;
        }
    }
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] input = puzzleData.Split("\r\n");

            Ingredient[] ingredients = new Ingredient[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                string[] parts = input[i].Split(' ');
                ingredients[i] = new Ingredient(parts[0], int.Parse(parts[2].Replace(",", "")), int.Parse(parts[4].Replace(",", "")), int.Parse(parts[6].Replace(",", "")), int.Parse(parts[8].Replace(",", "")), int.Parse(parts[10]));
            }

            int maxScore = int.MinValue;
            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= 100 - i; j++)
                {
                    for (int k = 0; k <= 100 - i - j; k++)
                    {
                        int l = 100 - i - j - k;
                        int capacity = ingredients[0].Capacity * i + ingredients[1].Capacity * j + ingredients[2].Capacity * k + ingredients[3].Capacity * l;
                        int durability = ingredients[0].Durability * i + ingredients[1].Durability * j + ingredients[2].Durability * k + ingredients[3].Durability * l;
                        int flavor = ingredients[0].Flavor * i + ingredients[1].Flavor * j + ingredients[2].Flavor * k + ingredients[3].Flavor * l;
                        int texture = ingredients[0].Texture * i + ingredients[1].Texture * j + ingredients[2].Texture * k + ingredients[3].Texture * l;
                        capacity = Math.Max(0, capacity);
                        durability = Math.Max(0, durability);
                        flavor = Math.Max(0, flavor);
                        texture = Math.Max(0, texture);
                        
                        maxScore = Math.Max(maxScore, capacity * durability * flavor * texture);
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("The maximum cooking score is {0} calculated in {1} ms",maxScore,watch.ElapsedMilliseconds);
        }
    }
}
