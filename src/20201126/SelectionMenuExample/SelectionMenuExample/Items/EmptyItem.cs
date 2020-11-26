using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class EmptyItem : IMenuItem
    {
        public EmptyItem()
        {
            //nothing to do
        }

        public string Description
        {
            get { return string.Empty; }
        }

        public ConsoleKey Code
        {
            get { return ConsoleKey.Spacebar; }
        }

        public void Display(int width)
        {
            Console.WriteLine();            
        }
    }
}
