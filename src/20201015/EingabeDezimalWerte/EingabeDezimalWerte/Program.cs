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
            string input = string.Empty;

            //create header
            Console.WriteLine("############################################");
            Console.WriteLine("             Flächen Berechnung");
            Console.WriteLine("############################################");

            //display input prompt & get length values
            Console.WriteLine("\nBitte Seitenlängen angeben:\n");                        
            Console.Write("\ta: ");
            input = Console.ReadLine();
            lengthA = double.Parse(input);

            Console.Write("\tb: ");
            input = Console.ReadLine();
            lengthB = double.Parse(input);

            //calculate area of rectangle
            calculatedRectangleArea = lengthA * lengthB;

            //display result
            Console.WriteLine($"\nFläche des Rechtecks ({lengthA} x {lengthB}): {calculatedRectangleArea}");

        }
    }
}
