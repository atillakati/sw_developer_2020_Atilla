using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Zahlenraten_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_VALUE = 1;
            const int MAX_VALUE = 100;
            const int TRY_COUNTER = 7;

            Random rnd = new Random(DateTime.Now.Millisecond);
            int userInput = 0;
            int randomValue = 0;
            bool userHasGuessedTheValue = false;
            int userTryCounter = 0;
            TimeSpan maxTryDuration = TimeSpan.FromSeconds(3);
            Stopwatch stopwatch = new Stopwatch();

            //get random value
            randomValue = rnd.Next(MIN_VALUE, MAX_VALUE + 1);

            //display the game rules
            Console.WriteLine($"Du hast max. {TRY_COUNTER} Versuche. Du darfst max. {maxTryDuration.TotalSeconds} Sekunden für eine Eingabe benötigen!");
            Console.Write("\nSTART mit ENTER!");
            Console.ReadLine();

            //start guessing
            Console.WriteLine($"Errate die Zahl [{MIN_VALUE} - {MAX_VALUE}]!");
            do
            {
                Console.Write($"[{userTryCounter+1}/{TRY_COUNTER}]Ihre Eingabe => ");

                //start the input time mesurement
                stopwatch.Restart();   
                
                userInput = int.Parse(Console.ReadLine());

                //stop the input time mesurement
                stopwatch.Stop();

                //update the try counter
                userTryCounter++;

                //check input value & display user hints
                if(userInput > randomValue)
                {
                    Console.WriteLine("Die Zahl ist kleiner!");
                    userHasGuessedTheValue = false;
                }
                else if(userInput < randomValue)
                {
                    Console.WriteLine("Die Zahl ist grösser!");
                    userHasGuessedTheValue = false;
                }
                else
                {
                    Console.WriteLine("\nGEWONNEN!");
                    userHasGuessedTheValue = true;
                }               
            }
            while (!userHasGuessedTheValue && userTryCounter < TRY_COUNTER && stopwatch.Elapsed < maxTryDuration);

            if(stopwatch.Elapsed > maxTryDuration)
            {
                Console.WriteLine($"\nLeider haben Sie zu lange [{stopwatch.Elapsed}] für Ihre Eingabe benötigt.");
            }

            if (userTryCounter >= TRY_COUNTER)
            {
                Console.WriteLine($"\nLeider haben Sie die max. Anzahl der Versuche ausgeschöpft... Lösung: {randomValue}");
            }
        }
    }
}
