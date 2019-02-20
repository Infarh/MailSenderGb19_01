namespace MailSender.lib.Data
{
    /// <summary>Отправитель сообщения электронной почты</summary>
    public class Sender
    {
        public int Id { get; set; }

        /// <summary>Имя</summary>
        public string Name { get; set; }

        /// <summary>Адрес электронной почты отправителя</summary>
        public string Address { get; set; }

        /// <summary>Пароль</summary>
        public string Password { get; set; }
    }
}