using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_for
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCount = 10;

            for (int i = 0; i < maxCount; i++)
            {
                Console.WriteLine($"{i + 1}. Durchlauf...");
            }

            Console.WriteLine();

            for (int x = 21; x >= 10; x = x - 1)
            {
                Console.WriteLine($"Test: {x}");
            }
        }
    }
}
