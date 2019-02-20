using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Data
{
    /// <summary>Сообщение электронной почты</summary>
    public class Mail
    {
        public int Id { get; set; }

        /// <summary>Тема письма</summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>Тело письма</summary>
        [Required]
        public string Body { get; set; }
    }
}
