using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Reverse
    {
        static int limit = 10_000;
        record Result(string result, long elapsedTime);

        static void Main(string[] args)
        {
            //String result = String.Empty;
            String input = GetInputString();

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //Approach 1
            //var result1 = StackReverse(input);
            //Console.WriteLine(result1.elapsedTime);

            //Approach 2
            //var result2 = SBReverse(input);
            //Console.WriteLine(result2.elapsedTime);

            //Approach 3
            var result3 = SensibleReverse(input);
            Console.WriteLine(result3.elapsedTime);

            //Approach 4
            var result4 = CharReverse(input);
            Console.WriteLine(result4.elapsedTime);

            //Approach 5
            var result5 = StringCreateReverse(input);
            Console.WriteLine(result5.elapsedTime);
        }

        static String GetInputString()
        {
            char[] result = new char[limit];
            for (int i = 0; i < limit; i++)
            {
                Int32 random = i < limit / 2 ? RandomNumberGenerator.GetInt32(65, 91) : RandomNumberGenerator.GetInt32(97, 123);
                result[i] = (char)random;
            }
            return new String(result);
        }

        //trash but valid!
        static Result StackReverse(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
                stack.Push(input[i]);

            String reversed = String.Empty;
            for (int i = 0; i < input.Length; i++)
                reversed = reversed + stack.Pop();

            stopwatch.Stop();
            return new Result(reversed, stopwatch.ElapsedTicks);
        }

        //great performance & memory usage
        static Result SBReverse(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
                sb.Append(input[i]);

            var result = sb.ToString();
            stopwatch.Stop();
            return new Result(result, stopwatch.ElapsedTicks);
        }

        //reasonable perf and readability
        static Result SensibleReverse(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var array = input.ToCharArray();
            Array.Reverse(array);

            var result = new String(array);
            stopwatch.Stop();
            return new Result(result, stopwatch.ElapsedTicks);
        }


        //best performance in 99% scenarios (strlen < 10_000)
        static Result CharReverse(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var l = input.Length - 1;
            char[] array = new char[input.Length];

            for (int i = l; i >= 0; i--)
                array[l - i] = input[i];

            var result = new String(array);
            stopwatch.Stop();
            return new Result(result, stopwatch.ElapsedTicks);
        }

        //strings.create method (best perf for large strings > 10_000)
        static Result StringCreateReverse(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string result = String.Create(input.Length, input, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars.Reverse();
            });

            stopwatch.Stop();
            return new Result(result, stopwatch.ElapsedTicks);
        }
    }
}
