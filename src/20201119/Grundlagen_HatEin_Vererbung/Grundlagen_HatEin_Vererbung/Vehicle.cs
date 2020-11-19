using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_HatEin_Vererbung
{
    public class Vehicle
    {
        private string _model;
        private string _description;
        private int _maxSpeed;
        private VehicleState _state;

        public Vehicle()
        {
            _model = "2-Bike Forte";
            _description = "Fahrrad std. Unisex";
            _maxSpeed = 30;
            _state = VehicleState.Locked;
        }

        public Vehicle(string model, string description, int maxSpeed)
        {
            _model = model;
            _description = description;
            _maxSpeed = maxSpeed;

            _state = VehicleState.Locked;
        }


        public VehicleState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int MaxSpeed
        {
            get { return _maxSpeed; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string Model
        {
            get { return _model; }
        }


        public string GetInfoString()
        {
            return $"{_model}-{_description}\nMax. Speed: {_maxSpeed}km/h State: {_state}";
        }
        
        public void Drive()
        {
            if(_state == VehicleState.Unlocked)
            {
                Console.WriteLine($"Das Fahrzeug '{_model}' bewegt sich.");
            }
            else
            {
                Console.WriteLine($"FEHLER: Das Fahrzeug '{_model}' kann sich leider nicht bewegen!");
            }
        }
    }
}
