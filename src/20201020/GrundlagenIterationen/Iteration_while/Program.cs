using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_while
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "q";

            //kopfgesteuert
            while (input != "q")
            {
                Console.Write("[while]: Bitte geben Sie etwas ein: ");
                input = Console.ReadLine();
            }

            //fussgesteuert
            do
            {
                Console.Write("[do-while]: Bitte geben Sie etwas ein: ");
                input = Console.ReadLine();
            }
            while (input != "q");
        }
    }
}
