using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { {1,2,3,4 }, {5,6,7,8 } };
            Console.WriteLine($"row: {a.GetLength(0)}, col: {a.GetLength(1)}, dimension: {a.Rank}\na[{a.GetUpperBound(0)},0]:{a[a.GetUpperBound(0),0]}");
            Console.ReadKey();
        }
    }
}
