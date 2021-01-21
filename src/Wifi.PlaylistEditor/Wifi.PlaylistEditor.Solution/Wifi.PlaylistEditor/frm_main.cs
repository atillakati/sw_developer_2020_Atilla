﻿using System;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Properties;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor
{
    public partial class frm_main : Form
    {
        private IPlaylist _playlist;
        private readonly INewPlaylistCreator _newPlaylistCreator;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        

        public frm_main(INewPlaylistCreator newPlaylistCreator,
                        IPlaylistItemFactory playlistItemFactory,
                        IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();

            _newPlaylistCreator = newPlaylistCreator;
            _playlistItemFactory = playlistItemFactory;
            _repositoryFactory = repositoryFactory;
        }

        private void NewPlaylistButton_Click(object sender, EventArgs e)
        {
            if (_newPlaylistCreator.StartDialog() != DialogResult.OK)
            {
                return;
            }

            var title = _newPlaylistCreator.Title;
            var author = _newPlaylistCreator.Author;

            //now create new playlist
            _playlist = new Playlist(title, author, DateTime.Now);

            //update view
            EnableItemCommands(true);
            DisplayPlaylistDetails(_playlist);
            DisplayPlaylistItems(_playlist);
        }

        private void DisplayPlaylistItems(IPlaylist playlist)
        {
            int index = 0;

            listView1.Items.Clear();
            imageList1.Images.Clear();

            foreach (var item in playlist.Items)
            {
                ListViewItem lvi = new ListViewItem(item.ToString());
                lvi.ImageIndex = index;
                lvi.Tag = item;

                if (item.Thumbnail != null)
                {
                    imageList1.Images.Add(item.Thumbnail);
                }
                else
                {
                    imageList1.Images.Add(Resources.no_image);
                }

                listView1.Items.Add(lvi);
                index++;
            }

            listView1.LargeImageList = imageList1;
        }

        private void DisplayPlaylistDetails(IPlaylist playlist)
        {
            lbl_playlistTitle.Text = playlist.Name;
            //Spielzeit: 00:15:12 | Autor: Max Mustermann
            lbl_playlistDetails.Text = $"Spielzeit: {playlist.Duration.ToString("hh\\:mm\\:ss")} | Autor: {playlist.Author}";
        }

        private void AddNewItemToPlaylist_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var file in openFileDialog1.FileNames)
            {
                var item = _playlistItemFactory.Create(file);
                if (item != null)
                {
                    _playlist.Add(item);
                }
            }

            //update view
            DisplayPlaylistDetails(_playlist);
            DisplayPlaylistItems(_playlist);
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            lbl_playlistTitle.Text = string.Empty;
            lbl_playlistDetails.Text = "Spielzeit: 00:00:00 | Autor: -";
            lbl_itemDetails.Text = string.Empty;

            EnableItemCommands(false);
        }

        private void EnableItemCommands(bool enabled)
        {
            toolStripButton3.Enabled = enabled;
            toolStripButton4.Enabled = enabled;
            toolStripButton5.Enabled = enabled;
            toolStripButton6.Enabled = enabled;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var playlistItem = GetSelectedPlaylistItem();
            if (playlistItem != null)
            {
                //Artist: Max Sänger | Titel: Cooler Song | Dauer: 00:05:25 | c:\temp\mySongs\coolerSong.mp3
                lbl_itemDetails.Text = $"Artist: {playlistItem.Artist} | Titel: {playlistItem.Title} " +
                                       $"| Dauer: {playlistItem.Duration.ToString("hh\\:mm\\:ss")} | {playlistItem.Path}";
            }
        }


        private IPlaylistItem GetSelectedPlaylistItem()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                return item.Tag as IPlaylistItem;
            }

            return null;
        }

        private void RemovePlaylistItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                var playlistItem = item.Tag as IPlaylistItem;
                if (playlistItem != null)
                {
                    _playlist.Remove(playlistItem);
                }
            }

            //update view
            DisplayPlaylistDetails(_playlist);
            DisplayPlaylistItems(_playlist);
        }

        private void ClearAllItems_Click(object sender, EventArgs e)
        {
            _playlist.ClearAllItems();

            //update view
            lbl_itemDetails.Text = string.Empty;
            DisplayPlaylistDetails(_playlist);
            DisplayPlaylistItems(_playlist);
        }

        private void SavePlaylistAsFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            IRepository repository = _repositoryFactory.Create(saveFileDialog1.FileName);
            if (repository != null)
            {
                repository.Save(saveFileDialog1.FileName, _playlist);
            }
        }

        private void LoadPlaylistFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            IRepository repository = _repositoryFactory.Create(openFileDialog1.FileName);
            if (repository != null)
            {
                _playlist = repository.Load(openFileDialog1.FileName);

                //update view
                lbl_itemDetails.Text = string.Empty;
                DisplayPlaylistDetails(_playlist);
                DisplayPlaylistItems(_playlist);

                EnableItemCommands(true);
            }
        }

        //private void SaveProjectIntoDB_Click(object sender, EventArgs e)
        //{
        //    _databaseRepository.Save(_playlist.Name, _playlist);
        //    MessageBox.Show("Playlist wurde gespeichert.", "Playlist Projekt sichern");
        //}

        //private void LoadProjectFormDb_Click(object sender, EventArgs e)
        //{
        //    //alle Playlist Dokumente laden
        //    var allPlaylistDocuments = _databaseRepository.LoadAll();

        //    if (allPlaylistDocuments == null)
        //    {
        //        MessageBox.Show("Keine Einträge in der Datenbank gefunden.", "Playlist Projekt laden");
        //        return;
        //    }

        //    //Auswahldialog mit Playlistnamen versorgen und anzeigen                
        //    var listWithPlaylistNames = allPlaylistDocuments.Select(x => x.Name);
        //    if (_databaseLoadDialog.ShowDialog(listWithPlaylistNames) != DialogResult.OK)
        //    {
        //        return;
        //    }

        //    //ein einzelnes Dokument über den Playlist Namen laden
        //    _playlist = _databaseRepository.Load(_databaseLoadDialog.SelectedPlaylistName);

        //    //update view
        //    lbl_itemDetails.Text = string.Empty;
        //    DisplayPlaylistDetails(_playlist);
        //    DisplayPlaylistItems(_playlist);

        //    EnableItemCommands(true);
        //}
    }
}
