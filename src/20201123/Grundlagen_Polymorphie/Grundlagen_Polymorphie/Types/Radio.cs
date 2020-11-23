using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Polymorphie.Types
{
    public class Radio
    {
        private double _frequency;
        private int _volume;
        private Power _powerState;

        public Radio()
        {
            _frequency = 90.5;
            _volume = 3;
            _powerState = Power.Off;
        }

        public Power PowerState
        {
            get { return _powerState; }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                //ToDo: Limit possible values between 0-10!
                _volume = value;
            }
        }

        public double Frequency
        {
            get { return _frequency; }
            set
            {
                //ToDo: Limit possible values between 86.0 - 102.0 (FM Band)
                _frequency = value;
            }
        }


        public string GetInfoString()
        {
            return $"State: {_powerState} | Freq: {_frequency} MHz | Volume: {_volume}";
        }

        public void SetPowerState(Power newPowerState)
        {
            _powerState = newPowerState;

            //ToDo: Macht euch Gedanken darüber, welche Status wann übernommen werden dürfen. => Umsetzen!

            switch (newPowerState)
            {
                case Power.On:
                    Console.WriteLine("Radio macht nun Musik: " + GetInfoString());
                    break;
                case Power.Off:
                    Console.WriteLine("Radio ist aus.");
                    break;
                case Power.Suspend:
                    Console.WriteLine("Bis bald: " + GetInfoString());
                    break;
                default:
                    break;
            }
        }
    }
}
