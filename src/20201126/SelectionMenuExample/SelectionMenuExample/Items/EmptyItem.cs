using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class EmptyItem<T> : IMenuItem<T>
    {
        private bool _selectable;
        private bool _visible;

        public EmptyItem()
        {
            _selectable = false;
            _visible = true;
        }

        public string Description
        {
            get { return string.Empty; }
        }

        public ConsoleKey Code
        {
            get { return ConsoleKey.Spacebar; }
        }

        public bool Selectable 
        { 
            get { return _selectable; }
            //set 
            //{
            //    _selectable = false;
            //    Debug.WriteLine("Selectable für EmptyItem wird immer auf false gesetzt.");
            //}
        }
        public bool Visible 
        {
            get { return _visible; }
            set { _visible = value; } 
        }

        public void Display(int width)
        {
            if (_visible)
            {
                Console.WriteLine();
            }
        }

        public void Execute(T executionParameter)
        {
            throw new NotImplementedException();
        }
    }
}
