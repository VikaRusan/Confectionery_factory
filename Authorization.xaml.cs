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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                txbPassword.Text = psbPassword.Password;
                txbPassword.Visibility = Visibility.Visible;
                psbPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                psbPassword.Password = txbPassword.Text; 
                txbPassword.Visibility = Visibility.Hidden;
                psbPassword.Visibility = Visibility.Visible; 
            }
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var password = md5.HashPassword(psbPassword.Password);
                var userObj = AppConnect.modelOdb.Пользователь.FirstOrDefault(x => x.Логин == txbLogin.Text && x.Пароль == password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.Код_роли)
                    {
                        case 1: MessageBox.Show("Здравствуйте, Администратор " + userObj.Имя + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new PageMenuAdmin());
                            break;
                        case 2: MessageBox.Show("Здравствуйте, Менеджер " + userObj.Имя + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new Menu());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, Заказчик " + userObj.Имя + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new Cataloge(userObj.Код_роли));
                            break;
                        default: MessageBox.Show("Данные не обнаружены!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка"+ ex.Message.ToString() + "Критическая работа приложения!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageCreateAcc());
        }
    }
}
