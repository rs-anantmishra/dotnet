using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class Fib
    {
        public static int StdFib(int n)
        {
            //base case
            if (n <= 2) { return 1; }
            return StdFib(n - 2) + StdFib(n - 1);
        }

        public static int MemoFib(int n, Dictionary<int, int> d)
        {
            if (n <= 2) { return 1; }
            if (d.ContainsKey(n))
            {
                bool v = d.TryGetValue(n, out int result);
                return result;
            }

            d.Add(n, MemoFib(n - 2, d) + MemoFib(n - 1, d));
            bool isResolved = d.TryGetValue(n, out int memo);

            return memo;
        }
    }
}
// considering fib's starting position 0 with value 0
// 0	1	1	2	3	5	8	13  21
// 0	1	2	3	4	5	6	7	8