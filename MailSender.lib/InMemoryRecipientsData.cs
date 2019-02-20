using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;
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

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Task<IEnumerable<Recipient>> GetAllAsync() => Task.FromResult(GetAll());

        public Recipient GetById(int id) => _Recipients.FirstOrDefault(r => r.Id == id);

        public Task<Recipient> GetByIdAsync(int id) => Task.FromResult(GetById(id));

        public void AddNew(Recipient NewRecipient)
        {
            if(_Recipients.Contains(NewRecipient))
                return;
            NewRecipient.Id = _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(NewRecipient);
        }

        public async Task AddNewAsync(Recipient NewItem)
        {
            await Task.Yield();
            AddNew(NewItem);
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
            await Task.Yield();
            Delete(id);
        }

        public void SaveChanges()
        {

        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
