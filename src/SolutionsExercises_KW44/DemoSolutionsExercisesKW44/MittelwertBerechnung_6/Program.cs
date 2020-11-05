using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittelwertBerechnung_6
{
    class Program
    {
        ////Implementierung ohne Arrays
        ////#############################################################
        //static void Main(string[] args)
        //{
        //    double sumOfInputValues = 0.0;
        //    double averageValue = 0.0;
        //    int countOfValues = 0;

        //    //get the count of input values
        //    Console.Write("Bitte die Anzahl der Werte eingeben: ");
        //    countOfValues = int.Parse(Console.ReadLine());

        //    //get the input values
        //    for (int i = 0; i < countOfValues; i++)
        //    {
        //        Console.Write($"Geben Sie nun den {i+1}. Wert ein: ");
        //        sumOfInputValues += double.Parse(Console.ReadLine());
        //    }

        //    //calculate the average
        //    averageValue = sumOfInputValues / countOfValues;

        //    //display the result
        //    Console.WriteLine($"\nDer Mittelwert Ihrer Eingaben ist: {averageValue}");
        //}

        //Implementierung mit Arrays
        //#############################################################
        static void Main(string[] args)
        {
            double[] inputValues;
            double averageValue = 0.0;
            double sumOfInputValues = 0.0;
            int countOfValues = 0;

            //get the count of input values
            Console.Write("Bitte die Anzahl der Werte eingeben: ");
            countOfValues = int.Parse(Console.ReadLine());

            //init the array
            inputValues = new double[countOfValues];

            //get the input values
            for (int i = 0; i < countOfValues; i++)
            {
                Console.Write($"Geben Sie nun den {i + 1}. Wert ein: ");
                inputValues[i] = double.Parse(Console.ReadLine());
            }

            //calculate the average
            foreach (double value in inputValues)
            {
                sumOfInputValues += value;
            }
            averageValue = sumOfInputValues / countOfValues;

            //display the result
            Console.WriteLine("\nIhre Eingaben:");
            foreach (double input in inputValues)
            {
                Console.WriteLine(input);
            }
            Console.WriteLine($"\nDer Mittelwert Ihrer Eingaben ist: {averageValue}");
        }
    }
}
