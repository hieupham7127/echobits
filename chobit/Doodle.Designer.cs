namespace eChobits {
    partial class Doodle {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doodle));
            this.pnPaint = new System.Windows.Forms.Panel();
            this.btPen = new System.Windows.Forms.Button();
            this.btEraser = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnPaint
            // 
            this.pnPaint.BackColor = System.Drawing.Color.White;
            this.pnPaint.Location = new System.Drawing.Point(0, 0);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.Size = new System.Drawing.Size(595, 438);
            this.pnPaint.TabIndex = 0;
            // 
            // btPen
            // 
            this.btPen.Location = new System.Drawing.Point(601, 12);
            this.btPen.Name = "btPen";
            this.btPen.Size = new System.Drawing.Size(32, 31);
            this.btPen.TabIndex = 1;
            this.btPen.UseVisualStyleBackColor = true;
            this.btPen.Click += new System.EventHandler(this.btPen_Click);
            // 
            // btEraser
            // 
            this.btEraser.Location = new System.Drawing.Point(601, 49);
            this.btEraser.Name = "btEraser";
            this.btEraser.Size = new System.Drawing.Size(32, 31);
            this.btEraser.TabIndex = 2;
            this.btEraser.UseVisualStyleBackColor = true;
            this.btEraser.Click += new System.EventHandler(this.btEraser_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(601, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 31);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(601, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(32, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(601, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 29);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Doodle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 438);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btEraser);
            this.Controls.Add(this.btPen);
            this.Controls.Add(this.pnPaint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Doodle";
            this.Text = "Dooooooodle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPaint;
        private System.Windows.Forms.Button btPen;
        private System.Windows.Forms.Button btEraser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}