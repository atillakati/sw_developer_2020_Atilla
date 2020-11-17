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
            Artikel artikel = new Artikel("Schraube M3x15mm, verchromt", 0.10m);

            Console.WriteLine(artikel.GetInfoString());
        }
    }
}
