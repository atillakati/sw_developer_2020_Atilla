using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EingabeDezimalWerte
{
    class Program
    {
        static void Main(string[] args)
        {
            /*############################################
             *              Flächen Berechnung
             *############################################ 
             * 
             * Bitte Seitenlängen angeben:
             * 
             *  a: ?????
             *  b: ?????
             *                 
             * Fläche des Rechtecks (a x b): 3165421
             *                
             */

            double lengthA = 0.0;
            double lengthB = 0.0;
            double calculatedRectangleArea = 0.0;
            int headerXPosition = 0;
            string headerText = "Flächen Berechnung";


            //create header
            //"###" => new string('#', 3)
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            headerXPosition = (Console.WindowWidth - headerText.Length) / 2;
            Console.CursorLeft = headerXPosition;
            Console.WriteLine("Flächen Berechnung");
            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            //display input prompt & get length values
            Console.WriteLine("\nBitte Seitenlängen angeben:\n");
            Console.Write("\ta: ");

            try
            {
                lengthA = double.Parse(Console.ReadLine());

                Console.Write("\tb: ");
                lengthB = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nUups! Leider ist was schief gelaufen: " + e.Message);                
                Console.WriteLine("Source: \n" + e.StackTrace);

                Environment.Exit(1);
            }
            //finally
            //{

            //}

            //calculate area of rectangle
            calculatedRectangleArea = lengthA * lengthB;

            //display result
            Console.WriteLine($"\nFläche des Rechtecks ({lengthA} x {lengthB}): {calculatedRectangleArea}");
            
            Console.WriteLine("Program Ende!");
        }
    }
}
