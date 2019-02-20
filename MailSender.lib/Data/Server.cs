namespace MailSender.lib.Data
{
    /// <summary>Почтовый сервер</summary>
    public class Server
    {
        public int Id { get; set; }

        /// <summary>Название</summary>
        public string Name { get; set; }

        /// <summary>Адрес</summary>
        public string Address { get; set; }

        /// <summary>Порт</summary>
        public int Port { get; set; } = 25;

        /// <summary>Использовать защищённое соединение</summary>
        public bool UseSSL { get; set; }
    }
}