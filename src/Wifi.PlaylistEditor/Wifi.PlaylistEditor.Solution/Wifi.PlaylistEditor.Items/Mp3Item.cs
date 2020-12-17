using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items
{
    public class Mp3Item : IPlaylistItem
    {
        private string _title;
        private TimeSpan _duration;
        private string _artist;
        private string _filePath;
        private Image _thumbnail;

        public Mp3Item(string filePath)
        {
            _filePath = filePath;

            if (string.IsNullOrWhiteSpace(_filePath) || !File.Exists(_filePath))
            {
                InitFieldsWithEmpty();
            }
            else
            {
                ReadIdv3TagsFromFile();
            }
        }

        private void InitFieldsWithEmpty()
        {
            _artist = string.Empty;
            _duration = TimeSpan.Zero;
            _thumbnail = null;
            _title = "--[File not found]--";
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }
        public string Artist
        {
            get => _artist;
            set => _artist = value;
        }
        public TimeSpan Duration
        {
            get => _duration;
            set => _duration = value;
        }
        public string Path
        {
            get => _filePath;
            set => _filePath = value;
        }
        public Image Thumbnail
        {
            get => _thumbnail;
            set => _thumbnail = value;
        }

        public override string ToString()
        {
            return $"{_artist} - {_title}";
        }

        private void ReadIdv3TagsFromFile()
        {
            var tfile = TagLib.File.Create(_filePath);

            _title = tfile.Tag.Title;
            _duration = tfile.Properties.Duration;
            _artist = tfile.Tag.FirstPerformer;

            if (tfile.Tag.Pictures != null && tfile.Tag.Pictures.Length > 0)
            {
                //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                _thumbnail = Image.FromStream(new MemoryStream(tfile.Tag.Pictures[0].Data.Data));
            }
            else
            {
                _thumbnail = null;
                Debug.WriteLine($"{System.IO.Path.GetFileName(_filePath)}: No Image stream found.");
            }
        }
    }
}
