using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public static class Servers
    {
        public static List<Server> Items { get; } = new List<Server>
        {
             new Server { Id = 1, Name = "Яндекс", Address  = "smtp.yandex.ru", Port = 25, UseSSL = true },
             new Server { Id = 2, Name = "Mail.ru", Address  = "smtp.mail.ru", Port = 25, UseSSL = true },
             new Server { Id = 3, Name = "Gmail", Address  = "smtp.gmail.com", Port = 25, UseSSL = true },
        };
    }

    /// <summary>Почтовый сервер</summary>
    public class Server
    {
         public int Id { get; set; }

         /// <summary>Название</summary>
         public string Name { get; set; }

         /// <summary>Адрес</summary>
         public string Address { get; set; }

         /// <summary>Порт</summary>
         public int Port { get; set; } = 25;

         /// <summary>Использовать защищённое соединение</summary>
         public bool UseSSL { get; set; }
    }
}
