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


namespace Confectionery_factory
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        private void PasswordBox_PasswordChanged (object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                btnCreate.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.BorderBrush = Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            if (AppConnect.modelOdb.Пользователь.Count(x => x.Логин == txbLogin.Text) > 0)
            {
                    MessageBox.Show("Пользователь с таким логином есть!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (psbPass.Password == null)
            {
                message.Text = "Пароль был пуст";
                psbPass.Password = null;
                txbPass.Text = "";
                psbPass.Background = Brushes.White;
                return;
            }

            if (psbPass.Password.Length < 2)
            {
                message.Text = "Длина пароля должна быть больше, чем 1";
                psbPass.Password = null;
                txbPass.Text = "";
                psbPass.Background = Brushes.White;
                return;
            }

            if (psbPass.Password.Length < 8)
            {
                message.Text = "Длина пароля должна быть не меньше, чем 8";
                psbPass.Password = null;
                txbPass.Text = "";
                psbPass.Background = Brushes.White;
                return;
            }
                
            try
            {
                var password = txbPass.Text;
                Пользователь userObj = new Пользователь()
                {
                    Логин = txbLogin.Text,
                    Имя = txbName.Text,
                    Пароль = md5.HashPassword(password),
                    Код_роли = 3
                };
                AppConnect.modelOdb.Пользователь.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
