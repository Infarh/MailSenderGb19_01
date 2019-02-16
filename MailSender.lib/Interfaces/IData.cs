using System.Collections.Generic;

namespace MailSender.lib.Interfaces
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void AddNew(T NewItem);
        void Delete(int id);
        void SaveChanges();
    }
}