using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditorUI.Annotations;

namespace Wifi.PlaylistEditorUI.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        private IPlaylist _playlist;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IRepositoryFactory _repositoryFactory;


        public PlaylistViewModel(IPlaylist playlist, 
                                 IPlaylistItemFactory playlistItemFactory,
                                 IRepositoryFactory repositoryFactory)
        {
            _playlist = playlist;

            _playlistItemFactory = playlistItemFactory;
            _repositoryFactory = repositoryFactory;
        }

        public IPlaylist Playlist => _playlist;

        public IEnumerable<PlaylistItemViewModel> Items {
            get
            {
                var itemList = new List<PlaylistItemViewModel>();

                if (_playlist == null)
                {
                    return itemList;
                }

                foreach (var playlistItem in _playlist.Items)
                {
                    var vmItem = new PlaylistItemViewModel
                    {
                        Tag = playlistItem,
                        Thumbnail = playlistItem.Thumbnail
                    };

                    itemList.Add(vmItem);
                }

                return itemList;
            }
        }

        public string CreatedAt => $"Erstellt am: {_playlist?.CreatedAt.ToShortDateString()}";

        public string Author
        {
            get { return $"Autor: {_playlist?.Author}"; }
            set
            {
                _playlist.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public string Name
        {
            get { return _playlist?.Name; }
            set
            {
                _playlist.Author = value;
                OnPropertyChanged("Name");
            }
        }

        public string Duration => $"Gesamte Spieldauer: {_playlist?.Duration}";


        public string Count => $"Anzahl Elemente: {_playlist?.Count}";
        

        public void AddItem(string filePath)
        {
            var item = _playlistItemFactory.Create(filePath);
            if (item == null)
            {
                return;
            }
            _playlist.Add(item);

            OnPropertyChanged("Items");
            OnPropertyChanged("Duration");
            OnPropertyChanged("Count");
        }

        public void Removetem(IPlaylistItem playlistItem)
        {
            _playlist.Remove(playlistItem);

            OnPropertyChanged("Items");
            OnPropertyChanged("Duration");
            OnPropertyChanged("Count");
        }

        public void ClearAllItems()
        {
            _playlist.ClearAllItems();

            OnPropertyChanged("Items");
            OnPropertyChanged("Duration");
            OnPropertyChanged("Count");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
