using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

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

            eineVariable = GetInt("Bitte Länge eingeben: ");
            Console.WriteLine("Länge = " + eineVariable);

            double gewicht = GetDouble("Gewicht eingeben: ");
            Console.WriteLine($"Das Gewicht ist {gewicht}.");

            DateTime gebDate = GetDateTime("Geburtsdatum eingeben: ");
            Console.WriteLine($"Sie sind {DateTime.Now.Year - gebDate.Year} Jahre alt.");
        }

        // Signatur
        //Rückgabetyp Bezeichnung ( [Parameter] )        
        static void DisplayHello()
        {
            Console.WriteLine("Hello!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageColor"></param>
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


        /// <summary>
        /// Reads an integer value from console input.
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns>Input value as integer</returns>
        static int GetInt(string inputPrompt)
        {
            int userInputValue = 0;
            bool userInputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                try
                {
                    //read input value and convert to int
                    userInputValue = int.Parse(Console.ReadLine());
                    userInputIsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    userInputIsValid = false;
                }
            }
            while (!userInputIsValid);

            return userInputValue;
        }

        //==> GetDouble(); GetString(); GetDateTime() => KISS!

        /// <summary>
        /// Reads an double value from console input.
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns></returns>
        static double GetDouble(string inputPrompt)
        {
            double userInputValue = 0;
            bool userInputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                try
                {
                    //read input value and convert to double
                    userInputValue = double.Parse(Console.ReadLine());
                    userInputIsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    userInputIsValid = false;
                }
            }
            while (!userInputIsValid);

            return userInputValue;
        }

        /// <summary>
        /// Reads an DateTime value from console input. The input format must be [dd.MM.yyyy hh:mm:ss].
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns></returns>
        static DateTime GetDateTime(string inputPrompt)
        {
            DateTime userInputValue = DateTime.MinValue;
            bool userInputIsValid = false;

            string inputFormat = "dd.MM.yyyy hh:mm:ss";

            do
            {
                Console.Write(inputPrompt);
                try
                {
                    //read input value and convert to DateTime
                    userInputValue = DateTime.ParseExact(Console.ReadLine(), inputFormat, CultureInfo.InvariantCulture);
                    userInputIsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    userInputIsValid = false;
                }
            }
            while (!userInputIsValid);

            return userInputValue;
        }

        /// <summary>
        /// Reads an string value from console input.
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns></returns>
        static string GetString(string inputPrompt)
        {
            Console.Write(inputPrompt);

            //read input value and convert to string
            return Console.ReadLine();
        }

    }
}
