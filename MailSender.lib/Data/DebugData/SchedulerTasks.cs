using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.DebugData
{
    public static class SchedulerTasks
    {
        public static List<SchedulerTask> Items { get; } = new List<SchedulerTask>
        {
            new SchedulerTask {Id = 1, Name = "Task_1", Time = DateTime.Now.AddHours(1), Mail = "Mail_1"},
            new SchedulerTask {Id = 2, Name = "Task_2", Time = DateTime.Now.AddHours(1), Mail = "Mail_2"},
            new SchedulerTask {Id = 3, Name = "Task_3", Time = DateTime.Now.AddHours(1), Mail = "Mail_3"},
        };
    }

    public class SchedulerTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Mail { get; set; }
    }
}
