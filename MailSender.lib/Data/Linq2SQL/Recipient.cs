using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Linq2SQL
{
    public partial class Recipient : IDataErrorInfo
    {
        string IDataErrorInfo.Error => string.Empty;

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case nameof(Id): break;

                    case nameof(Name):
                        if (Name is null) return "Отсутствует имя (пустая ссылка на строку)";
                        if (Name.Length < 4) return "Длина имени должна быть больше 4 символов";
                        break;

                    case nameof(Address): break;
                }

                return string.Empty;
            }
        }

        partial void OnAddressChanging(string value)
        {
            if(value is null) 
                throw new ArgumentNullException(nameof(value), "Передана пустая ссылка на строку адреса");
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(
                    "Отсутствует адрес электронной почты, либо он имеет неверный формат", 
                    nameof(value));
        }
    }
}
