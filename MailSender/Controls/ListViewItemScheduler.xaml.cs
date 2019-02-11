using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Controls
{
    /// <summary>
    /// Interaction logic for ListViewItemScheduler.xaml
    /// </summary>
    public partial class ListViewItemScheduler : UserControl
    {
        public ListViewItemScheduler() => InitializeComponent();

        public event EventHandler AddMessage;

        public event EventHandler RemoveElement;

        private void AddMessageClick(object sender, RoutedEventArgs E)
        {
            AddMessage?.Invoke(this, EventArgs.Empty);
        }

        private void RemoveElementClick(object sender, RoutedEventArgs E)
        {
            RemoveElement?.Invoke(this, EventArgs.Empty);
        }
    }
}
