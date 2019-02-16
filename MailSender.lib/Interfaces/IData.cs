using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        void AddNew(T NewItem);
        Task AddNewAsync(T NewItem);

        void Delete(int id);
        Task DeleteAsync(int id);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}