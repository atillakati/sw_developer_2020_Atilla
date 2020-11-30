using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAdvanced
{
    public class TestClass
    {
        public void Calculate(int z1, int z2)
        {
            if(z1 == 0)
            {
                //throw new CalculationImpossibleException("z1");
                throw new ArgumentException("z1");
            }

            if (z2 == 0)
            {
                throw new CalculationImpossibleException("z2");
            }

            Console.WriteLine("Berechnung gestartet....");
        }
    }
}
