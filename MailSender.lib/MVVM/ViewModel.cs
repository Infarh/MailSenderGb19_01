using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.MVVM
{
    /// <summary>Модель представления</summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>Событие, возникающее когда в модель изменяет одно из своих свойств</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Сгенерировать событие изменения свойства</summary>
        /// <param name="PropertyName">Имя изменившегося свойства (если не указано, будет взято имя метода, откуда поступил вызов)</param>
        protected void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>Установит значение поля свойства с последующей генерацией события <see cref="PropertyChanged"/></summary>
        /// <typeparam name="T">Тип данных свойства</typeparam>
        /// <param name="field">Ссылка на поле, где свойство хранит свои данные</param>
        /// <param name="value">Новое значение свойства</param>
        /// <param name="PropertyName">Имя свойства - указывать не нужно. Будет использовано имя свойства, откуда поступил вызов</param>
        /// <returns>Истина, если новое значение свойства не <see cref="object.Equals(object)"/> и новое значение было установлено для поля <see cref="field"/></returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
