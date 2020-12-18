using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    /// <summary>
    /// Interface to implement classes to load and save a IPlaylist document into a file
    /// </summary>
    public interface IRepository : IFileIdentifier
    {
        /// <summary>
        /// Writes the provided playlist data into the file in filePath
        /// </summary>
        /// <param name="filePath">The file to create</param>
        /// <param name="playlist">Playlist data to write into a file</param>
        void Save(string filePath, IPlaylist playlist);

        /// <summary>
        /// Loads the playlist data from provided file
        /// </summary>
        /// <param name="filePath">Filepath to load</param>
        /// <returns></returns>
        IPlaylist Load(string filePath);
    }
}
