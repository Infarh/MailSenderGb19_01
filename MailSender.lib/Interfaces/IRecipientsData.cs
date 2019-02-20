using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;

namespace MailSender.lib.Interfaces
{
    /// <summary>Сервис доступа к данным по получателям почтовых сообщений</summary>
    public interface IRecipientsData : IData<Recipient> { }
}
