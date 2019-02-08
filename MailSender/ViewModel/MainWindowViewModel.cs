using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассылщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "К спаму готов";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
    }
}
