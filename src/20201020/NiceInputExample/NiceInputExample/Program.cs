using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace NiceInputExample
{
    class Program
    {        
        static void Main(string[] args)
        {
            const int MAX_AGE = 150;

            /*
             *  Der User soll sein Geburtsjahr eingeben. Daraufhin wird das Alter berechnet und ausgegeben.
             *  - Fehleingaben sollen abgefangen werden (fehlertolerante Eingabe)
             *  - der User soll nach einer Fehleingabe seine Eingabe wiederholen dürfen
             *  - die Anzahl der Versuche ist nicht begrenzt!
             *  - Gültiges Geburtsjahr:
             *      - nicht in der Zukunft
             *      - PEGI 7+
             *      - nicht vor 1870 (max. 150 Jahre) => 150 Jahre ab heute!
             */
            const int MIN_AGE = 7;

            bool inputIsValid = true;
            int birthdayYear = 0;
            int age = 0;
            string inputString = string.Empty;

            //Implementierung Eingabe
            do
            {
                Console.Write("Bitte das Geburtsjahr eingeben: ");                
                inputString = Console.ReadLine();                
                inputIsValid = true;

                //Fehleingaben abfangen
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    inputIsValid = false;
                }
                else
                {
                    //ungültige Zeichen erkennen
                    for (int i = 0; i < inputString.Length; i++)
                    {
                        if (!char.IsDigit(inputString[i]))
                        {
                            inputIsValid = false;
                            break;
                        }
                    }
                }

                if (inputIsValid)
                {
                    birthdayYear = int.Parse(inputString);
                }
                else
                {
                    Console.WriteLine("\aFEHLER: Bitte nur ganze Zahlen eingeben.");                 
                }
                
                //inhaltlich ungültige Eingaben abfangen  (min./max. Alter)
                if (inputIsValid && (birthdayYear < DateTime.Now.Year - MAX_AGE || birthdayYear > DateTime.Now.Year - MIN_AGE))
                {
                    Console.WriteLine($"\aFEHLER: Ungültiges Alter ({MIN_AGE}-{MAX_AGE}).");
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);


            //Alter berechnen
            age = DateTime.Now.Year - birthdayYear;

            //Ausgabe 
            Console.WriteLine($"\nSie sind {age} Jahre jung.");
        }
    }
}


