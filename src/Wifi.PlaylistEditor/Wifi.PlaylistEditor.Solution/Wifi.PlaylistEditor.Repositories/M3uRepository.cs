using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IRepository
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }

        public string Extension => ".mp3";

        public string Description => "Music files";

        public IPlaylist Load(string filePath)
        {
            IPlaylist playlist = null;
            IBasePlaylist playlistBase = null;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return null;
            }

            //open file and read content
            using (StreamReader sr = new StreamReader(filePath))
            {
                var parser = PlaylistParserFactory.GetPlaylistParser(Extension);
                playlistBase = parser.GetFromStream(sr.BaseStream);
            }            
            
            M3uPlaylist m3uplaylistBase = playlistBase as M3uPlaylist;
            if(m3uplaylistBase == null)
            {
                return null;
            }

            //map to IPlaylist type
            playlist = MapToDomain(m3uplaylistBase);

            return playlist;
        }

        public void Save(string filePath, IPlaylist playlist)
        {
            M3uPlaylist m3uPlaylist = null;

            //map to entity
            m3uPlaylist = MapToEntity(playlist);

            M3uContent content = new M3uContent();
            string text = content.ToText(m3uPlaylist);

            //write into file
            using(StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }

            return;
        }

        private M3uPlaylist MapToEntity(IPlaylist playlist)
        {
            M3uPlaylist m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            foreach (var item in playlist.Items)
            {
                var entry = new M3uPlaylistEntry()
                {
                    AlbumArtist = item.Artist,
                    Duration = item.Duration,
                    Path = item.Path,
                    Title = item.Title,
                };

                m3uPlaylist.PlaylistEntries.Add(entry);
            }

            m3uPlaylist.Comments.Add($"#Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"#Title:{playlist.Name}");
            m3uPlaylist.Comments.Add($"#CreatedAt:{playlist.CreatedAt.ToShortDateString()}");

            return m3uPlaylist;
        }

        private IPlaylist MapToDomain(M3uPlaylist m3uplaylistBase)
        {
            IPlaylist playlist = null;

            //get meta data
            var author = GetValueFromComment("Author", m3uplaylistBase.Comments, "NoName");
            var title = GetValueFromComment("Title", m3uplaylistBase.Comments, Path.GetFileNameWithoutExtension(m3uplaylistBase.Path));
            var createdAt = GetValueFromComment("CreatedAt", m3uplaylistBase.Comments, File.GetCreationTime(m3uplaylistBase.Path).ToShortDateString());

            //get item paths
            List<string> paths = m3uplaylistBase.GetTracksPaths();

            //create playlist and add items
            playlist = new Playlist(title, author, DateTime.Parse(createdAt));
            foreach (var itemPath in paths)
            {
                var playlistItem = _playlistItemFactory.Create(itemPath);
                if (playlistItem != null)
                {
                    playlist.Add(playlistItem);
                }
            }

            return playlist;
        }

        private string GetValueFromComment(string key, IEnumerable<string> comments, string defaultValue)
        {
            return defaultValue;
        }      
    }
}
