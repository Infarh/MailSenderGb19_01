﻿using System;
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

        public Recipient GetById(int id)
        {
            return _db.Recipient.FirstOrDefault(r => r.Id == id);
        }

        public void AddNew(Recipient NewRecipient)
        {
            NewRecipient.Id = _db.Recipient.Max(r => r.Id) + 1;
            _db.Recipient.InsertOnSubmit(NewRecipient);
        }

        public void Delete(int id)
        {
            var recipient = GetById(id);
            if(recipient is null)
                return;
            _db.Recipient.DeleteOnSubmit(recipient);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}