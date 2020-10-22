using StrukturenGL.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrukturenGL.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            Teilnehmer einTeilnehmer = new Teilnehmer();

            int[] zahlen;
            string[] namen;
            Teilnehmer[] meineTeilnehmer;
            
            //Initialisierung
            einTeilnehmer.Vorname = "Max";
            einTeilnehmer.Nachname = "Musterman";
            einTeilnehmer.Geburtsdatum = new DateTime(1980, 4, 16);

            Console.WriteLine($"{einTeilnehmer.Vorname} {einTeilnehmer.Nachname}");
        }
    }
    
}
