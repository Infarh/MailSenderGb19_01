using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InLinq2SQLRecipientsData : IRecipientsData
    {
        private MailDatabaseContext _db;

        public InLinq2SQLRecipientsData(MailDatabaseContext DatabaseContext)
        {
            _db = DatabaseContext;
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient.AsEnumerable();
        }

        public async Task<IEnumerable<Recipient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Recipient GetById(int id)
        {
            return _db.Recipient.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Recipient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void AddNew(Recipient NewRecipient)
        {
            NewRecipient.Id = _db.Recipient.Max(r => r.Id) + 1;
            _db.Recipient.InsertOnSubmit(NewRecipient);
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
            _db.Recipient.DeleteOnSubmit(recipient);
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
