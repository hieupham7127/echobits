using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace eChobits {
    public partial class SMTP : Form {
        public SMTP () {
            InitializeComponent();
        }
        
        private void SMTP_Load(object sender, EventArgs e) {
            // cellular carrier
            cboCarrier.Items.Add("@text.republicwireless.com");
            cboCarrier.Items.Add("@gmail.com");
            cboCarrier.Items.Add("@yahoo.com");
            //cboCarrier.Items.Add("@wap.mobifone.com.vn");
            // email server
            cboMailServer.Items.Add("smtp.mail.yahoo.com");
            //cboMailServer.Items.Add("smtp.gmail.com");

            cboCarrier.SelectedIndex = 0;
            cboRecipient.SelectedIndex = 0; // this must be below cboCarrier
            cboSenderEmail.SelectedIndex = 0;
            cboMailServer.SelectedIndex = 0;
        }
        
        private void cboSenderEmail_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboSenderEmail.SelectedIndex == 1) tbSenderPsw.Text = "thunder8551549.";
            else tbSenderPsw.Text = "";
        }


        private string mFrom;
        private string mTo;
        private string mMailServer;
        private string mMailPsw;
        
        private void cboRecipient_SelectedIndexChanged(object sender, EventArgs e) {
            cboCarrier.SelectedIndex = cboRecipient.SelectedIndex;
        }

        private string mSubject;
        private string mMsg;
        private void button1_Click(object sender, EventArgs e) {
            // Collect user input from the form and stow content into
            // the objects member variables
            //mTo = "5093021453" + cboCarrier.SelectedItem.ToString();
            mTo = cboRecipient.Text + cboCarrier.SelectedItem.ToString();
            //mTo = "hieu_pham8366@yahoo.com";
            mFrom = cboSenderEmail.Text;
            mMailPsw = tbSenderPsw.Text;
            mMailServer = cboMailServer.Text;
            mSubject = tbSubject.Text;
            mMsg = tbMessage.Text;

            try {
                // Within a try catch, format and send the message to
                // the recipient.  Catch and handle any errors.
                MailMessage msg = new MailMessage(mFrom, mTo, mSubject, mMsg);
                // setup client
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mFrom, mMailPsw);
                smtp.Host = mMailServer;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(msg);
                MessageBox.Show("The mail message has been sent to " + msg.To.ToString(), "Mail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex) {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SmtpException ex) {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
