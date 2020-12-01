using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class MenuItem<T> : IMenuItemWithUpdateableSelectable<T>
    {
        private string _description;
        private ConsoleKey _code;
        private bool _selectable;
        private bool _visible;
        private Action<T> _action;


        public MenuItem(string description, ConsoleKey code, Action<T> action)
        {
            _description = description;
            _code = code;
            _action = action;

            _visible = true;
            _selectable = true;
        }
        
        public string Description
        {
            get { return _description; }
        }

        public ConsoleKey Code
        {
            get { return _code; }
        }

        public bool Selectable
        {
            get { return _selectable; }           
        }

        public bool Visible 
        {
            get { return _visible; }
            set { _visible = value; } 
        }

        public virtual void Display(int width)
        {
            //Daten laden...............L
            //Program beenden...........Q
            if (_visible)
            {
                Console.WriteLine($"{_description} {new string('.', width - _description.Length)} {_code}");
            }
        }

        public void Execute(T executionParameter)
        {
            if (_action != null)
            {
                _action(executionParameter);
            }
        }

        public void UpdateSelectable(bool newValue)
        {
            _selectable = newValue;
        }
    }
}
