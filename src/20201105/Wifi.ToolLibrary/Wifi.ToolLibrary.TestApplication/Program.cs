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
            ConsoleTools.DisplayColoredMessage("Hallo Leute!", ConsoleColor.Magenta);

            ConsoleTools.DisplayColoredMessage("Hallo liebe Leute..", ConsoleColor.Cyan, true);

            Console.WriteLine("Testausgabe im Main()");

            ConsoleTools.GetDateTime("Alte Version: Geburtstag: ");
            ConsoleTools.GetDateTime("Neue Version: Geburtstag: ", "yyyy-MM-dd");
        }
    }
}
