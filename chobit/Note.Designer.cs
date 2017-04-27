namespace eChobits {
    partial class Note {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Note));
            this.lvLetter = new System.Windows.Forms.ListView();
            this.ilLetter = new System.Windows.Forms.ImageList(this.components);
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.tbLetter = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvLetter
            // 
            this.lvLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lvLetter.LargeImageList = this.ilLetter;
            this.lvLetter.Location = new System.Drawing.Point(0, 58);
            this.lvLetter.Name = "lvLetter";
            this.lvLetter.Size = new System.Drawing.Size(522, 383);
            this.lvLetter.TabIndex = 1;
            this.lvLetter.UseCompatibleStateImageBehavior = false;
            this.lvLetter.SelectedIndexChanged += new System.EventHandler(this.lvLetter_SelectedIndexChanged);
            // 
            // ilLetter
            // 
            this.ilLetter.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilLetter.ImageSize = new System.Drawing.Size(16, 16);
            this.ilLetter.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(12, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(115, 12);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 23);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // tbLetter
            // 
            this.tbLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tbLetter.Location = new System.Drawing.Point(521, 1);
            this.tbLetter.Multiline = true;
            this.tbLetter.Name = "tbLetter";
            this.tbLetter.Size = new System.Drawing.Size(538, 440);
            this.tbLetter.TabIndex = 4;
            this.tbLetter.TextChanged += new System.EventHandler(this.tbLetter_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(309, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(160, 20);
            this.tbName.TabIndex = 5;
            this.tbName.Text = "Letter1";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(268, 17);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 441);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbLetter);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.lvLetter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Note";
            this.Text = "Note";
            this.Load += new System.EventHandler(this.Note_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvLetter;
        private System.Windows.Forms.ImageList ilLetter;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.TextBox tbLetter;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
    }
}