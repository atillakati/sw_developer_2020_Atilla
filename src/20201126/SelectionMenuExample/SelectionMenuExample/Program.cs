using SelectionMenuExample.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu myMenu = new Menu();

            //myMenu.LoadFromFile("menufile.txt");

            myMenu.Add(new MenuItem("Daten laden", ConsoleKey.F1));
            myMenu.Add(new MenuItem("Daten speichern", ConsoleKey.F2));
            myMenu.Add(new EmptyItem());
            myMenu.Add(new MenuItem("Daten löschen", ConsoleKey.F3));
            myMenu.Add(new MenuItem("Daten drucken", ConsoleKey.F4));
            myMenu.Add(new EmptyItem());
            myMenu.Add(new ColoredMenuItem("Ende", ConsoleKey.Escape, ConsoleColor.Yellow));

            myMenu.Display(35);

            var mySelection = myMenu.SelectItem("Ihre Wahl: ");

            Console.WriteLine(mySelection.Description);
            
            //if(mySelection  == "daten laden")
            //{
            //    //tu was => daten sollen geladen werden
            //}
            //else if (mySelection == "daten speicher")
            //{
            //    //tu was => daten sollen gesichert werden
            //}
        }

        static int EineMethode(string something)
        {
            var isValid = true;


        }
    }
}
