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

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor : UserControl
    {
        public RecipientEditor()
        {
            InitializeComponent();
        }

        private void Validation_OnError(object Sender, ValidationErrorEventArgs E)
        {
            if(!(E.Source is FrameworkElement conrtol)) return;
            if (E.Action == ValidationErrorEventAction.Added)
            {
                conrtol.ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                conrtol.ToolTip = "";
            }
        }
    }
}
