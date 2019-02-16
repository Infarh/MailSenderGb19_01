using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.DebugData;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class InMemoryMailsData : IMailsData
    {
        public IEnumerable<Mail> GetAll() => Mails.Items;

        public Mail GetById(int id) => Mails.Items.FirstOrDefault(m => m.Id == id);

        public void AddNew(Mail NewItem)
        {
            if (Mails.Items.Contains(NewItem)) return;
            if (Mails.Items.Count > 0)
                NewItem.Id = Mails.Items.Max(m => m.Id) + 1;
            else
                NewItem.Id = 1;
            Mails.Items.Add(NewItem);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if(item is null) return;
            Mails.Items.Remove(item);
        }

        public void SaveChanges() { }
    }
}
