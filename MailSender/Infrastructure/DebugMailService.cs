using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.Infrastructure
{
    internal class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Address, int Port, bool SSL, string Login, SecureString Password)
        {
            return new DebugMailSender(Address, Port, SSL, Login, Password);
        }
    }

    internal class DebugMailSender : IMailSender
    {
        private readonly string _Address;
        private readonly int _Port;
        private readonly bool _Ssl;
        private readonly string _Login;
        private readonly SecureString _Password;

        public DebugMailSender(string Address, int Port, bool SSL, string Login, SecureString Password)
        {
            _Address = Address;
            _Port = Port;
            _Ssl = SSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            Trace.TraceInformation("Отправка сообщения через сервер {0}:{1} (ssl:{2})" +
                            "\r\n  Login:{3}" +
                            "\r\n  Отправитель:{4}" +
                            "\r\n  Получатель:{5}" +
                            "\r\n  Тема:{6}" +
                            "\r\n  Текст:{7}",
                _Address, _Port, _Ssl,
                _Login, SenderAddress, RecipientAddress,
                Subject, Body);
        }

        public async Task SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            await Task.Yield();
            Send(SenderAddress, RecipientAddress, Subject, Body);
        }

        public void SendParallel(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var thread = new Thread(() => Send(SenderAddress, RecipientAddress, Subject, Body))
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = true
            };
            thread.Start();
        }

        public void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient in RecipientsAddresses)
                Send(SenderAddress, recipient, Subject, Body);
        }

        public async Task SendAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            await Task.Yield();
            Send(SenderAddress, RecipientsAddresses, Subject, Body);
        }

        public void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient in RecipientsAddresses)
                ThreadPool.QueueUserWorkItem(o => Send(SenderAddress, recipient, Subject, Body));

        }

        public void Dispose()
        {

        }
    }
}
