using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditorUI
{
    public class DummyCreator : INewPlaylistCreator
    {
        public string Author => "Gandalf der Weise";

        public string Title => "Superplaylist Charts 2020";

        public bool StartDialog()
        {
            return true;
        }
    }
}
