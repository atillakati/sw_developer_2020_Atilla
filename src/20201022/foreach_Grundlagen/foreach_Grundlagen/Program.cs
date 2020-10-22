using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreach_Grundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * - Anzahl der Teilnehmer einlesen!             
             * - Für jeden Teilnehmer Name und (Geburtsjahr) einlesen             
             * - Ausgabe tabelarisch alle Teilnehmerinformationen
             *              
             * */

            int participantCount = 0;
            string[] participantNames;

            //Anzahl der Teilnehmer einlesen
            Console.Write("Bitte die Anzahl der Teilnehmer eingeben: ");
            participantCount = int.Parse(Console.ReadLine());

            //Teilnehmerlist erzeugen & initialisieren
            participantNames = new string[participantCount];
            for (int i = 0; i < participantNames.Length; i++)
            {
                participantNames[i] = string.Empty;
            }

            //Teilnehmernamen einlesen
            for (int i = 0; i < participantNames.Length; i++)
            {
                Console.Write($"Bitte Name Teilnehmer {i + 1} eingeben: ");
                participantNames[i] = Console.ReadLine();
            }

            //Ausgabe der Teilnehmernamen
            Console.WriteLine("\nListe der Teilnehmer:");
            foreach(string participant in participantNames)
            {                
                Console.WriteLine($"\t{participant}");
            }
        }
    }
}
