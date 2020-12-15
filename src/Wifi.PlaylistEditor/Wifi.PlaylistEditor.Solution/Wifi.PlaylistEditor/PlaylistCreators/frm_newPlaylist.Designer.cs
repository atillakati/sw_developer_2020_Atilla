namespace Wifi.PlaylistEditor
{
    partial class frm_newPlaylist
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
            this.btt_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btt_ok
            // 
            this.btt_ok.Location = new System.Drawing.Point(142, 167);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(87, 27);
            this.btt_ok.TabIndex = 0;
            this.btt_ok.Text = "OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titel: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Autor:";
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(71, 75);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(252, 21);
            this.txt_title.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 54);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bitte Playlist Details eingeben:";
            // 
            // txt_author
            // 
            this.txt_author.Location = new System.Drawing.Point(71, 108);
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(252, 21);
            this.txt_author.TabIndex = 5;
            // 
            // btt_cancel
            // 
            this.btt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btt_cancel.Location = new System.Drawing.Point(237, 167);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(87, 27);
            this.btt_cancel.TabIndex = 6;
            this.btt_cancel.Text = "Abbruch";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click);
            // 
            // frm_newPlaylist
            // 
            this.AcceptButton = this.btt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btt_cancel;
            this.ClientSize = new System.Drawing.Size(350, 208);
            this.Controls.Add(this.btt_cancel);
            this.Controls.Add(this.txt_author);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btt_ok);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_newPlaylist";
            this.Text = "Playlist Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_author;
        private System.Windows.Forms.Button btt_cancel;
    }
}