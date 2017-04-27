namespace eChobits {
    partial class StickyNoteForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StickyNoteForm));
            this.tbContent = new System.Windows.Forms.TextBox();
            this.lbAdd = new System.Windows.Forms.Label();
            this.pnOptions = new System.Windows.Forms.Panel();
            this.lbOptions = new System.Windows.Forms.Label();
            this.pnOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbContent
            // 
            this.tbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContent.Location = new System.Drawing.Point(0, 36);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(284, 226);
            this.tbContent.TabIndex = 2;
            this.tbContent.TextChanged += new System.EventHandler(this.tbContent_TextChanged);
            // 
            // lbAdd
            // 
            this.lbAdd.AutoSize = true;
            this.lbAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdd.Location = new System.Drawing.Point(3, 0);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(33, 33);
            this.lbAdd.TabIndex = 3;
            this.lbAdd.Text = "+";
            this.lbAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAdd.Click += new System.EventHandler(this.lbAdd_Click);
            // 
            // pnOptions
            // 
            this.pnOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnOptions.BackgroundImage")));
            this.pnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnOptions.Controls.Add(this.lbOptions);
            this.pnOptions.Location = new System.Drawing.Point(259, 5);
            this.pnOptions.Name = "pnOptions";
            this.pnOptions.Size = new System.Drawing.Size(25, 25);
            this.pnOptions.TabIndex = 5;
            // 
            // lbOptions
            // 
            this.lbOptions.AutoSize = true;
            this.lbOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOptions.Location = new System.Drawing.Point(3, 0);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(24, 33);
            this.lbOptions.TabIndex = 6;
            this.lbOptions.Text = " ";
            this.lbOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOptions.Click += new System.EventHandler(this.lbOptions_Click);
            // 
            // StickyNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.pnOptions);
            this.Controls.Add(this.lbAdd);
            this.Controls.Add(this.tbContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StickyNoteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StickyNote_Load);
            this.pnOptions.ResumeLayout(false);
            this.pnOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Label lbAdd;
        private System.Windows.Forms.Panel pnOptions;
        private System.Windows.Forms.Label lbOptions;
    }
}