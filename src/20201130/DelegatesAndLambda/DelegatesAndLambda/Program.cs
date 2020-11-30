using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndLambda
{
    //Type Spezifikation
    public delegate void DoSomethingHandler(string message);

    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingHandler myAction;
            DoSomethingHandler[] myActionList = new DoSomethingHandler[2];

            //Methode als WERT zuweisen
            //myAction = DisplayMessage;
            myAction = CreateOutput;
            myAction("Hallo!");

            myActionList[0] = CreateOutput;
            myActionList[1] = DisplayMessage;

            //Methode über delegate aufrufen
            foreach (var method in myActionList)
            {
                Console.WriteLine($"Invoke {method.Method.Name}:");
                method("Wie cool ist denn das?");
                Console.WriteLine();
            }
        }

        static void CreateOutput(string text)
        {
            Console.WriteLine("...creating output now:");
            Console.WriteLine("\t{0}", text.ToUpper());
        }

        static void DisplayMessage(string userMessage)
        {
            Console.WriteLine(userMessage);
        }
    }
}
