using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<IRecipientsData, InMemoryRecipientsData>();
            if(!SimpleIoc.Default.IsRegistered<MailDatabaseContext>())
                SimpleIoc.Default.Register(() => new MailDatabaseContext());
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup() { }
    }
}