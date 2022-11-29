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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private Пользователь _currentUser = new Пользователь();
        public AddUser(Пользователь selectedUser)
        {
            if (selectedUser != null)
            {
                _currentUser = selectedUser;
            }
            InitializeComponent();
            DataContext = _currentUser;
            ComboRoles.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Роли.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Имя))
                errors.AppendLine("Укажите имя пользователя");
            if (string.IsNullOrWhiteSpace(_currentUser.Логин))
                errors.AppendLine("Укажите логин пользователя");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentUser.Код == 0)
                Кондитерская_фабрикаEntities1.GetContext().Пользователь.Add(_currentUser);

            try
            {
                Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
