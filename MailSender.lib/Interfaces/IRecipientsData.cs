using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Interfaces
{
    public interface IRecipientsData
    {
        IEnumerable<Recipient> GetAll();
        Recipient GetById(int id);
        void AddNew(Recipient NewRecipient);
        void Delete(int id);
        void SaveChanges();
    }
}
