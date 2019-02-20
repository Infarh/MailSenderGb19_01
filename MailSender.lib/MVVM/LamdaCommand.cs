using System;
using System.Windows.Input;

namespace MailSender.lib.MVVM
{
    /// <summary>Команда элемента управления</summary>
    public class LamdaCommand : ICommand
    {
        /// <summary>Событие возникает когда команда меняет своё состояние <see cref="CanExecute"/></summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>Делегат метода действия команды, вызываемый при её активации</summary>
        private readonly Action<object> _OnExecute;

        /// <summary>Делегат метода проверки возможности выполнения команды</summary>
        private readonly Func<object, bool> _CanExecute;

        /// <summary>Новая команда</summary>
        /// <param name="OnExecute">Основное действие команды</param>
        /// <param name="CanExecute">Проверка на возможность исполнения. Если null, то команда может быть исполнена в любом случае</param>
        public LamdaCommand(Action<object> OnExecute, Func<object, bool> CanExecute = null)
        {
            _OnExecute = OnExecute;
            _CanExecute = CanExecute;
        }

        /// <summary>Проверка на возможность исполнения команды</summary>
        /// <param name="parameter">Параметр, передаваемый команде при её исполнении</param>
        /// <returns>Истина - команду можно выполнить</returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>Исполнение команды</summary>
        /// <param name="parameter">Параметр, передаваемый команде при её исполнении</param>
        public void Execute(object parameter)
        {
            _OnExecute(parameter);
        }
    }
}
