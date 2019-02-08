using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.DebugData
{
    public static class Servers
    {
        public static List<Server> Items { get; } = new List<Server>
        {
            new Server{Id = 1, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 25, UseSsl = true},
            new Server{Id = 2, Name = "mail.ru", Address = "smtp.mail.ru", Port = 25, UseSsl = true},
            new Server{Id = 3, Name = "google", Address = "smtp.google.com", Port = 25, UseSsl = true},
        };
    }

    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSsl { get; set; }
    }
}
