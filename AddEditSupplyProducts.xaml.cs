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
    /// Логика взаимодействия для AddEditSupplyProducts.xaml
    /// </summary>
    public partial class AddEditSupplyProducts : Page
    {
        private Поставки_изделий _currentSupply = new Поставки_изделий();
        public AddEditSupplyProducts(Поставки_изделий selectedSupply)
        {
            InitializeComponent();
            if (selectedSupply != null)
            {
                _currentSupply = selectedSupply;
            }
            InitializeComponent();
            DataContext = _currentSupply;
            ComboOrders.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            _currentSupply.Дата_поставки = Convert.ToDateTime(DPicker.Text);
            if (string.IsNullOrWhiteSpace(_currentSupply.Организация_поставщика))
                errors.AppendLine("Укажите организацию поставщика");
            if (string.IsNullOrWhiteSpace(_currentSupply.Телефон_поставщика))
                errors.AppendLine("Укажите телефон поставщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentSupply.Код_пост_изд == 0)
                Кондитерская_фабрикаEntities1.GetContext().Поставки_изделий.Add(_currentSupply);

            try
            {
                Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены", "Уведомление",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
