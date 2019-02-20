﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    /// <summary>Получатель сообщения электронной почты</summary>
    public class Recipient
    {
        public int Id { get; set; }

        /// <summary>Имя</summary>
        public string Name { get; set; }

        /// <summary>Адрес электронной почты получателя</summary>
        public string Address { get; set; }
    }
}
