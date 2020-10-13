using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenOperatoren
{
    class Program
    {
        static void Main(string[] args)
        {
            //arithmetische Operatoren
            // + - / * %

            double erg = 0;
            double zahl1 = 5;
            double zahl2 = 2;

            erg = zahl1 + zahl2;
            string test = "Gandalf" + " der Weise";

            //myRaid = hdd1 + hdd2;

            Console.WriteLine("Ergebnis: " + erg);

            erg = zahl1 / zahl2;
            Console.WriteLine("Ergebnis: " + erg);

            erg = zahl1 % zahl2;
            Console.WriteLine("Ergebnis: " + erg);

            erg = Math.Sin(zahl1);

            //logische Operatoren
            // & (&&) = AND  
            // | (||) = OR
            // ! = NOT

            bool logikErgebnis = true;
            bool wert1 = true;
            bool wert2 = false;

            logikErgebnis = wert1 | wert2;

            //Vergleichsoperatoren
            // < > == != <= >= 
            bool vergleichsErgebnis = 5 > 2;             //=true
            vergleichsErgebnis = "Gandalf" == "Atilla";  //=false
            vergleichsErgebnis = "Gandalf" != "Atilla";  //=true

            //zusammengesetzte Operatoren
            int zahl = 5;            
            zahl = zahl + 3;
            zahl += 3;

            zahl -= 5;
            zahl *= 2;
            zahl /= 6;

            //Inkrementiern / Dekrementieren
            zahl = zahl + 1;
            zahl += 1;
            zahl++;
            zahl--;
            ++zahl;
            --zahl;

            zahl = 5;
            Console.WriteLine("Zahl: " + zahl);     // 5
            Console.WriteLine("Zahl: " + zahl++);   // 5
            Console.WriteLine("Zahl: " + zahl++);   // 6
            Console.WriteLine("Zahl: " + ++zahl);   // 8
            Console.WriteLine("Zahl: " + zahl++);   // 8
            //zahl = 9


        }
    }
}
