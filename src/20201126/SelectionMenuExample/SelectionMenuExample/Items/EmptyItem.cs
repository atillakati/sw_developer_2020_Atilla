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

        public char Code
        {
            get { return ' '; }
        }

        public void Display(int width)
        {
            Console.WriteLine();
        }
    }
}
