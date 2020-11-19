using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungGrundlagen_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Sales susi = new Sales("Susi", "Sales", new DateTime(2000, 5, 19), 1500.8m, 0.15);
            Console.WriteLine(susi.GetInfoString());

            Manager manfred = new Manager("Manfred", "Manager", new DateTime(1980, 10, 5), 15, 2500m);
            Console.WriteLine(manfred.GetInfoString());

            Console.WriteLine($"Anteile: {manfred.Shares}%");
            manfred.AddShares(5);
            Console.WriteLine($"Anteile: {manfred.Shares}%");
            manfred.RemoveShares(20);
            Console.WriteLine($"Anteile: {manfred.Shares}%");
        }
    }
}
