using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.DebugData
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

    public class Mail
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
