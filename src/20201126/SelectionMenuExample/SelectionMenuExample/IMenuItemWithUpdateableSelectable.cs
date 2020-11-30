namespace SelectionMenuExample
{
    public interface IMenuItemWithUpdateableSelectable : IMenuItem
    {
        void UpdateSelectable(bool newValue);
    }
}