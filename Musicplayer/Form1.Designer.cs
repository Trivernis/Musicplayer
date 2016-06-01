namespace Musicplayer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpen = new System.Windows.Forms.Button();
            this.listBoxSong = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.checkBoxOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxShuffle = new System.Windows.Forms.CheckBox();
            this.checkBoxUpload = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(622, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "öffnen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // listBoxSong
            // 
            this.listBoxSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSong.FormattingEnabled = true;
            this.listBoxSong.Location = new System.Drawing.Point(360, 41);
            this.listBoxSong.Name = "listBoxSong";
            this.listBoxSong.Size = new System.Drawing.Size(337, 199);
            this.listBoxSong.TabIndex = 5;
            this.listBoxSong.SelectedIndexChanged += new System.EventHandler(this.listBoxSong_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "mp3-Dateien|*.mp3|Playlist-Dateien|*.m3u|Alle Dateien|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(13, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(287, 182);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // checkBoxOutput
            // 
            this.checkBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxOutput.AutoSize = true;
            this.checkBoxOutput.Location = new System.Drawing.Point(12, 200);
            this.checkBoxOutput.Name = "checkBoxOutput";
            this.checkBoxOutput.Size = new System.Drawing.Size(111, 17);
            this.checkBoxOutput.TabIndex = 7;
            this.checkBoxOutput.Text = "Media Info Output";
            this.checkBoxOutput.UseVisualStyleBackColor = true;
            // 
            // checkBoxShuffle
            // 
            this.checkBoxShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShuffle.AutoSize = true;
            this.checkBoxShuffle.Location = new System.Drawing.Point(12, 223);
            this.checkBoxShuffle.Name = "checkBoxShuffle";
            this.checkBoxShuffle.Size = new System.Drawing.Size(59, 17);
            this.checkBoxShuffle.TabIndex = 8;
            this.checkBoxShuffle.Text = "Shuffle";
            this.checkBoxShuffle.UseVisualStyleBackColor = true;
            this.checkBoxShuffle.CheckedChanged += new System.EventHandler(this.checkBoxShuffle_CheckedChanged);
            // 
            // checkBoxUpload
            // 
            this.checkBoxUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxUpload.AutoSize = true;
            this.checkBoxUpload.Location = new System.Drawing.Point(129, 200);
            this.checkBoxUpload.Name = "checkBoxUpload";
            this.checkBoxUpload.Size = new System.Drawing.Size(76, 17);
            this.checkBoxUpload.TabIndex = 9;
            this.checkBoxUpload.Text = "uploadInfo";
            this.checkBoxUpload.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 261);
            this.Controls.Add(this.checkBoxUpload);
            this.Controls.Add(this.checkBoxShuffle);
            this.Controls.Add(this.checkBoxOutput);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.listBoxSong);
            this.Controls.Add(this.buttonOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ListBox listBoxSong;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.CheckBox checkBoxOutput;
        private System.Windows.Forms.CheckBox checkBoxShuffle;
        private System.Windows.Forms.CheckBox checkBoxUpload;
    }
}

