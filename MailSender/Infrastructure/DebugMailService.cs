using System;
using System.Diagnostics;
using System.Security;
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

    internal class DebugMailSender : IMailSender, IDisposable
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

        public void Dispose()
        {

        }
    }
}
