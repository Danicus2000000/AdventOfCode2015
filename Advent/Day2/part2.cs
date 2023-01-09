/*The elves are also running low on ribbon. Ribbon is all the same width, so they only have to worry about the length they need to order, which they would again like to be exact.

The ribbon required to wrap a present is the shortest distance around its sides, or the smallest perimeter of any one face. Each present also requires a bow made out of ribbon as well; the feet of ribbon required for the perfect bow is equal to the cubic feet of volume of the present. Don't ask how they tie the bow, though; they'll never tell.

For example:

A present with dimensions 2x3x4 requires 2+2+3+3 = 10 feet of ribbon to wrap the present plus 2*3*4 = 24 feet of ribbon for the bow, for a total of 34 feet.
A present with dimensions 1x1x10 requires 1+1+1+1 = 4 feet of ribbon to wrap the present plus 1*1*10 = 10 feet of ribbon for the bow, for a total of 14 feet.
How many total feet of ribbon should they order?*/
namespace Day2
{
    internal static class part2
    {
        internal static void solve(string puzzleData) 
        {
            int totalRibon = 0;
            string[] paperParts = puzzleData.Split("\r\n");
            foreach (string paper in paperParts)
            {
                string[] dimentions = paper.Split("x");
                int length = int.Parse(dimentions[0]);
                int width = int.Parse(dimentions[1]);
                int height = int.Parse(dimentions[2]);
                totalRibon += length * width * height;
                List<int > sides = new List<int> {length,width,height};
                int lowestOne = int.MaxValue;
                foreach (int side in sides) 
                {
                    if (side < lowestOne) 
                    {
                        lowestOne = side;
                    }
                }
                sides.Remove(lowestOne);
                int lowestTwo = int.MaxValue;
                foreach (int side in sides)
                {
                    if (side < lowestTwo)
                    {
                        lowestTwo = side;
                    }
                }
                totalRibon += lowestOne * 2 + lowestTwo * 2;
                Console.WriteLine(totalRibon);
            }
            Console.WriteLine("In total we need " + totalRibon + " feet of ribon");
        }
    }
}
