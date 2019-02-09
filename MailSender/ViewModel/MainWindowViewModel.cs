using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsData _RecipientsData;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "К спаму готов!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public ICommand UpdateRecipientsCommand { get; }
        private bool CanUpdateRecipientsCommandExecuted() => true;
        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            foreach (var recipient in _RecipientsData.GetAll())
                Recipients.Add(recipient);
        }

        private Recipient _CurrentRecipient;

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        } 

        public ICommand SaveRecipientCommand { get; }

        public MainWindowViewModel(IRecipientsData RecipientsData)
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted);

            _RecipientsData = RecipientsData;
        }
    }
}
                                         