using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class SeperatorItem : MenuItem
    {
        private char _separator;

        public SeperatorItem(char separator) 
            :base(string.Empty, ConsoleKey.Spacebar)
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
