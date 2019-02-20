using MailSender.lib.Data;

namespace MailSender.lib.Interfaces
{
    /// <summary>Сервис доступа к данным по отправителям почтовых сообщений</summary>
    public interface ISendersData : IData<Sender> { }
}