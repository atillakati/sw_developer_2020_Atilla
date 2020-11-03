using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGrundlagen
{
    class Program
    {


        static void Main(string[] args)
        {

            //bool participantState = false; //true

            string participantState = "krank";
            participantState = "anwesend";
            participantState = "nicht anwesend";
            participantState = "heute nicht anwesend";

            ParticipantState state = ParticipantState.Unbekannt;

            Console.ForegroundColor = ConsoleColor.Red;
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.Clear();
            Console.WriteLine("Test...");

            if(state == ParticipantState.Krank) 
            { 

            }
            

            Console.WriteLine($"State: {state}");

            Console.ResetColor();

            Console.WriteLine();            
        }
    }
}
