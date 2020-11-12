using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenKapselung
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto car = new Auto();

            car.DisplayInfos();

            for (int i = 0; i < 5; i++)
            {
                car.SpeedUp(45);
                car.DisplayInfos();
            }

            car.SpeedUp(50);

            Console.WriteLine($"{car.Type}: {car.CurrentSpeed}/{car.MaxSpeed} km/h");

            car.SpeedUp(car.CurrentSpeed * -1);
            car.DisplayInfos();

            while (car.CurrentSpeed < 100)
            {
                car.SpeedUp(10);
                Console.WriteLine($"{car.Type}: {car.CurrentSpeed}/{car.MaxSpeed} km/h");            
            }            
        }
    }
}
