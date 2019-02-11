using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MailSender.lib.Data.DebugData
{
   

    public static class MailsList
    {
        public static ObservableCollection<Mail> Items { get; set; } = new ObservableCollection<Mail>
        {
            new Mail{strMessage = "1", dtDate = DateTime.Now},
            new Mail{strMessage = "2", dtDate = DateTime.Now},
            new Mail{strMessage = "3", dtDate = DateTime.Now},
            new Mail{strMessage = "4", dtDate = DateTime.Now},

        };
    }

    public class Mail
    {
        public string strMessage { get; set; }
        public DateTime dtDate { get; set; }
    }
}
