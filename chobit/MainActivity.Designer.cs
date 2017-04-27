namespace eChobits {
    partial class mainform {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.btSpeech = new System.Windows.Forms.Button();
            this.lbResponse = new System.Windows.Forms.Label();
            this.btYes = new System.Windows.Forms.Button();
            this.btNo = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.item2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item3 = new System.Windows.Forms.ToolStripMenuItem();
            this.item4 = new System.Windows.Forms.ToolStripMenuItem();
            this.item5 = new System.Windows.Forms.ToolStripMenuItem();
            this.item6 = new System.Windows.Forms.ToolStripMenuItem();
            this.item7 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbName = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(12, 29);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(401, 20);
            this.tbCommand.TabIndex = 0;
            // 
            // btSpeech
            // 
            this.btSpeech.BackColor = System.Drawing.Color.Transparent;
            this.btSpeech.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSpeech.BackgroundImage")));
            this.btSpeech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSpeech.FlatAppearance.BorderSize = 0;
            this.btSpeech.ForeColor = System.Drawing.Color.Transparent;
            this.btSpeech.Location = new System.Drawing.Point(419, 22);
            this.btSpeech.Name = "btSpeech";
            this.btSpeech.Size = new System.Drawing.Size(33, 32);
            this.btSpeech.TabIndex = 1;
            this.btSpeech.UseVisualStyleBackColor = false;
            this.btSpeech.Click += new System.EventHandler(this.btSpeech_Click);
            // 
            // lbResponse
            // 
            this.lbResponse.AllowDrop = true;
            this.lbResponse.AutoSize = true;
            this.lbResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResponse.Location = new System.Drawing.Point(12, 68);
            this.lbResponse.Name = "lbResponse";
            this.lbResponse.Size = new System.Drawing.Size(161, 16);
            this.lbResponse.TabIndex = 2;
            this.lbResponse.Text = "Hi! My name is Chobit!";
            this.lbResponse.TextChanged += new System.EventHandler(this.lbResponse_TextChanged);
            // 
            // btYes
            // 
            this.btYes.Location = new System.Drawing.Point(546, 107);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(75, 23);
            this.btYes.TabIndex = 3;
            this.btYes.Text = "It\'s me!";
            this.btYes.UseVisualStyleBackColor = true;
            this.btYes.Visible = false;
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // btNo
            // 
            this.btNo.Location = new System.Drawing.Point(700, 107);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(75, 23);
            this.btNo.TabIndex = 4;
            this.btNo.Text = "Not me!";
            this.btNo.UseVisualStyleBackColor = true;
            this.btNo.Visible = false;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "eChobits";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1,
            this.item2,
            this.item3,
            this.item4,
            this.item5,
            this.item6,
            this.item7});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(171, 158);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // item1
            // 
            this.item1.Image = ((System.Drawing.Image)(resources.GetObject("item1.Image")));
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(170, 22);
            this.item1.Text = "Music";
            // 
            // item2
            // 
            this.item2.Image = ((System.Drawing.Image)(resources.GetObject("item2.Image")));
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(170, 22);
            this.item2.Text = "SMTP";
            // 
            // item3
            // 
            this.item3.Image = ((System.Drawing.Image)(resources.GetObject("item3.Image")));
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(170, 22);
            this.item3.Text = "Image Conversion";
            // 
            // item4
            // 
            this.item4.Image = ((System.Drawing.Image)(resources.GetObject("item4.Image")));
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(170, 22);
            this.item4.Text = "Gallery";
            // 
            // item5
            // 
            this.item5.Image = ((System.Drawing.Image)(resources.GetObject("item5.Image")));
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(170, 22);
            this.item5.Text = "Paint";
            // 
            // item6
            // 
            this.item6.Image = ((System.Drawing.Image)(resources.GetObject("item6.Image")));
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(170, 22);
            this.item6.Text = "Note";
            // 
            // item7
            // 
            this.item7.Image = ((System.Drawing.Image)(resources.GetObject("item7.Image")));
            this.item7.Name = "item7";
            this.item7.Size = new System.Drawing.Size(170, 22);
            this.item7.Text = "Close";
            // 
            // lbName
            // 
            this.lbName.AllowDrop = true;
            this.lbName.AutoSize = true;
            this.lbName.Enabled = false;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(546, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(229, 39);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "Hello, World!";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbName.Visible = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(546, 68);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(229, 20);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.Visible = false;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 369);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.lbResponse);
            this.Controls.Add(this.btSpeech);
            this.Controls.Add(this.tbCommand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainform";
            this.Text = "Chobit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainform_FormClosed);
            this.Load += new System.EventHandler(this.mainform_Load);
            this.Resize += new System.EventHandler(this.mainform_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button btSpeech;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.Button btYes;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem item1;
        private System.Windows.Forms.ToolStripMenuItem item2;
        private System.Windows.Forms.ToolStripMenuItem item3;
        private System.Windows.Forms.ToolStripMenuItem item4;
        private System.Windows.Forms.ToolStripMenuItem item5;
        private System.Windows.Forms.ToolStripMenuItem item6;
        private System.Windows.Forms.ToolStripMenuItem item7;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbPassword;
    }
}

