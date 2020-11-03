using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodenGL
{
    class Program
    {
        static void Main(string[] args)
        {
            int eineVariable = 12;

            DisplayHello();
            DisplayHello();
            DisplayHello();
            DisplayHello();

            DisplayColoredMessage("Hallo liebe Leute!", ConsoleColor.Yellow);

            DisplayColoredMessage("Hallo liebe Leute!", ConsoleColor.Red);
            DisplayColoredMessage("Hallo liebe Leute!", ConsoleColor.Green);

            double erg = CalculateWeight(20.0);
            Console.WriteLine($"Ergebnis: {erg}");            
        }

        // Signatur
        //Rückgabetyp Bezeichnung ( [Parameter] )        
        static void DisplayHello()
        {
            Console.WriteLine("Hello!");
        }

        static void DisplayColoredMessage(string message, ConsoleColor messageColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldColor;            
        }

        // Signatur
        //Rückgabetyp Bezeichnung ( [Parameter] )        
        static double CalculateWeight(double nettoWeight)
        {
            double result = 0.0;

            result = nettoWeight * 1.25;

            return result;
        }

        static int GetInt(string inputPrompt)
        {

        }
    }
}
