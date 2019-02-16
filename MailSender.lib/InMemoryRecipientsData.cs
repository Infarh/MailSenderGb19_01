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
            new Recipient { Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru" },
            new Recipient { Id = 1, Name = "Петров", Address = "petrov@yandex.ru" },
            new Recipient { Id = 2, Name = "Сидоров", Address = "sidorov@yandex.ru" },
        };

        public InMemoryRecipientsData()
        {

        }

        public IEnumerable<Recipient> GetAll()
        {
            return _Recipients;
        }

        public async Task<IEnumerable<Recipient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Recipient GetById(int id)
        {
            return _Recipients.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Recipient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void AddNew(Recipient NewRecipient)
        {
            if(_Recipients.Contains(NewRecipient))
                return;
            NewRecipient.Id = _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(NewRecipient);
        }

        public async Task AddNewAsync(Recipient NewItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var recipient = GetById(id);
            if(recipient is null)
                return;
            _Recipients.Remove(recipient);
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {

        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
