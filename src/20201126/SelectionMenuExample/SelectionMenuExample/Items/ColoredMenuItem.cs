using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class ColoredMenuItem : MenuItem
    {
        private ConsoleColor _itemColor;

        public ColoredMenuItem(string description, char code, ConsoleColor itemColor)
            :base(description, code)
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
