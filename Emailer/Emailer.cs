using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Emailer
{
    public partial class Emailer : Form
    {
        public Emailer()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close(); 
        }

        private void llbl_attachfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.ShowDialog();
            lbl_location.Text = openFileDialog.FileName;
        }

        private void Emailer_Load(object sender, EventArgs e)
        {
            lbl_location.Text = "";
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
                mail.From = new MailAddress(txt_from.Text);
                mail.To.Add(txt_to.Text);
                mail.Subject = txt_tittle.Text;
                mail.Body = txt_body.Text;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(lbl_location.Text);
                mail.Attachments.Add(attachment);

                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(txt_from.Text, txt_password.Text);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(mail);

                MessageBox.Show("Cool!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
