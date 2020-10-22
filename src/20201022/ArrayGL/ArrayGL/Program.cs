using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayGL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            int zahl;
            int[] zahlen;

            //Dimensionierung
            zahlen = new int[5];

            //Initialisierung
            zahl = -2;            

            zahlen[0] = 50;
            zahlen[1] = 0;
            zahlen[2] = 10;
            zahlen[3] = 20;
            zahlen[4] = 30;

            zahlen[0] = zahlen[1] + zahlen[2];

            //Ausgabe der Inhalte aus dem Array
            //Console.WriteLine($"Element 1: {zahlen[0]}");
            //Console.WriteLine($"Element 2: {zahlen[1]}");
            //Console.WriteLine($"Element 3: {zahlen[2]}");
            //Console.WriteLine($"Element 4: {zahlen[3]}");
            //Console.WriteLine($"Element 5: {zahlen[4]}");


            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine($"Element {i + 1}: {zahlen[i]}");
            }

        }
    }
}
