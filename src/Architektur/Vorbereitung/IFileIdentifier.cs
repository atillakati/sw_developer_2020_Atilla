using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public interface IFileIdentifier
    {
        /// <summary>
        /// Definiert die Dateinamenerweiterung für eine Datei
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Liefert beschreibende Informationen zu einem Dateiformat
        /// </summary>
        string Description { get; }
    }
}
