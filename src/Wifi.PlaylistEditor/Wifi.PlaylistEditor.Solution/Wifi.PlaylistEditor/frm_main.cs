using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Items;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor
{
    public partial class frm_main : Form
    {
        private IPlaylist _playlist;

        public frm_main()
        {
            InitializeComponent();
        }

        private void NewPlaylistButton_Click(object sender, EventArgs e)
        {
            frm_newPlaylist newPlaylistDialog = new frm_newPlaylist();

            if(newPlaylistDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var title = newPlaylistDialog.Title;
            var author = newPlaylistDialog.Author;

            //now create new playlist
            _playlist = new Playlist(title, author, DateTime.Now);

            //update view
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
                imageList1.Images.Add(item.Thumbnail);

                listView1.Items.Add(lvi);
                index++;
            }

            listView1.LargeImageList = imageList1;            
        }

        private void DisplayPlaylistDetails(IPlaylist playlist)
        {
            lbl_playlistTitle.Text = playlist.Name;
            //Spielzeit: 00:15:12 | Autor: Max Mustermann
            lbl_playlistDetails.Text = $"Spielzeit: {playlist.Duration} | Autor: {playlist.Author}";
        }

        private void AddNewItemToPlaylist_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var file in openFileDialog1.FileNames)
            {
                var item = new Mp3Item(file);
                _playlist.Add(item);
            }

            //update view
            DisplayPlaylistDetails(_playlist);
            DisplayPlaylistItems(_playlist);
        }
    }
}
