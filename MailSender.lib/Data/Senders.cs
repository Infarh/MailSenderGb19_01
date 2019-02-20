using System.Collections.Generic;
using MailSender.lib.Service;
using PasswordServiceLib;

namespace MailSender.lib.Data
{
    public static class Senders
    {
        public static List<Sender> Items { get; } = new List<Sender>
        {
            new Sender { Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru", Password = PasswordEncoder.Encrypt("Password1")},
            new Sender { Id = 0, Name = "Петров", Address = "petrov@yandex.ru", Password = PasswordService.Encrypt("Password2") },
            new Sender { Id = 0, Name = "Сидоров", Address = "sidorov@yandex.ru", Password = PasswordService.Encrypt("Password3") },
        };
    }

    /// <summary>Отправитель сообщения электронной почты</summary>
    public class Sender
    {
        public int Id { get; set; }

        /// <summary>Имя</summary>
        public string Name { get; set; }

        /// <summary>Адрес электронной почты отправителя</summary>
        public string Address { get; set; }

        /// <summary>Пароль</summary>
        public string Password { get; set; }
    }
}
