using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class ColoredMenuItem<T> : MenuItem<T>
    {
        private ConsoleColor _itemColor;

        public ColoredMenuItem(string description, ConsoleKey code, ConsoleColor itemColor, Action<T> action)
            :base(description, code, action)
        {
            _itemColor = itemColor;
        }

        public ConsoleColor ItemColor
        {
            get { return _itemColor; }
        }

        public override void Display(int width)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = _itemColor;

            base.Display(width);

            Console.ForegroundColor = oldColor;            
        }
    }
}
