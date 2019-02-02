using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;

namespace WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("@yandex.ru", "Павел");
                    message.To.Add("@gmail.com");

                    message.Subject = "Заголовок сообщения";
                    message.Body = "Текст сообщения";
                    message.IsBodyHtml = false;

                    using (var client = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        client.EnableSsl = true;

                        //var user_name = UserNameEdit.Text;
                        //SecureString user_password = PasswordBoxEdit.SecurePassword;
                        //client.Credentials = new NetworkCredential(user_name, user_password);

                        //client.Send(message);
                        //MessageBox.Show("Почта успешно отправилена", "Успех!",
                        //    MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Возникла ошибка в процессе отправки почты",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //SmtpClient smtp_client = null;
            //try
            //{
            //    smtp_client = new SmtpClient("smtp.yandex.ru", 465);
            //    // остальной код тела using
            //}
            //finally
            //{
            //     if(smtp_client != null)
            //         smtp_client.Dispose();
            //}
        }
    }
}
