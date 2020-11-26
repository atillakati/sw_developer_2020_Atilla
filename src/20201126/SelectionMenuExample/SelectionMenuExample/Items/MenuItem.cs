using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample.Items
{
    public class MenuItem : IMenuItem
    {
        private string _description;
        private char _code;

        public MenuItem(string description, char code)
        {
            _description = description;
            _code = code;
        }
        
        public string Description
        {
            get { return _description; }
        }

        public char Code
        {
            get { return _code; }
        }

        public virtual void Display(int width)
        {
            //Daten laden...............L
            //Program beenden...........Q
            Console.WriteLine($"{_description} {new string('.', width - _description.Length)} {_code}");
        }
    }
}
