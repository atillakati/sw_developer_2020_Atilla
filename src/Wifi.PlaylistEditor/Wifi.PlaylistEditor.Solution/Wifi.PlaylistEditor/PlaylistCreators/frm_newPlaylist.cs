using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public partial class frm_newPlaylist : Form
    {
        public frm_newPlaylist()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return txt_title.Text;
            }
        }

        public string Author
        {
            get => txt_author.Text;
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_title.Text) || string.IsNullOrWhiteSpace(txt_author.Text))
            {
                MessageBox.Show("Titel und Autor dürfen nicht leer sein!", "Fehleingabe", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
