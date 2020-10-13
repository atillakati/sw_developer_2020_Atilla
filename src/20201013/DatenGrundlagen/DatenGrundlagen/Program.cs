using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenGrundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            int zahl;

            //Initialisierung
            zahl = 9;

            //Deklaration & Initialisierung
            int zahl1 = 5;

            Console.WriteLine(zahl);
            zahl = int.MaxValue;

            //Dezimalzahlen: float, double, decimal
            double size_x = 15.321;

            Console.WriteLine("Size X = " + size_x);

            decimal preis = 15.50M;

            string name = "Gandalf";
            name = "";
            name = string.Empty;

            char symbol = 'a';

            bool isPowerOn = true;
        }
    }
}
