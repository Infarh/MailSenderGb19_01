using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Threading;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Service
{
    class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer();
        private EmailSenderServiceClass emailSender;
        private Dictionary<DateTime, string> dicTdSend;
        private ObservableCollection<Recipient> recipients;
        private DateTime key;
        
        

        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }

            return tsSendTime;
        }

        public void SendEmails(DateTime dtSend, EmailSenderServiceClass emailSender,
            ObservableCollection<Recipient> recipients, string messageText)
        {
            this.emailSender = emailSender;
            dicTdSend.Add(dtSend, messageText);
            this.recipients = recipients;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var elementDictionary in dicTdSend)
            {
                key = elementDictionary.Key;
                if (DateTime.Now.ToShortTimeString() == elementDictionary.Key.ToShortTimeString())
                {
                    emailSender.SendMessage(recipients, elementDictionary.Value);
                    MessageBox.Show("Письма отправлены");
                }
            }
            dicTdSend.Remove(key);
        }
    }
}
