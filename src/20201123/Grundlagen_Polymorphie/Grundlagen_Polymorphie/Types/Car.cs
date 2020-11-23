using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Polymorphie.Types
{
    public class Car : Vehicle
    {
        //Erbt von Vehicle. Jede klasse bekommt 1 Property und 1 Methode zusätzlich
        private int _fuel;

        public Car(string model, string description, int maxSpeed) 
            : base(model, description, maxSpeed)
        {
            _fuel = 10;
        }

        public int Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }

        public string GetCarString()
        {
            return GetInfoString() + $" Tank: {_fuel.ToString()}%";
        }

        public override string GetInfoString()
        {
            return $"Fahrzeug: '{Model.ToUpper()}-{Description}' Aktueller Tankstatus: {_fuel}%";
        }
    }
}
