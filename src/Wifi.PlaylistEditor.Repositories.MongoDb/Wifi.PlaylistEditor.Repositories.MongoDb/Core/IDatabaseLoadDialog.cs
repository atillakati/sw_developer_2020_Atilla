using System.Collections.Generic;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Core
{
    public interface IDatabaseLoadDialog
    {
        DialogResult ShowDialog(IEnumerable<string> playlistNames);
        string SelectedPlaylistName { get; }
    }
}