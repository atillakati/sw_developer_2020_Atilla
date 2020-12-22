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
    public class WplRepository : IRepository
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public WplRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }

        public string Extension => ".wpl";

        public string Description => "Windows Playlist file";

        public IPlaylist Load(string filePath)
        {
            IPlaylist playlist = null;            
            WplPlaylist wplplaylistBase = null;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return null;
            }
            
            //open file and read content
            using (StreamReader sr = new StreamReader(filePath))
            {
                WplContent content = new WplContent();
                wplplaylistBase = content.GetFromStream(sr.BaseStream);
            }

            wplplaylistBase.Path = filePath;

            //map to IPlaylist type
            playlist = MapToDomain(wplplaylistBase);

            return playlist;
        }

        public void Save(string filePath, IPlaylist playlist)
        {
            WplPlaylist wplPlaylist = null;

            //map to entity
            wplPlaylist = MapToEntity(playlist);

            WplContent content = new WplContent();
            string text = content.ToText(wplPlaylist);

            //write into file
            using(StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }

            return;
        }

        private WplPlaylist MapToEntity(IPlaylist playlist)
        {
            WplPlaylist wplPlaylist = new WplPlaylist();
            //wplPlaylist.IsExtended = true;            

            //wplPlaylist.Comments.Add($"PLAYLIST-Author:{playlist.Author}");
            //wplPlaylist.Comments.Add($"PLAYLIST-Title:{playlist.Name}");
            //wplPlaylist.Comments.Add($"PLAYLIST-CreatedAt:{playlist.CreatedAt.ToShortDateString()}");

            foreach (var item in playlist.Items)
            {
                var entry = new WplPlaylistEntry()
                {
                    //AlbumArtist = item.Artist,
                    Duration = item.Duration,
                    Path = item.Path,                    
                };

                wplPlaylist.PlaylistEntries.Add(entry);
            }
            
            return wplPlaylist;
        }

        private IPlaylist MapToDomain(WplPlaylist wplplaylistBase)
        {
            IPlaylist playlist = null;


            //get all comments
            var commentList = new List<string>();

            //get meta data
            var author = GetValueFromComment("PLAYLIST-Author", commentList, "NoName");
            var title = GetValueFromComment("PLAYLIST-Title", commentList, Path.GetFileNameWithoutExtension(wplplaylistBase.Path));
            var createdAt = GetValueFromComment("PLAYLIST-CreatedAt", commentList, File.GetCreationTime(wplplaylistBase.Path).ToShortDateString());

            //get item paths
            List<string> paths = wplplaylistBase.GetTracksPaths();

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

        private IEnumerable<string> ExtractAllComments(IEnumerable<WplPlaylistEntry> playlistEntries)
        {
            List<string> commentList = new List<string>();

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
