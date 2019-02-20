namespace MailSender.lib.Data
{
    /// <summary>Сообщение электронной почты</summary>
    public class Mail
    {
        public int Id { get; set; }

        /// <summary>Тема письма</summary>
        public string Subject { get; set; }

        /// <summary>Тело письма</summary>
        public string Body { get; set; }
    }
}
