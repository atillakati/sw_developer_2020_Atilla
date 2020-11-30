using System;

namespace SelectionMenuExample
{
    public interface IMenuItem
    {
        string Description { get; }
        ConsoleKey Code { get; }

        bool Selectable { get; }
        bool Visible { get; set; }

        void Display(int width);
    }

    public interface IMenuItemWithUpdateableSelectable : IMenuItem
    {
        void UpdateSelectable(bool newValue);
    }
}