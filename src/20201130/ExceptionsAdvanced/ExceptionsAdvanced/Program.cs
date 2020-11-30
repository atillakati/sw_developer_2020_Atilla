using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClass = new TestClass();

            try
            {
                testClass.Calculate(0, 2);
            }
            catch (CalculationImpossibleException cex)
            {
                Console.WriteLine("Eine CalculationImpossibleException wurde abgefangen:");
                Console.WriteLine($"ERROR: {cex.Message}");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine("Juhuuu!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
