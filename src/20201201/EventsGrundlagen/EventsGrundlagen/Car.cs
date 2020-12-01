using System;

namespace EventsGrundlagen
{
    public delegate void CarExplodedHandler(int currentSpeed, int maxSpeed);

    public class Car
    {
        private string _description;
        private int _maxSpeed;
        private int _currentSpeed;
        private State _state;

        public event CarExplodedHandler CarExploded;

        public Car(string description, int maxSpeed)
        {
            _description = description;
            _maxSpeed = maxSpeed;

            _state = State.Normal;
            _currentSpeed = 0;
        }

        public State State
        {
            get { return _state; }            
        }
        
        public void SpeedUp(int delta)
        {
            _currentSpeed += delta;

            if (_currentSpeed > _maxSpeed)
            {
                _state = State.Exploded;

                //Ereignis abfeuern => Microsoft Event Pattern
                if (CarExploded != null)
                {
                    CarExploded(_currentSpeed, _maxSpeed);
                }
            }
        }

        public override string ToString()
        {
            return $"{_description} = [{_state}] | {_currentSpeed}/{_maxSpeed} km/h";
        }
    }
}