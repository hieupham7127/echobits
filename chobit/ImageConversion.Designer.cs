﻿namespace eChobits {
    partial class ImageConversion {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageConversion));
            this.btConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConvert
            // 
            this.btConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConvert.Location = new System.Drawing.Point(12, 12);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(465, 34);
            this.btConvert.TabIndex = 0;
            this.btConvert.Text = "Please create a folder on Desktop for convenient conversion!";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // ImageConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 57);
            this.Controls.Add(this.btConvert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImageConversion";
            this.Text = "ImageConversion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btConvert;
    }
}