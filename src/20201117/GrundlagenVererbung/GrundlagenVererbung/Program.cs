using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenVererbung
{
    class Program
    {
        static void Main(string[] args)
        {
            Sales susi = new Sales("Susi", "Musterman", new DateTime(2000, 5, 1), 1500.90m, 0.15);

            Console.WriteLine(susi.GetInfoString());

        }
    }
}
