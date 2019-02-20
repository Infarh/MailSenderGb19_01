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

        /// <summary>Отправляемое письмо</summary>
        public string Mail { get; set; }
    }
}