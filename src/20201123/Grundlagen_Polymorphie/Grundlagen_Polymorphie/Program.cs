using Grundlagen_Polymorphie.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Polymorphie
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] myVehicleList = new Vehicle[]
            {
                new Vehicle(),
                new Vehicle("Badmobil", "Black Edition Super v2", 250),
                new Plane("F16", "Euro-Fighter Legal Edition", 2500, 20000.0),
                new Car("VW", "Rabbit Golf", 120)
            };

            ////Hauptprogramm
            //foreach (var vehicle in myVehicleList)
            //{
            //    Display(vehicle);
            //}

            Console.WriteLine(myVehicleList[3]);
        }

        private static void Display(Vehicle vehicle)
        {            
            Console.WriteLine(vehicle.GetInfoString());
            Console.WriteLine();
        }
    }
}
