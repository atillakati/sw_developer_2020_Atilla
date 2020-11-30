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
            var geburtsJahr = ConsoleTools.GetInt("Bitte geben Sie Ihr Geburtsjahr ein: ", DoNothing);    
            
        }

        static void DoNothing(string errorMessage)
        {
            
        }

        static void DisplayInputError(string errorMessage)
        {
            ConsoleTools.DisplayColoredMessage(errorMessage, ConsoleColor.Red);
        }

        static void DisplayErrorOnLastLine(string errorMessage)
        {
            var oldYposition = Console.CursorTop;
            Console.SetCursorPosition(0, Console.WindowHeight - 3);

            ConsoleTools.DisplayColoredMessage(errorMessage, ConsoleColor.Red);
            Console.ReadLine();

            //löschen der Fehlermeldung
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine(new string(' ', errorMessage.Length));

            //cursor position wieder herstellen
            Console.SetCursorPosition(0, oldYposition);
        }
    }
}
