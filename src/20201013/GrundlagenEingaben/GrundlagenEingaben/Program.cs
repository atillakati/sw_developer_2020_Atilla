using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenEingaben
{
    class Program
    {
        static void Main(string[] args)
        {            
            string name = string.Empty;

            Console.Write("Bitte Name eingeben: ");
            name = Console.ReadLine();

            Console.WriteLine("Hallo " + name + "!");

            #region Ausgabe string mit Variablen Inhalten
            Console.WriteLine($"Hallo {name}!");

            string ausgabe = $"Lieber {name}, {name} ist ein schöner Name!";
            Console.WriteLine(ausgabe);

            Console.WriteLine("Hallo {0}!", name);
            int zahl1 = 5;
            int zahl2 = 2;
            int erg = zahl1 + zahl2;

            Console.WriteLine("Die Summe von {1} + {2} ergibt {0}.", erg, zahl1, zahl2);

            string newOutputString = string.Format("Die Summe von {1} + {2} ergibt {0}.", erg, zahl1, zahl2); 
            #endregion
        }
    }
}
