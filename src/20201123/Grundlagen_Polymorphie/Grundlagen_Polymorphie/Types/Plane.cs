using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Polymorphie.Types
{
    public class Plane : Vehicle
    {
        private double _maxAltitude;
        private double _currentAltitude;

        public Plane(string model, string description, int maxSpeed, double maxAltitude)
            : base(model, description, maxSpeed)
        {
            _currentAltitude = 0.0;
            _maxAltitude = maxAltitude;
        }

        public double MaxAltitude
        {
            get { return _maxAltitude; }
        }

        public double CurrentAltitude
        {
            get { return _currentAltitude; }            
        }

        public void AddAltitude(double addAlt)
        {
            if (_maxAltitude > _currentAltitude + addAlt)
            {
                _currentAltitude += addAlt;                
            }
            else
            {
                Console.WriteLine($"Die maximale Flughöhe {_maxAltitude} darf nicht überschritten werden ! Aktuelle Höhe = {_currentAltitude}");                
            }            
        }


        public override string GetInfoString()
        {            
            string info = base.GetInfoString();
            info += $"\nmax. Altitude: {_maxAltitude}m current Altitude: {_currentAltitude}m";

            return info;
        }

    }
}
