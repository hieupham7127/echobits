namespace eChobits {
    partial class SMTP {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMTP));
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCarrier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMailServer = new System.Windows.Forms.ComboBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSenderPsw = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSenderEmail = new System.Windows.Forms.ComboBox();
            this.cboRecipient = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.Location = new System.Drawing.Point(216, 61);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(292, 212);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.Text = "Text me!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recipient\'s Phone#/Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recipient\'s Cellular Carrier:";
            // 
            // cboCarrier
            // 
            this.cboCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrier.Enabled = false;
            this.cboCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCarrier.Location = new System.Drawing.Point(13, 79);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Size = new System.Drawing.Size(178, 24);
            this.cboCarrier.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sender Email Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sender Email Server";
            // 
            // cboMailServer
            // 
            this.cboMailServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMailServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMailServer.Location = new System.Drawing.Point(13, 225);
            this.cboMailServer.Name = "cboMailServer";
            this.cboMailServer.Size = new System.Drawing.Size(178, 24);
            this.cboMailServer.TabIndex = 10;
            // 
            // tbSubject
            // 
            this.tbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubject.Location = new System.Drawing.Point(216, 31);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(292, 22);
            this.tbSubject.TabIndex = 11;
            this.tbSubject.Text = "Greetings";
            this.tbSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(301, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Subject (for email)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSalmon;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(304, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSenderPsw
            // 
            this.tbSenderPsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSenderPsw.Location = new System.Drawing.Point(13, 179);
            this.tbSenderPsw.Name = "tbSenderPsw";
            this.tbSenderPsw.Size = new System.Drawing.Size(178, 22);
            this.tbSenderPsw.TabIndex = 14;
            this.tbSenderPsw.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(15, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sender Email Password:";
            // 
            // cboSenderEmail
            // 
            this.cboSenderEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSenderEmail.FormattingEnabled = true;
            this.cboSenderEmail.Items.AddRange(new object[] {
            "hieu_pham8366@yahoo.com",
            "nguoilangthang761321@yahoo.com"});
            this.cboSenderEmail.Location = new System.Drawing.Point(13, 130);
            this.cboSenderEmail.Name = "cboSenderEmail";
            this.cboSenderEmail.Size = new System.Drawing.Size(178, 24);
            this.cboSenderEmail.TabIndex = 17;
            this.cboSenderEmail.SelectedIndexChanged += new System.EventHandler(this.cboSenderEmail_SelectedIndexChanged);
            // 
            // cboRecipient
            // 
            this.cboRecipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRecipient.FormattingEnabled = true;
            this.cboRecipient.Items.AddRange(new object[] {
            "9712320696",
            "hieupham7127",
            "hieu_pham8366"});
            this.cboRecipient.Location = new System.Drawing.Point(13, 33);
            this.cboRecipient.Name = "cboRecipient";
            this.cboRecipient.Size = new System.Drawing.Size(178, 24);
            this.cboRecipient.TabIndex = 18;
            this.cboRecipient.SelectedIndexChanged += new System.EventHandler(this.cboRecipient_SelectedIndexChanged);
            // 
            // SMTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(556, 351);
            this.Controls.Add(this.cboRecipient);
            this.Controls.Add(this.cboSenderEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSenderPsw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.cboMailServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCarrier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SMTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP";
            this.Load += new System.EventHandler(this.SMTP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSenderPsw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.ComboBox cboMailServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCarrier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ComboBox cboSenderEmail;
        private System.Windows.Forms.ComboBox cboRecipient;
    }
}