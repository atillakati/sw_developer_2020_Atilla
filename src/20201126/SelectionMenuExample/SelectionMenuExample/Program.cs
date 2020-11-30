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
            IMenu myMenu = new Menu();

            //myMenu.LoadFromFile("menufile.txt");

            myMenu = CreateMenu();

            myMenu.Display(35);

            var mySelection = myMenu.SelectItem("Ihre Wahl: ");

            Console.WriteLine($"\nIhre Auswahl: {mySelection.Description}");
        }

        private static IMenu CreateMenu()
        {
            Menu myMenu = new Menu();

            myMenu.Add(new MenuItem("Daten laden", ConsoleKey.F1));
            myMenu.Add(new MenuItem("Daten speichern", ConsoleKey.F2));
            myMenu.Add(new SeperatorItem('~'));
            myMenu.Add(new MenuItem("Daten löschen", ConsoleKey.F3));
            myMenu.Add(new MenuItem("Daten drucken", ConsoleKey.F4));
            myMenu.Add(new EmptyItem());
            myMenu.Add(new ColoredMenuItem("Ende", ConsoleKey.Escape, ConsoleColor.Yellow));

            return myMenu;
        }

    }
}
