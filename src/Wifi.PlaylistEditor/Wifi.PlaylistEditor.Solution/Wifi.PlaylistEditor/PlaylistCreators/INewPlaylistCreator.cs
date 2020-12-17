using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public interface INewPlaylistCreator
    {
        string Author { get; }
        string Title { get; }

        DialogResult StartDialog();
    }
}