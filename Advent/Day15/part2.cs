/*Your cookie recipe becomes wildly popular! Someone asks if you can make another recipe that has exactly 500 calories per cookie (so they can use it as a meal replacement). Keep the rest of your award-winning process the same (100 teaspoons, same ingredients, same scoring system).

For example, given the ingredients above, if you had instead selected 40 teaspoons of butterscotch and 60 teaspoons of cinnamon (which still adds to 100), the total calorie count would be 40*8 + 60*3 = 500. The total score would go down, though: only 57600000, the best you can do in such trying circumstances.

Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make with a calorie total of 500?*/
using System.Diagnostics;
namespace Day15
{
    internal static class part2
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
                        int calories = ingredients[0].Calories * i + ingredients[1].Calories * j + ingredients[2].Calories * k + ingredients[3].Calories * l;
                        capacity = Math.Max(0, capacity);
                        durability = Math.Max(0, durability);
                        flavor = Math.Max(0, flavor);
                        texture = Math.Max(0, texture);
                        calories = Math.Max(0, calories);
                        if (calories == 500)
                        {
                            maxScore = Math.Max(maxScore, capacity * durability * flavor * texture);
                        }
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("The maximum cooking score under 500 calories is {0} calculated in {1} ms", maxScore, watch.ElapsedMilliseconds);
        }
    }
}
