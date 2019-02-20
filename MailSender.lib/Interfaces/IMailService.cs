using System.Linq;
using System.Security;
using System.Text;

namespace MailSender.lib.Interfaces
{
    /// <summary>Сервис рассылки почты</summary>
    public interface IMailService
    {
        /// <summary>Получить объект, позволяющий отправлять через себя почтовые сообщения</summary>
        /// <param name="Address">Адрес сервера</param>
        /// <param name="Port">Порт</param>
        /// <param name="SSL">Использовать защищённое соединение</param>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Объект рассылки почты</returns>
        IMailSender GetSender(string Address, int Port, bool SSL, string Login, SecureString Password);
    }
}
