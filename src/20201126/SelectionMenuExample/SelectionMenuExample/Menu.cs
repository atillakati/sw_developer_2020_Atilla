using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionMenuExample
{
    public class Menu : IMenu
    {
        private List<IMenuItem> _items;

        public Menu()
        {
            _items = new List<IMenuItem>();
        }


        public int Count
        {
            get { return _items.Count; }
        }

        public void Add(IMenuItem menuItem)
        {
            _items.Add(menuItem);
        }

        public void Remove(IMenuItem menuItem)
        {
            _items.Remove(menuItem);
        }

        public void Display(int width)
        {
            foreach (var menuItem in _items)
            {
                menuItem.Display(width);
            }

            Console.WriteLine();
        }

        public IMenuItem SelectItem(string inputPrompt)
        {            
            while (true)
            {
                Console.Write(inputPrompt);
                var userInput = Console.ReadKey(true);

                foreach (var menuItem in _items)
                {
                    if (userInput.Key == menuItem.Code && menuItem.Selectable)
                    {
                        return menuItem;
                    }
                }

                Console.WriteLine("Ungültige Eingabe!");
            }
        }
    }
}
