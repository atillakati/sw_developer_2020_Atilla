using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsGrundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCar = new Car("SuperCar VW", 220);

            myCar.CarExploded += MyCar_CarExploded;
            myCar.CarExploded += MyCar_CarExploded1;

            do
            {
                Console.WriteLine(myCar);
                myCar.SpeedUp(20);                
            }
            while (myCar.State != State.Exploded);


            //vom Ereignis abmelden
            //myCar.CarExploded -= MyCar_CarExploded;
        }

        private static void MyCar_CarExploded1(int currentSpeed, int maxSpeed)
        {
            Console.WriteLine("Hier noch tutaaaa!");
        }

        private static void MyCar_CarExploded(int currentSpeed, int maxSpeed)
        {
            Console.WriteLine("Leider ist das Auto nun explodiert.");
        }
    }
}
