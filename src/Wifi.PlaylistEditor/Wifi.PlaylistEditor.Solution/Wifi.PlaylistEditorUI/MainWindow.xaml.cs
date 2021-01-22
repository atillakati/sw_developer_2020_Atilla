using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditorUI.ViewModel;

namespace Wifi.PlaylistEditorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INewPlaylistCreator _newPlaylistCreator;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        private PlaylistViewModel _playlistViewModel;

        public MainWindow(INewPlaylistCreator newPlaylistCreator, 
                          IPlaylistItemFactory playlistItemFactory,
                          IRepositoryFactory repositoryFactory)
        {
            _newPlaylistCreator = newPlaylistCreator;
            _playlistItemFactory = playlistItemFactory;
            _repositoryFactory = repositoryFactory;

            InitializeComponent();
            DataContext = new PlaylistViewModel(null, _playlistItemFactory, _repositoryFactory);
        }

        private void newDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_newPlaylistCreator.StartDialog())
            {
                return;
            }

            var playlist = new Playlist(_newPlaylistCreator.Title, _newPlaylistCreator.Author, DateTime.Now);
            _playlistViewModel = new PlaylistViewModel(playlist, _playlistItemFactory, _repositoryFactory);

            DataContext = null;
            DataContext = _playlistViewModel;
        }

        private void AddNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            foreach (var fileName in openFileDialog.FileNames)
            {
                _playlistViewModel.AddItem(fileName);
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in lst_items.SelectedItems)
            {
                if (selectedItem is PlaylistItemViewModel item)
                {
                    _playlistViewModel.Removetem(item.Tag);
                }
            }
        }

        private void ClearAllItemsButton_Click(object sender, RoutedEventArgs e)
        {
            _playlistViewModel.ClearAllItems();
        }
    }
}
