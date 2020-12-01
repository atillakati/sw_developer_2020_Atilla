using System;

namespace SelectionMenuExample
{
    public interface IMenuItem<T>
    {
        string Description { get; }
        ConsoleKey Code { get; }

        bool Selectable { get; }
        bool Visible { get; set; }

        void Display(int width);

        void Execute(T executionParameter);
    }
}