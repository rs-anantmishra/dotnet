namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int n = 7;

            result = Fib.StdFib(n);
            Console.WriteLine(result);

            Dictionary<int, int> d = new Dictionary<int, int>();

            result = Fib.MemoFib(n, d);
            Console.WriteLine(result);

        }


    }
}