using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class SeperatorItem<T> : MenuItem<T>
    {
        private char _separator;

        public SeperatorItem(char separator) 
            :base(string.Empty, ConsoleKey.Spacebar, null)
        {
            _separator = separator;
            UpdateSelectable(false);
        }

        public char Separator
        {
            get { return _separator; }
            set { _separator = value; }
        }

        public override void Display(int width)
        {
            if (Visible)
            {                
                Console.WriteLine(new string(_separator, width+4));
            }
        }
    }
}
