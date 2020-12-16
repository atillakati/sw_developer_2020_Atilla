using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Core
{
    public interface IDatabaseRepository : IRepository
    {
        IEnumerable<IPlaylist> LoadAll();
    }
}
