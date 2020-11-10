using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WertUndVerweisTypen
{
    class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book();

            myBook.Title = "Die unendliche Geschichte";
            myBook.Author = "Michael Ende";
            myBook.Price = 15.99m;

            //das Buch kopieren
            Book dummyBook = null;
            Book myNewBook = myBook;
            
            bool erg = myBook == myNewBook;
            Console.WriteLine($"Ergebnis Vergleich: {erg}");

            //das Buch ändern
            myBook.Title = "Vom Mythos des Mann-Monats";

            DisplayBookInfos(dummyBook);
            DisplayBookInfos(myBook);
            Console.WriteLine($"Ausgabe im Main(): {myBook.Title}");

            //DisplayBookInfos(myNewBook);
        }

        static void DisplayBookInfos(Book bookToDisplay)
        {            
            Console.WriteLine($"'{bookToDisplay.Title.ToUpper()}' von {bookToDisplay.Author} => EUR {bookToDisplay.Price}");

            bookToDisplay.Title = "[Modified] " + bookToDisplay.Title;
        }
    }
}
