using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    /// <summary>Сервис доступа к данным</summary>
    /// <typeparam name="T">Тип элемента данных</typeparam>
    public interface IData<T>
    {
        /// <summary>Получить все элементы</summary>
        /// <returns>Перечисление элементов</returns>
        IEnumerable<T> GetAll();

        /// <summary>Получить все элементы асинхронно</summary>
        /// <returns>Задача получения всех элементов данных</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>Найти элемент по индексу</summary>
        /// <param name="id">Индекс элемента</param>
        /// <returns>Элемент в источнике данных по указанному индексу, либо null, если такой отсутствует</returns>
        T GetById(int id);

        /// <summary>Асинхронно найти элемент по индексу</summary>
        /// <param name="id">Индекс элемента</param>
        /// <returns>Задача поиска элемента с указанным индексом в источнике данных</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>Добавить новый элемент в источник данных</summary>
        /// <param name="NewItem">Добавляемый элемент</param>
        void AddNew(T NewItem);

        /// <summary>Асинхронно добавить новый элемент в источник данных</summary>
        /// <param name="NewItem">Добавляемый элемент</param>
        /// <returns>Задача асинхронного добавления нового элемента</returns>
        Task AddNewAsync(T NewItem);

        /// <summary>Удалить элемент из источника данных по указанному индексу</summary>
        /// <param name="id">Индекс удаляемого элемента</param>
        void Delete(int id);

        /// <summary>Асинхронно удалить элемент с указанным индексом из источника данных</summary>
        /// <param name="id">Индекс удаляемого эелемента</param>
        /// <returns>Задача удаления элемента из источника данных</returns>
        Task DeleteAsync(int id);

        /// <summary>Сохранить изменения в источнике</summary>
        void SaveChanges();

        /// <summary>Асинхронно сохранить изменения в источнике</summary>
        /// <returns>Задача асинхронного сохранения изменений</returns>
        Task SaveChangesAsync();
    }
}