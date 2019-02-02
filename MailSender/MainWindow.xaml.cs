using System;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void OnForvard(object Sender, EventArgs E)
        {
            if (MainTabControl.SelectedIndex > 0)
                MainTabControl.SelectedIndex--;
        }

        private void OnBackvard(object Sender, EventArgs E)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.Items.Count)
                MainTabControl.SelectedIndex++;
        }
    }
}
