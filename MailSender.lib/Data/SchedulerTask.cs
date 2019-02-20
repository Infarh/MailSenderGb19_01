using System;
using System.Collections.Generic;

namespace MailSender.lib.Data
{
    /// <summary>Задача планировщика</summary>
    public class SchedulerTask
    {
        public int Id { get; set; }

        /// <summary>Название</summary>
        public string Name { get; set; }

        /// <summary>Время</summary>
        public DateTime Time { get; set; }

        public virtual MailsList Mails { get; set; }

        public virtual SendingList Recipients { get; set; }

        public virtual Sender Sender { get; set; }

        public virtual Server MailServer { get; set; }
    }
}