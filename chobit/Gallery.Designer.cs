namespace eChobits {
    partial class Gallery {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gallery));
            this.lvGallery = new System.Windows.Forms.ListView();
            this.ilPics = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvGallery
            // 
            this.lvGallery.LargeImageList = this.ilPics;
            this.lvGallery.Location = new System.Drawing.Point(-1, 0);
            this.lvGallery.Name = "lvGallery";
            this.lvGallery.Size = new System.Drawing.Size(880, 474);
            this.lvGallery.TabIndex = 0;
            this.lvGallery.UseCompatibleStateImageBehavior = false;
            // 
            // ilPics
            // 
            this.ilPics.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilPics.ImageSize = new System.Drawing.Size(100, 100);
            this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Gallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 473);
            this.Controls.Add(this.lvGallery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Gallery";
            this.Text = "Gallery";
            this.Load += new System.EventHandler(this.Gallery_Load);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.ListView lvGallery;
        private System.Windows.Forms.ImageList ilPics;
    }
}