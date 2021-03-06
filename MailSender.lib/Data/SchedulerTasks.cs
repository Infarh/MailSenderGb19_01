﻿using System;
using System.Collections.Generic;

namespace MailSender.lib.Data
{
    /// <summary>Тестовый набор данных по задачам планировщика</summary>
    public static class SchedulerTasks
    {
        public static List<SchedulerTask> Items { get; } = new List<SchedulerTask>
        {
            new SchedulerTask { Id = 1, Name = "Task 1", Time = DateTime.Now.AddHours(1) },
            new SchedulerTask { Id = 2, Name = "Task 2", Time = DateTime.Now.AddHours(3) },
            new SchedulerTask { Id = 3, Name = "Task 3", Time = DateTime.Now.AddHours(7) },
        };
    }
}
