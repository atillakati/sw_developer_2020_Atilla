using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Artikel artikel = new Artikel();

            artikel.Bezeichnung = "Schraube M3 x 15mm. verchromt";
            artikel.Bezeichnung = string.Empty;

            artikel.

            Console.WriteLine("Content: " + artikel.Bezeichnung);
        }   
    }
}
