using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaGrundlagen
{
    public delegate void DoSomethingHandler<T>(T message);

    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingHandler<string> myAction = DisplayMessage;
            myAction("Hello Welt!");

            Action<string> myNewAction = DisplayMessage;
            

            //anonyme Methode (C# 2.0)
            myAction = delegate (string userText)
            {
                Console.Write("Ausgabe anonyme Methode: ");
                Console.WriteLine(userText);
            };

            myAction("Invoke anonyme Methode");

            //anonyme Methode (C# 3.0) => Lambda
            myAction = (string userText) =>
            {
                Console.Write("Ausgabe vereinfachte anonyme Methode: ");
                Console.WriteLine(userText);
            };

            myAction = userText =>
            {
                Console.Write("Ausgabe vereinfachte anonyme Methode: ");
                Console.WriteLine(userText);
            };

            myAction = x => Console.WriteLine(x);
            myAction("Test");

            int[] zahlenReihe = new int[] { 5, 21, 8, 9, 22, 50, 1, 96 };
            //zahlenReihe = zahlenReihe.Where(CheckSizeToFive).ToArray();
            zahlenReihe = zahlenReihe.Where(x => x > 10).ToArray();
            zahlenReihe = zahlenReihe.Select(x => x * x).ToArray();

            List<int> sortedElements = new List<int>();
            foreach (var item in zahlenReihe)
            {
                if(item > 10)
                {
                    sortedElements.Add(item);
                }
            }

            zahlenReihe = sortedElements.ToArray();            
        }

        static bool CheckSize(int number)
        {            
            return number > 10;
        }

        static bool CheckSizeToFive(int number)
        {
            return number > 5;
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
