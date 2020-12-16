
namespace Wifi.PlaylistEditor.Forms
{
    partial class frm_databaseLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_playlist = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.btt_ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_playlist
            // 
            this.lst_playlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_playlist.FormattingEnabled = true;
            this.lst_playlist.ItemHeight = 16;
            this.lst_playlist.Location = new System.Drawing.Point(14, 88);
            this.lst_playlist.Name = "lst_playlist";
            this.lst_playlist.Size = new System.Drawing.Size(510, 180);
            this.lst_playlist.TabIndex = 0;
            this.lst_playlist.DoubleClick += new System.EventHandler(this.lst_playlist_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wählen Sie aus zum Laden:";
            // 
            // btt_cancel
            // 
            this.btt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btt_cancel.Location = new System.Drawing.Point(437, 290);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(87, 27);
            this.btt_cancel.TabIndex = 2;
            this.btt_cancel.Text = "Abbruch";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click);
            // 
            // btt_ok
            // 
            this.btt_ok.Location = new System.Drawing.Point(343, 290);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(87, 27);
            this.btt_ok.TabIndex = 3;
            this.btt_ok.Text = "Laden";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 54);
            this.panel1.TabIndex = 4;
            // 
            // frm_databaseLoad
            // 
            this.AcceptButton = this.btt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btt_cancel;
            this.ClientSize = new System.Drawing.Size(539, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btt_ok);
            this.Controls.Add(this.btt_cancel);
            this.Controls.Add(this.lst_playlist);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_databaseLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlist aus Datenbank laden";
            this.Load += new System.EventHandler(this.frm_databaseLoad_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_playlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Panel panel1;
    }
}