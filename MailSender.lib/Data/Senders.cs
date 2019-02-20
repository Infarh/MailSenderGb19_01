using System.Collections.Generic;
using MailSender.lib.Service;
using PasswordServiceLib;

namespace MailSender.lib.Data
{
    /// <summary>Тестовый набор данных по отправителям</summary>
    public static class Senders
    {
        public static List<Sender> Items { get; } = new List<Sender>
        {
            new Sender { Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru", Password = PasswordEncoder.Encrypt("Password1")},
            new Sender { Id = 0, Name = "Петров", Address = "petrov@yandex.ru", Password = PasswordService.Encrypt("Password2") },
            new Sender { Id = 0, Name = "Сидоров", Address = "sidorov@yandex.ru", Password = PasswordService.Encrypt("Password3") },
        };
    }
}
