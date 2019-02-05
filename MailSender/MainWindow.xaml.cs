using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MailSender.lib.Data.Debug;

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

        private void MiClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = tabPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {

            
            
            MessageBox.Show(cbSenderSelect.Items.CurrentItem.ToString());


        }

        private void cbSenderselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
