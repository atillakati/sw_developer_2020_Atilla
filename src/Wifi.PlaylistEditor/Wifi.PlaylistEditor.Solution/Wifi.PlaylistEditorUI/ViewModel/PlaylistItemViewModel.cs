using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditorUI.ViewModel
{
    public class PlaylistItemViewModel
    {
        public Image Thumbnail { get; set; }

        public IPlaylistItem Tag { get; set; }
    }
}
