using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ausgaben_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //define constants - reduce hardcoded numeric values in the code
            const int MAX_VALUE = 5;
            const int MIN_VALUE = 1;

            bool userInputIsValid = false;
            int inputValue = 0;
            string[] numericStringValues = new string[] { "eins", "zwei", "drei", "vier", "fünf" };

            do
            {                           
                //get the input from user
                Console.Write($"Usereingabe ({MIN_VALUE}-{MAX_VALUE}): ");
                try
                {                    
                    inputValue = int.Parse(Console.ReadLine());

                    //check input value range
                    userInputIsValid = inputValue >= MIN_VALUE && inputValue <= MAX_VALUE;
                    if (!userInputIsValid)
                    {
                        Console.WriteLine("ERROR: Ungültiger Wert.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);
                    userInputIsValid = false;
                }
            }
            while (!userInputIsValid);

            //Process inputValue for output
            //Variante 1
            if(inputValue == 1)
            {
                Console.WriteLine("Dies war die Zahl eins!");
            }
            else if(inputValue == 2)
            {
                Console.WriteLine("Dies war die Zahl zwei!");
            }
            else if (inputValue == 3)
            {
                Console.WriteLine("Dies war die Zahl drei!");
            }
            else if (inputValue == 4)
            {
                Console.WriteLine("Dies war die Zahl vier!");
            }
            else if (inputValue == 5)
            {
                Console.WriteLine("Dies war die Zahl fünf!");
            }

            //Variante 2 - using arrays
            Console.WriteLine($"Dies war die Zahl {numericStringValues[inputValue-1]}!");
        }
    }
}
