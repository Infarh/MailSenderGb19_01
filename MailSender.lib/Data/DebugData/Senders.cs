using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Service;
using PasswordServiceLib;

namespace MailSender.lib.Data.DebugData
{
    public static class Senders 
    {
        public static List<Sender> Items { get; } = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов",  Address = "ivanov@yandex.ru",  Password = PasswordEncoder.Encrypt("Password1")},
            new Sender{Id = 2, Name = "Петров",  Address = "petrov@yandex.ru",  Password = PasswordEncoder.Encrypt("Password2")},
            new Sender{Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru", Password = PasswordEncoder.Encrypt("Password3")},
        };
    }

    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
