/*Santa's Accounting-Elves need help balancing the books after a recent order. Unfortunately, their accounting software uses a peculiar storage format. That's where you come in.

They have a JSON document which contains a variety of things: arrays ([1,2,3]), objects ({"a":1, "b":2}), numbers, and strings. Your first job is to simply find all of the numbers throughout the document and add them together.

For example:

[1,2,3] and {"a":2,"b":4} both have a sum of 6.
[[[3]]] and {"a":{"b":4},"c":-1} both have a sum of 3.
{"a":[-1,1]} and [-1,{"a":1}] both have a sum of 0.
[] and {} both have a sum of 0.
You will not encounter any strings containing numbers.

What is the sum of all numbers in the document?*/
using System.Diagnostics;
using Newtonsoft.Json.Linq;
namespace Day12
{
    internal static class part1
    {
        internal static void solve(string puzzleData)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            JToken json = JToken.Parse(puzzleData);
            int result = sum(json);
            watch.Stop();
            Console.WriteLine("The total of numbers in the json file is " + result+" completed in "+watch.ElapsedMilliseconds+"ms");
        }
        internal static int sum(JToken json)
        {
            int total = 0;
            if (json.Type == JTokenType.Object)
            {
                foreach (JProperty child in json.Children<JProperty>())
                {
                    total += sum(child.Value);
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
