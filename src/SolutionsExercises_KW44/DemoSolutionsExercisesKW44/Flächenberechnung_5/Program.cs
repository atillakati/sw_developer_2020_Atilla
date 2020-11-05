using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flächenberechnung_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double length_a = 0.0;
            double length_b = 0.0;
            double rectArea = 0.0;
            bool userInputIsValid = false;

            do
            {
                try
                {
                    //read length a
                    Console.Write("Länge der Seite a eingeben: ");
                    length_a = double.Parse(Console.ReadLine());

                    //read length b
                    Console.Write("Länge der Seite b eingeben: ");
                    length_b = double.Parse(Console.ReadLine());

                    userInputIsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                    userInputIsValid = false;
                }
            } while (!userInputIsValid);

            //start calculation
            rectArea = length_a * length_b;

            //output result
            Console.WriteLine($"Die Fläche beträgt: {rectArea}.");
        }
    }
}
