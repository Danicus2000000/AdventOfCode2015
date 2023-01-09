/*This year, Santa brought little Bobby Tables a set of wires and bitwise logic gates! Unfortunately, little Bobby is a little under the recommended age range, and he needs help assembling the circuit.

Each wire has an identifier (some lowercase letters) and can carry a 16-bit signal (a number from 0 to 65535). A signal is provided to each wire by a gate, another wire, or some specific value. Each wire can only get a signal from one source, but can provide its signal to multiple destinations. A gate provides no signal until all of its inputs have a signal.

The included instructions booklet describes how to connect the parts together: x AND y -> z means to connect wires x and y to an AND gate, and then connect its output to wire z.

For example:

123 -> x means that the signal 123 is provided to wire x.
x AND y -> z means that the bitwise AND of wire x and wire y is provided to wire z.
p LSHIFT 2 -> q means that the value from wire p is left-shifted by 2 and then provided to wire q.
NOT e -> f means that the bitwise complement of the value from wire e is provided to wire f.
Other possible gates include OR (bitwise OR) and RSHIFT (right-shift). If, for some reason, you'd like to emulate the circuit instead, almost all programming languages (for example, C, JavaScript, or Python) provide operators for these gates.

For example, here is a simple circuit:

123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i
After it is run, these are the signals on the wires:

d: 72
e: 507
f: 492
g: 114
h: 65412
i: 65079
x: 123
y: 456
In little Bobby's kit's instructions booklet (provided as your puzzle input), what signal is ultimately provided to wire a?

 
 Part 2:
Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). What new signal is ultimately provided to wire a?
 */
using System.Diagnostics;
namespace Day7
{
    internal static class solution 
    {
        private static Dictionary<string, int> values=new Dictionary<string, int>();
        private static List<Ops> ops=new List<Ops>();
        internal static void solve(string puzzleData)
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            var input = puzzleData.Split("\r\n").ToList();
            values = new Dictionary<string, int>();
            ops = new List<Ops>();
            foreach (string inp in input)//filter instructions
            {
                var data = inp.Split(' ');
                Ops op = new Ops();
                switch (data.Length)
                {
                    case 3:
                        op.Op = "Pass";
                        op.leftOp = data[0];
                        op.result = data[2];
                        break;
                    case 4:
                        op.Op = data[0];
                        op.rightOp = data[1];
                        op.result = data[3];
                        break;
                    case 5:
                        op.Op = data[1];
                        op.leftOp = data[0];
                        op.rightOp = data[2];
                        op.result = data[4];
                        break;
                }
                ops.Add(op);//add options
            }
            foreach (Ops op in ops)
            {
                GetValues(op);
            }
            Console.WriteLine("part 1: "+values["a"]);
            Ops op1 = ops.FirstOrDefault(o => o.result == "b");
            ops.Remove(op1);
            op1.leftOp = values["a"].ToString();
            ops.Add(op1);
            values = new Dictionary<string, int>();
            foreach (Ops op in ops)
            {
                GetValues(op);
            }
            watch.Stop();
            Console.WriteLine("part 2: "+values["a"]);
            Console.WriteLine("Time: " + watch.ElapsedMilliseconds);
        }

        // Define other methods and classes here
        public struct Ops
        {
            public string leftOp;
            public string rightOp;
            public string Op;
            public string result;
        }

        public static int GetValue(string operand)//get value of wire following option logic
        {
            var val = 0;
            if (Int32.TryParse(operand, out val)) return val;
            if (!values.ContainsKey(operand))
            {
                Ops op = ops.FirstOrDefault(o => o.result == operand);
                GetValues(op);
            }
            val = values[operand];
            return val;
        }

        public static void GetValues(Ops op)//get value of operation logic
        {
            switch (op.Op)
            {
                case "Pass":
                    values[op.result] = GetValue(op.leftOp);
                    break;
                case "NOT":
                    values[op.result] = ~GetValue(op.rightOp);
                    break;
                case "OR":
                    values[op.result] = GetValue(op.leftOp) | GetValue(op.rightOp);
                    break;
                case "AND":
                    values[op.result] = GetValue(op.leftOp) & GetValue(op.rightOp);
                    break;
                case "RSHIFT":
                    values[op.result] = GetValue(op.leftOp) >> GetValue(op.rightOp);
                    break;
                case "LSHIFT":
                    values[op.result] = GetValue(op.leftOp) << GetValue(op.rightOp);
                    break;
            }
        }
    }
}