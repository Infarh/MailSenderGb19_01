using System;
using System.Windows;

namespace MailSender.Controls
{
    public partial class TabViewManager
    {
        public event EventHandler Forvard;

        public event EventHandler Backvard;

        public TabViewManager() => InitializeComponent();

        private void BackwardButtonClick(object Sender, RoutedEventArgs E)
        {
            //Forvard?.Invoke(this, EventArgs.Empty);
            var handlers = Forvard;
            if(handlers != null)
                handlers(this, EventArgs.Empty);
        }

        private void ForvardButtonClick(object Sender, RoutedEventArgs E)
        {
            Backvard?.Invoke(this, EventArgs.Empty);
        }
    }
}
