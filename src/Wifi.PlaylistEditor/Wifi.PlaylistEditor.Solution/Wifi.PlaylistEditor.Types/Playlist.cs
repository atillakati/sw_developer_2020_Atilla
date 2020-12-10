using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public class Playlist
    {
        private string _name;
        private string _author;
        private DateTime _createdAt;
        private List<IPlaylistItem> _items;

        public Playlist()
        {

        }


        public IEnumerable<IPlaylistItem> Items
        {
            get { return _items; }            
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }            
        }

        public string  Author
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

                if (_items != null)
                {                    
                    foreach (var item in _items)
                    {
                        duration = duration.Add(item.Duration);
                    }                    
                }

                return duration;
            }
        }

    }
}
