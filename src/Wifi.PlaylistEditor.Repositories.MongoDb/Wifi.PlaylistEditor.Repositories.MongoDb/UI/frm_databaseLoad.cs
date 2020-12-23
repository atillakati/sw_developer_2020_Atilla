using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Wifi.PlaylistEditor.Repositories.MongoDb.Core;


namespace Wifi.PlaylistEditor.Repositories.MongoDb.UI
{
    public partial class frm_databaseLoad : Form, IDatabaseLoadDialog
    {
        private IEnumerable<string> _playlistNames;
        private string _selectedPlaylistName;

        public frm_databaseLoad()
        {
            InitializeComponent();

            _playlistNames = null;
            _selectedPlaylistName = string.Empty;
        }

        #region IDatabaseLoadDialog implementation
        public string SelectedPlaylistName 
        { 
            get => _selectedPlaylistName; 
        }

        public DialogResult ShowDialog(IEnumerable<string> playlistNames)
        {
            _playlistNames = playlistNames;
            _selectedPlaylistName = string.Empty;

            return ShowDialog();
        }
        #endregion

        #region private Methods
        private void frm_databaseLoad_Load(object sender, EventArgs e)
        {
            lst_playlist.Items.Clear();
            lst_playlist.Items.AddRange(_playlistNames.ToArray());
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _selectedPlaylistName = lst_playlist.SelectedItem.ToString();

            Close();
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _selectedPlaylistName = string.Empty;

            Close();
        }

        private void lst_playlist_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _selectedPlaylistName = lst_playlist.SelectedItem.ToString();

            Close();
        }
        #endregion

    }
}
