using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlenreihen_7
{
    class Program
    {
        ////Implementierung nur eine Spalte
        ////#################################################################
        //static void Main(string[] args)
        //{
        //    int maxFaktor = 0;

        //    //get max faktor
        //    Console.Write("Bitte max. Faktor eingeben (1-20): ");
        //    maxFaktor = int.Parse(Console.ReadLine());

        //    //check range
        //    if(maxFaktor > 20 || maxFaktor < 0)
        //    {
        //        Console.WriteLine("Der Wert ist leider ungültig!");
        //        return;
        //    }

        //    Console.WriteLine();

        //    //create column with calculation
        //    for (int i = 0; i < maxFaktor; i++)
        //    {
        //        Console.WriteLine($"{i+1,2} x 2 = {(i+1)*2,2}");
        //    }

        //    Console.WriteLine();
        //}

        //Implementierung mehrere Spalten
        //#################################################################
        static void Main(string[] args)
        {
            int maxFaktor = 0;
            int maxColumn = 0;

            //get max faktor
            Console.Write("Bitte max. Faktor eingeben (1-20): ");
            maxFaktor = int.Parse(Console.ReadLine());

            Console.Write("Bitte Anzahl der Spalten eingeben (1-8): ");
            maxColumn = int.Parse(Console.ReadLine());

            //check range
            if (maxFaktor > 20 || maxFaktor < 0 || maxColumn > 8 || maxColumn < 1)
            {
                Console.WriteLine("Der Wert ist leider ungültig!");
                return;
            }

            Console.WriteLine();

            //create column with calculation
            for (int i = 0; i < maxFaktor; i++)
            {
                //create column values
                for (int j = 0; j < maxColumn; j++)
                {
                    Console.Write($"{i + 1,2} x {j + 1} = {(i + 1) * (j + 1),2}      ");
                }

                //line break!
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
