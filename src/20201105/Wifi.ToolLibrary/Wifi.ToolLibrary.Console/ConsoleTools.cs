using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.ToolLibrary.ConsoleIo
{
    public class ConsoleTools
    {
        /// <summary>
        /// Generates colored messages for the console output
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="messageColor">The color of the message</param>
        public static void DisplayColoredMessage(string message, ConsoleColor messageColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// Generates colored messages for the console output
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="messageColor">The color of the message</param>
        public static void DisplayColoredMessage(string message)
        {
            DisplayColoredMessage(message, ConsoleColor.Yellow);
        }



        /// <summary>
        /// Reads an integer value from console input.
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns>Input value as integer</returns>
        public static int GetInt(string inputPrompt)
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

        /// <summary>
        /// Reads an double value from console input.
        /// </summary>
        /// <param name="inputPrompt">Prompt for the user</param>
        /// <returns></returns>
        public static double GetDouble(string inputPrompt)
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
        public static DateTime GetDateTime(string inputPrompt)
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
        public static string GetString(string inputPrompt)
        {
            Console.Write(inputPrompt);

            //read input value and convert to string
            return Console.ReadLine();
        }


        public static void HelloWorld()
        {
            Console.WriteLine("Hi!");
        }
    }
}
