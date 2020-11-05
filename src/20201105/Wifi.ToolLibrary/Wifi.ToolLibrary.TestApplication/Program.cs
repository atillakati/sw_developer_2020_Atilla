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
            ConsoleTools.DisplayColoredMessage("Dies ist ein Test..", ConsoleColor.Red);

            double val1 = ConsoleTools.GetDouble("Bitte Wert eingeben: ");

            Console.WriteLine($"Der Wert war: {val1}");

            ConsoleTools.DisplayColoredMessage("Test", ConsoleColor.Yellow);

            ConsoleTools.DisplayColoredMessage("Hallo");

            Console.ReadLine();
        }
    }
}
