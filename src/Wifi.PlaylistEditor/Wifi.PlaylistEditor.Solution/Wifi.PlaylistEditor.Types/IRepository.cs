using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public interface IRepository : IFileIdentifier
    {
        void Save(string filePath, IPlaylist playlist);

        IPlaylist Load(string filePath);
    }
}
