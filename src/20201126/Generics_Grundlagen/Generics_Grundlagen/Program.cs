using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Grundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] meineZahlen = InitArray<double>(10, 1.99);

            DateTime[] geburtstage = InitArray<DateTime>(10, DateTime.Now);  
            
        }
        
        static T[] InitArray<T>(int elementCount, T initValue)
        {
            T[] tmpArray = new T[elementCount];

            for (int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = initValue;
            }

            return tmpArray;
        }
    }
}
