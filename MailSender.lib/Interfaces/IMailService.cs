using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IMailService
    {
        IMailSender GetSender(string Address, int Port, bool SSL, string Login, SecureString Password);
    }

    public interface IMailSender : IDisposable
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);

        Task SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body);

        void SendParallel(string SenderAddress, string RecipientAddress, string Subject, string Body);

        void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);

        Task SendAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);

        void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);
    }
}
