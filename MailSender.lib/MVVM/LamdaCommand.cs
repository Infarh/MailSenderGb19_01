using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    public class LamdaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _OnExecute;
        private readonly Func<object, bool> _CanExecute;

        public LamdaCommand(Action<object> OnExecute, Func<object, bool> CanExecute = null)
        {
            _OnExecute = OnExecute;
            _CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _OnExecute(parameter);
        }
    }
}
