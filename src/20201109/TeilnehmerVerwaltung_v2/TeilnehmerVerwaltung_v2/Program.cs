using System;
using System.IO;

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
            meineTeilnehmer = ReadTeilnehmerData(teilnehmerCount);

            //Teilnehmerdaten ausgeben
            DisplayTeilnehmerData(meineTeilnehmer);

            //Teilnehmerdaten optional als Datei sichern
            SaveDataToFile(meineTeilnehmer);
        }

        static void SaveDataToFile(Teilnehmer[] meineTeilnehmer)
        {
            string userInput = ConsoleTools.GetString("Wollen Sie die Daten in einer Datei sichern (j/n)?");
            if (userInput.ToLower() == "j")
            {
                string fileName = ConsoleTools.GetString("Dateiname: ");
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    try
                    {
                        SaveData(fileName, meineTeilnehmer);
                        Console.WriteLine($"Daten wurden in die Datei {fileName} geschrieben.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Daten konnten nicht gesichert werden.");
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            }            
        }

        static void SaveData(string fileName, Teilnehmer[] meineTeilnehmer)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                foreach (Teilnehmer t in meineTeilnehmer)
                {                    
                    sw.WriteLine($"{t.Vorname}, {t.Nachname}, {t.Strasse}, {t.HausNr}, {t.Plz}, {t.Ort}, {t.Geburtsdatum}");
                }
            }
        }

        static void DisplayTeilnehmerData(Teilnehmer[] meineTeilnehmer)
        {
            foreach (Teilnehmer t in meineTeilnehmer)
            {
                Console.WriteLine($"{t.Vorname} {t.Nachname} [{t.Geburtsdatum.Year}] - {t.Plz} {t.Ort}");
            }
        }

        static Teilnehmer[] ReadTeilnehmerData(int teilnehmerCount)
        {
            Teilnehmer[] myTempDataList = new Teilnehmer[teilnehmerCount];

            for (int i = 0; i < teilnehmerCount; i++)
            {
                Console.WriteLine($"\nBitte Daten für Teilnehmer {i+1} eingeben:");

                myTempDataList[i].Vorname = ConsoleTools.GetString("\tVorname: ");
                myTempDataList[i].Nachname = ConsoleTools.GetString("\tNachname: ");

                myTempDataList[i].Strasse = ConsoleTools.GetString("\tStrasse: ");
                myTempDataList[i].HausNr = ConsoleTools.GetString("\tHausNr: ");
                myTempDataList[i].Ort = ConsoleTools.GetString("\tOrt: ");
                myTempDataList[i].Plz = ConsoleTools.GetInt("\tPlz: ");

                myTempDataList[i].Geburtsdatum = ConsoleTools.GetDateTime("\tGeburtsdatum: ");
            }

            return myTempDataList;
        }
    }
}
