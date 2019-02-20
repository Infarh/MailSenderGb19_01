using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSender.lib.Data
{
    public class MailsList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[ForeignKey("MailId")]
        public virtual ICollection<Mail> Mails { get; set; }
    }
}