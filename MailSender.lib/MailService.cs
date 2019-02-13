using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class MailService : IMailService
    {
        public IMailSender GetSender(string Address, int Port, bool SSL, string Login, SecureString Password)
        {
            return new MailSender(Address, Port, SSL, Login, Password);
        }
    }

    internal class MailSender : IMailSender
    {
        private readonly SmtpClient _Client;

        public MailSender(string Address, int Port, bool SSL, string Login, SecureString Password)
        {
            _Client = new SmtpClient(Address, Port)
            {
                Credentials = new NetworkCredential(Login, Password),
                EnableSsl = SSL
            };
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            using (var msg = new MailMessage(SenderAddress, RecipientAddress, Subject, Body))
                _Client.Send(msg);
        }

        public void SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var thread = new Thread(() => Send(SenderAddress, RecipientAddress, Subject, Body));
            thread.Priority = ThreadPriority.BelowNormal;
            thread.IsBackground = true;
            thread.Start();
        }

        public void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient in RecipientsAddresses)
                Send(SenderAddress, recipient, Subject, Body);
        }

        public void SendAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient in RecipientsAddresses)
                ThreadPool.QueueUserWorkItem(o => Send(SenderAddress, recipient, Subject, Body));

        }

        public void Dispose()
        {
            _Client.Dispose();
        }
    }
}
