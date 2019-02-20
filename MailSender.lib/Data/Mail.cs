using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public static class Mails
    {
          public static List<Mail> Items { get; } = new List<Mail>
          {
              new Mail { Id = 1, Subject = "Mail 1", Body = "Mail body 1" },
              new Mail { Id = 2, Subject = "Mail 2", Body = "Mail body 2" },
              new Mail { Id = 3, Subject = "Mail 3", Body = "Mail body 3" }
          };
    }

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
