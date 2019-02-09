using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    public class LambdaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> _OnExecute;
        private readonly Func<object, bool> _CanExeute;

        public LambdaCommand(Action<object> OnExecute, Func<object, bool> CanExecute = null)
        {
            _OnExecute = OnExecute;
            _CanExeute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExeute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _OnExecute(parameter);
        }
    }
}
