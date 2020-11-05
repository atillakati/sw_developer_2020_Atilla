using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koordinaten_8
{
    class Program
    {
        ////Eingabe einer Koordinat
        ////#################################################################
        //static void Main(string[] args)
        //{
        //    bool userInputIsValid = false;
        //    int maxWidth = Console.WindowWidth - 1;
        //    int maxLength = Console.WindowHeight - 1;
        //    int xPos = 0;
        //    int yPos = 0;

        //    do
        //    {
        //        try
        //        {
        //            Console.Write("Geben Sie die X-Koordinate ein: ");
        //            xPos = int.Parse(Console.ReadLine());

        //            Console.Write("Geben Sie die Y-Koordinate ein: ");
        //            yPos = int.Parse(Console.ReadLine());

        //            userInputIsValid = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"ERROR: {ex.Message}");
        //            userInputIsValid = false;
        //        }

        //        //check the values
        //        if (xPos > maxWidth || xPos < 0 || yPos > maxLength || yPos < 0)
        //        {
        //            Console.WriteLine("ERROR: Leider sind diese Eingaben ungültig!");
        //            userInputIsValid = false;
        //        }

        //    } while (!userInputIsValid);

        //    //display point
        //    Console.SetCursorPosition(xPos, yPos);
        //    Console.Write("X");
        //    Console.SetCursorPosition(0, maxLength);
        //}

        //Eingabe mehrerer Koordinaten
        //#################################################################
        static void Main(string[] args)
        {
            bool userInputIsValid = false;
            int maxWidth = Console.WindowWidth - 1;
            int maxLength = Console.WindowHeight - 1;
            int pointCount = 0;
            int xPos = 0;
            int yPos = 0;
            Point[] myPointList;

            //get count of points
            Console.Write("Anzahl der Punkte definieren: ");
            pointCount = int.Parse(Console.ReadLine());

            //init points array
            myPointList = new Point[pointCount];

            //get all points
            for (int i = 0; i < pointCount; i++)
            {
                Console.WriteLine("Punkt {0}", i+1);

                do
                {
                    try
                    {
                        Console.Write("\tX-Koordinate ein: ");
                        myPointList[i].X_Pos = int.Parse(Console.ReadLine());

                        Console.Write("\tY-Koordinate ein: ");
                        myPointList[i].Y_Pos = int.Parse(Console.ReadLine());

                        userInputIsValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                        userInputIsValid = false;
                    }

                    //check the values
                    if (xPos > maxWidth || xPos < 0 || yPos > maxLength || yPos < 0)
                    {
                        Console.WriteLine("ERROR: Leider sind diese Eingaben ungültig!");
                        userInputIsValid = false;
                    }

                } while (!userInputIsValid);
            }

            //setup a sign for all points
            for (int i = 0; i < myPointList.Length; i++)
            {
                myPointList[i].Sign = 'X';
            }

            //display points
            Console.Clear();
            foreach (Point p in myPointList)
            {
                Console.SetCursorPosition(p.X_Pos, p.Y_Pos);
                Console.Write(p.Sign);
            }
            
            Console.SetCursorPosition(0, maxLength);
        }
    }
}
