/*Uh oh - the Accounting-Elves have realized that they double-counted everything red.

Ignore any object (and all of its children) which has any property with the value "red". Do this only for objects ({...}), not arrays ([...]).

[1,2,3] still has a sum of 6.
[1,{"c":"red","b":2},3] now has a sum of 4, because the middle object is ignored.
{"d":"red","e":[1,2,3,4],"f":5} now has a sum of 0, because the entire structure is ignored.
[1,"red",5] has a sum of 6, because "red" in an array has no effect.*/
using Newtonsoft.Json.Linq;
using System.Diagnostics;
namespace Day12
{
    internal static class part2
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            JToken json = JToken.Parse(puzzleData);
            int result = sum(json);
            watch.Stop();
            Console.WriteLine("The total of numbers in the json file excluding those with parameter red is " + result + " completed in " + watch.ElapsedMilliseconds + "ms");
        }
        internal static int sum(JToken json)
        {
            int total = 0;
            if (json.Type == JTokenType.Object)
            {
                bool containsRed = false;
                foreach (var child in json.Children<JProperty>())
                {
                    if (child.Value.Type == JTokenType.String && child.Value.ToString() == "red")
                    {
                        containsRed = true;
                        break;
                    }
                }
                if (!containsRed)
                {
                    foreach (JProperty child in json.Children<JProperty>())
                    {
                        total += sum(child.Value);
                    }
                }
            }
            else if (json.Type == JTokenType.Array)
            {
                foreach (JToken child in json.Children())
                {
                    total += sum(child);
                }
            }
            else if (json.Type == JTokenType.Integer)
            {
                total += (int)json;
            }
            return total;
        }
    }
}
