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

        public string Extension => ".m3u";

        public string Description => "Music files";

        public IPlaylist Load(string filePath)
        {
            IPlaylist playlist = null;            
            M3uPlaylist m3uplaylistBase = null;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return null;
            }
            
            //open file and read content
            using (StreamReader sr = new StreamReader(filePath))
            {
                M3uContent content = new M3uContent();
                m3uplaylistBase = content.GetFromStream(sr.BaseStream);
            }

            m3uplaylistBase.Path = filePath;

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

            m3uPlaylist.Comments.Add($"PLAYLIST-Author:{playlist.Author}");
            m3uPlaylist.Comments.Add($"PLAYLIST-Title:{playlist.Name}");
            m3uPlaylist.Comments.Add($"PLAYLIST-CreatedAt:{playlist.CreatedAt.ToShortDateString()}");

            foreach (var item in playlist.Items)
            {
                var entry = new M3uPlaylistEntry()
                {
                    //AlbumArtist = item.Artist,
                    Duration = item.Duration,
                    Path = item.Path,
                    Title = item.Title,
                    Comments = new List<string>(),
                };

                m3uPlaylist.PlaylistEntries.Add(entry);
            }
            
            return m3uPlaylist;
        }

        private IPlaylist MapToDomain(M3uPlaylist m3uplaylistBase)
        {
            IPlaylist playlist = null;

            //get all comments
            var commentList = ExtractAllComments(m3uplaylistBase.PlaylistEntries);

            //get meta data
            var author = GetValueFromComment("PLAYLIST-Author", commentList, "NoName");
            var title = GetValueFromComment("PLAYLIST-Title", commentList, Path.GetFileNameWithoutExtension(m3uplaylistBase.Path));
            var createdAt = GetValueFromComment("PLAYLIST-CreatedAt", commentList, File.GetCreationTime(m3uplaylistBase.Path).ToShortDateString());

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

        private IEnumerable<string> ExtractAllComments(IEnumerable<M3uPlaylistEntry> playlistEntries)
        {
            List<string> commentList = new List<string>();

            foreach (var entry in playlistEntries)
            {
                if(entry.Comments != null && entry.Comments.Count > 0)
                {
                    commentList.AddRange(entry.Comments);
                }
            }

            return commentList;
        }

        private string GetValueFromComment(string key, IEnumerable<string> comments, string defaultValue)
        {
            foreach (var comment in comments)
            {
                if (comment.StartsWith(key))
                {
                    var parts = comment.Split(':');
                    if(parts.Length == 2)
                    {
                        return parts[1].Trim();
                    }
                }
            }

            return defaultValue;
        }      
    }
}
