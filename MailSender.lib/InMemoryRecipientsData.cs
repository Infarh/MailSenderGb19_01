using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InMemoryRecipientsData : IRecipientsData
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>
        {
            new Recipient{ Id = 1, Name = "Смирнов",   Address = "smirnov@yandex.ru" },
            new Recipient{ Id = 2, Name = "Мельников", Address = "melnikov@yandex.ru"},
            new Recipient{ Id = 3, Name = "Данилов",   Address = "danilov@yandex.ru" },
        };

        public void AddNew(Recipient NewRecipient)
        {
            if(_Recipients.Contains(NewRecipient))
                return;
            NewRecipient.Id = _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(NewRecipient);
        }

        public void Delete(int id)
        {
            var recipient = GetById(id);
            if (recipient is null)
                return;
            _Recipients.Remove(recipient);
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _Recipients;
        }

        public Recipient GetById(int id)
        {
            return _Recipients.FirstOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
        }
    }
}
