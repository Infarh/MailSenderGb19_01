using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure;
using MailSender.lib;
using MailSender.lib.Data.Context;
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
            SimpleIoc.Default.Register<IMailsData, InMemoryMailsData>();

            SimpleIoc.Default.Register<IMailService, DebugMailService>();
            SimpleIoc.Default.Register<IServersData, EFServersData>();
            //SimpleIoc.Default.Register<IMailService, MailService>();

            SimpleIoc.Default.Register<MailDatabaseContext>();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup() { }
    }
}