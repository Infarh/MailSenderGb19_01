using System.Collections.Generic;

namespace MailSender.lib.Data
{
    /// <summary>Тестовый набор данных по серверам</summary>
    public static class Servers
    {
        public static List<Server> Items { get; } = new List<Server>
        {
             new Server { Name = "Яндекс", Address  = "smtp.yandex.ru", Port = 25, UseSSL = true, Login = "login", Password = "pass" },
             new Server { Name = "Mail.ru", Address  = "smtp.mail.ru", Port = 25, UseSSL = true, Login = "login", Password = "pass" },
             new Server { Name = "Gmail", Address  = "smtp.gmail.com", Port = 25, UseSSL = true, Login = "login", Password = "pass" },
        };
    }
}
