using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileIdentifier> KnownTypes { get; }

        IRepository Create(string playlistPath);
    }
}
