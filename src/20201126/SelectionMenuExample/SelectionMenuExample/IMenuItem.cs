using System;

namespace SelectionMenuExample
{
    public interface IMenuItem
    {
        string Description { get; }
        ConsoleKey Code { get; }

        bool Selectable { get; set; }
        bool Visible { get; set; }


        void Display(int width);
    }
}