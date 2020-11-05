using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Coins_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool coinValueIsValid = false;
            int[] validCoinValues = new int[] { 5, 10, 20, 50, 100, 200 };
            int inputValue = 0;

            do
            {
                Console.Write("Bitte werfen Sie eine Münze ein: ");
                try
                {
                    inputValue = int.Parse(Console.ReadLine());
                    coinValueIsValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                    coinValueIsValid = false;
                }

                //Variante 2
                if (coinValueIsValid)
                {
                    ////Solution for a)
                    //if (inputValue == 5 || inputValue == 10 ||
                    //inputValue == 20 || inputValue == 50 ||
                    //inputValue == 100 || inputValue == 200)
                    //{
                    //    coinValueIsValid = true;
                    //}
                    //else
                    //{
                    //    coinValueIsValid = false;
                    //    Console.WriteLine($"ERROR: Ungültiger Münzen-Wert.");
                    //}

                    //Solution for b)
                    switch (inputValue)
                    {
                        case 5:
                        case 10:
                        case 20:
                        case 50:
                        case 100:
                        case 200:
                            coinValueIsValid = true;
                            break;

                        default:
                            coinValueIsValid = false;
                            Console.WriteLine($"ERROR: Ungültiger Münzen-Wert.");
                            break;
                    }
                }

                ////Variante 2 - using a simple array
                //if (coinValueIsValid)
                //{
                //    coinValueIsValid = false;
                //    foreach (var coinValue in validCoinValues)
                //    {
                //        if (inputValue == coinValue)
                //        {
                //            coinValueIsValid = true;
                //            break;
                //        }
                //    }

                //    if (!coinValueIsValid)
                //    {
                //        Console.WriteLine($"ERROR: Ungültiger Münzen-Wert.");
                //    }
                //}
            }
            while (!coinValueIsValid);

            Console.WriteLine("Die Münze ist gültig!");

        }
    }
}
