using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public interface IFactory<T>
    {
        IEnumerable<IFileIdentifier> KnownTypes { get; }

        T Create(string filePath);
    }
}
