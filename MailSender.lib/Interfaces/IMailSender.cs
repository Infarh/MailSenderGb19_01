using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    /// <summary>Сервис отправки почты</summary>
    public interface IMailSender : IDisposable
    {
        /// <summary>Отправить сообщение</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientAddress">Адрес получателя</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);

        /// <summary>Асинхронно отправить сообщение</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientAddress">Адрес получателя</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        /// <returns>Задача отправки сообщения</returns>
        Task SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body);

        /// <summary>Отправить сообщение в параллельном потоке</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientAddress">Адрес получателя</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        void SendParallel(string SenderAddress, string RecipientAddress, string Subject, string Body);

        /// <summary>Отправить сообщение списку получателей</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientsAddresses">Перечисление адресов получателей</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);

        /// <summary>Асинхронно отправить сообщение списку получателей</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientsAddresses">Перечисление адресов получателей</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        /// <returns>Задача отправки сообщений</returns>
        Task SendAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);

        /// <summary>Параллельно отправить сообщение списку получателей</summary>
        /// <param name="SenderAddress">Адрес отправителя</param>
        /// <param name="RecipientsAddresses">Перечисление адресов получателей</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Body">Текст письма</param>
        void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);
    }
}