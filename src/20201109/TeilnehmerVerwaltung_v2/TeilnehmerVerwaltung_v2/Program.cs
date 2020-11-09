using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.ToolLibrary.ConsoleIo;

namespace TeilnehmerVerwaltung_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Schreiben Sie eine einfache Applikation mit der Teilnehmer-Daten verwaltet 
             * werden können.
             * Teilnehmerdaten sollen:
             * 
             *  - Eingabe
             *  - tabellarische Ausgabe
             *  - Ausgabe in eine Text-Datei (wahlweise)
             * 
             * Welche Teilnehmerdaten:
             * 
             *   - TeilnehmerID (= Guid)
             *   - Name & Nachname
             *   - Strasse, HausNr, Plz, Ort
             *   - Geburtsdatum
             *   
             */

            int teilnehmerCount = 0;
            Teilnehmer[] meineTeilnehmer;

            //Anzahl einlesen
            teilnehmerCount = ConsoleTools.GetInt("Anzahl der Teilnehmer eingeben: ");            

            //Teilnehmerdaten einlesen
            meineTeilnehmer = TeilnehmerDatenEinlesen(teilnehmerCount);

            //Teilnehmerdaten ausgeben
            DisplayTeilnehmer(meineTeilnehmer);
        }

        static void DisplayTeilnehmer(Teilnehmer[] meineTeilnehmer)
        {
            foreach (Teilnehmer t in meineTeilnehmer)
            {
                Console.WriteLine($"{t.Vorname}, {t.Nachname}, {t.Geburtsdatum.Date}, {t.Plz}, {t.Ort}");
            }
        }

        static Teilnehmer[] TeilnehmerDatenEinlesen(int count)
        {
            Teilnehmer[] meineTeilnehmer = new Teilnehmer[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Daten für Teilnehmer {i+1} eingeben:");

                meineTeilnehmer[i].Vorname = ConsoleTools.GetString("\tVorname: ");
                meineTeilnehmer[i].Nachname = ConsoleTools.GetString("\tNachname: ");

                meineTeilnehmer[i].Strasse = ConsoleTools.GetString("\tStrasse: ");
                meineTeilnehmer[i].HausNr= ConsoleTools.GetString("\tHausnummer: ");
                meineTeilnehmer[i].Ort= ConsoleTools.GetString("\tOrt: ");
                meineTeilnehmer[i].Plz = ConsoleTools.GetInt("\tPlz: ");

                meineTeilnehmer[i].Geburtsdatum = ConsoleTools.GetDateTime("\tGeburtsdatum : ");
            }

            return meineTeilnehmer;
        }
    }
}
