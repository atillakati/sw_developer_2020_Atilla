using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wifi.ToolLibrary.ConsoleIo;

namespace Wifi.ToolLibrary.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomAdv rnd = new RandomAdv();

            Console.WriteLine($"Zufällige Zahl (1-10): {rnd.Next(1,11)}");

            Console.WriteLine($"Zufälliger String: {rnd.NextString(15)}");
            Console.WriteLine($"Zufälliger String: {rnd.NextString(15)}");
            Console.WriteLine($"Zufälliger String: {rnd.NextString(25)}");
        }
    }
}
