using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Service
{
    class EmailSenderServiceClass
    {
        
        private string strPassword;
        private string strSender;
        private string strSubject;
        private string strSmtpServer;
        private int    iPort;

        public EmailSenderServiceClass(string strPassword, string strSender, string strSubject, string strSmtpServer, int iPort)
        {
            this.strPassword = strPassword;
            this.strSender = strSender;
            this.strSubject = strSubject;
            this.strSmtpServer = strSmtpServer;
            this.iPort = iPort;
        }

        public void SendMessage(ObservableCollection<Recipient> recipients, string strBody)
        {
            foreach (var mail in recipients)
            {
                using (MailMessage mm = new MailMessage(strSender, mail.Address))
                {
                    mm.Subject = strSubject;
                    mm.Body = strBody;
                    mm.IsBodyHtml = false;

                    using (SmtpClient sc = new SmtpClient(strSmtpServer, iPort))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(strSender, strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
            }

        }

    }
}
