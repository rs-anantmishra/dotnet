using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    internal class Grid
    {
        public Int64 Rows { get; set; }
        public Int64 Cols { get; set; }
    }

    internal static class GridTraveller
    {
        public static Int64 StdGridTraveller(int m, int n)
        {
            if (m == 0 || n == 0) { return 0; }
            if (m == 1 || n == 1) { return 1; }

            return StdGridTraveller(m - 1, n) + StdGridTraveller(m, n - 1);
        }

        public static Int64 MemoGridTraveller(Grid grid, Dictionary<Grid, Int64> memo)
        {
            //base cases
            if (grid.Rows == 0 || grid.Cols == 0) { return 0; }
            if (grid.Rows == 1 || grid.Cols == 1) { return 1; }


            /* Compiler Optimized Code - having this enabled has no impact.
             * 
            bool isResolved = false;
            bool isKeyFound = false;

            IList<Grid> lstGridKeys = memo.Keys.ToList();
            foreach (var gridKey in lstGridKeys)
            {
                if (gridKey.Rows == grid.Rows && gridKey.Cols == grid.Cols)
                { isKeyFound = true; break; }
            }

            //check memo for fast-return
            if (isKeyFound)
            {
                Int64 value = memo.Where(x => (x.Key.Rows == grid.Rows && x.Key.Cols == grid.Cols)).FirstOrDefault().Value;
                return value;
            }
            *
            */

            Int64 value = memo.Where(x => (x.Key.Rows == grid.Rows && x.Key.Cols == grid.Cols)).FirstOrDefault().Value;
            if(value > 0)
                return value;

            //Update memo
            memo.Add(grid,
                MemoGridTraveller(new Grid { Rows = grid.Rows - 1, Cols = grid.Cols }, memo) +
                MemoGridTraveller(new Grid { Rows = grid.Rows, Cols = grid.Cols - 1 }, memo)
                );

            Int64 result = memo.Where(x => (x.Key.Rows == grid.Rows && x.Key.Cols == grid.Cols)).FirstOrDefault().Value;

            return result;

        }
    }
}
