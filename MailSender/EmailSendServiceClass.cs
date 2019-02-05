using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender
{
    class EmailSendServiceClass
    {
        #region varibles
        private string strLogin;
        private string strPassword;
        private string strSmtp;
        private int    iSmtpPort;
        private string strBody;
        private string strSubject;
        #endregion

        public EmailSendServiceClass(string mail, string name)
        {


            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = "HELLO";
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Невозможно отправить письмо " + e.ToString());
                }
            }
        }

        private void SendMail(string mail, string name)
        {

        }

        public void SendMails(IQueryable<Recipient> emails)
        {
            foreach (Recipient email in emails)
            {
                SendMail(email.Address, email.Name);
            }
        }
    }
}
