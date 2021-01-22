namespace Wifi.PlaylistEditor.Types
{
    public interface INewPlaylistCreator
    {
        string Author { get; }
        string Title { get; }

        bool StartDialog();
    }
}