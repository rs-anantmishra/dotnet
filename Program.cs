using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CallFib();

            CallGridTraveller();




        }

        static void CallGridTraveller()
        {
            Stopwatch s = new Stopwatch();
            //try
            //{
            //    s.Start();
            //    Int64 result = 0;
            //    int rows = 18; int cols = 18;
            //    result = GridTraveller.StdGridTraveller(rows, cols);
            //    Console.WriteLine($"Ways to traverse {rows} x {cols} grid are: {result}");
            //}
            //finally
            //{
            //    s.Stop();
            //    Console.WriteLine($"Time elapsed: {s.Elapsed}");
            //}

            try
            {
                s.Start();
                Grid g = new Grid();
                g.Rows = 18; g.Cols = 18;
                Dictionary<Grid, Int64> memo = new Dictionary<Grid, Int64>();
                Int64 result = GridTraveller.MemoGridTraveller(g, memo);

                Console.WriteLine($"Result is: {result}");
            }
            finally
            {
                s.Stop();
                Console.WriteLine($"Time elapsed: {s.Elapsed}");
            }
        }

        static void CallFib()
        {
            int result = 0;
            int n = 7;

            /* Call Standard Fib */
            result = Fib.StdFib(n);
            Console.WriteLine(result);

            /* Call Memoized Fib */
            Dictionary<int, int> d = new Dictionary<int, int>();
            result = Fib.MemoFib(n, d);
            Console.WriteLine(result);
        }


    }
}