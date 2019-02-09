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
    /// Interaction logic for ToolBarSelectSenderOrServer.xaml
    /// </summary>
    public partial class ToolBarSelectSenderOrServer : UserControl
    {
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler ServerSelect;

        
        public ToolBarSelectSenderOrServer() => InitializeComponent();

        private void cbSenderselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
