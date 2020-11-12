using System;
using Wifi.ToolLibrary.ConsoleIo;

namespace GrundlagenKapselung
{
    public class Auto
    {
        private string _type;
        private string _description;
        private int _maxSpeed;
        private int _currentSpeed;

        public Auto()
        {
            _type = "Opel Astra";
            _description = "Ein std. Fahrzeug für die Familie";
            _maxSpeed = 175;
            _currentSpeed = 0;
        }

        public Auto(string type, string description, int maxSpeed)
        {
            _type = type;
            _description = description;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;            
        }

        public Auto(string type, string description)
        {
            _type = type;
            _description = description;

            _maxSpeed = 175;
            _currentSpeed = 0;
        }       


        //Zugriffs- & Änderungsmethoden
        //public int GetCurrentSpeed()
        //{
        //    return CurrentSpeed;
        //}

        //public int GetMaxSpeed()
        //{
        //    return MaxSpeed;
        //}

        //public string GetTypeString()
        //{
        //    return Type;
        //}

        //public void SetTypeString(string newTypeString)
        //{
        //    if (!string.IsNullOrWhiteSpace(newTypeString))
        //    {
        //        Type = newTypeString;
        //    }
        //}

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _type = value;
                }
            }
        }

        public string Description
        {
            get
            {
                return _type;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _type = value;
                }
            }
        }
        
        public string TypeInfo
        {
            get
            {
                return _type + "/" + _description;
            }
        }

        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }            
        }        

        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }


        public void SpeedUp(int delta)
        {
            if (_currentSpeed + delta > _maxSpeed || _currentSpeed + delta < 0)
            {
                ConsoleTools.DisplayColoredMessage($"ERROR: Die aktuelle Geschwindigkeit kann nicht um {delta} verändert werden.", ConsoleColor.Red);
                return;
            }

            //update current speed
            _currentSpeed += delta;
        }

        public void DisplayInfos()
        {
            ConsoleTools.DisplayColoredMessage($"{_type} - {_description}");
            ConsoleTools.DisplayColoredMessage($"Max. Speed: {_maxSpeed} km/h Current Speed: {_currentSpeed} km/h");
            Console.WriteLine();
        }
    }
}