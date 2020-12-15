using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public class Playlist : IPlaylist
    {
        private string _name;
        private string _author;
        private DateTime _createdAt;
        private List<IPlaylistItem> _items;

        public Playlist(string name, string author, DateTime createdAt)
        {
            _name = name;
            _author = author;
            _createdAt = createdAt;

            _items = new List<IPlaylistItem>();
        }


        public IEnumerable<IPlaylistItem> Items
        {
            get { return _items; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TimeSpan Duration
        {
            get
            {
                TimeSpan duration = TimeSpan.Zero;

                foreach (var item in _items)
                {
                    duration = duration.Add(item.Duration);
                }

                return duration;
            }
        }

        public int Count
        {
            get => _items.Count;
        }


        public void Add(IPlaylistItem newItem)
        {
            _items.Add(newItem);
        }

        public void Remove(IPlaylistItem itemToRemove)
        {
            _items.Remove(itemToRemove);
        }

        public void ClearAllItems()
        {
            _items.Clear();
        }
    }
}
