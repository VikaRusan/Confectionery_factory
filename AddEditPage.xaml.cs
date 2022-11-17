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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Заказы _currentOrder = new Заказы();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentOrder;
            ComboConfectionery.ItemsSource = Кондитерская_фабрикаEntities.GetContext().Изделия.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentOrder.Наименование_покупателя))
                errors.AppendLine("Укажите наименование покупателя");
            if (string.IsNullOrWhiteSpace(_currentOrder.ФИО_менеджера))
                errors.AppendLine("Укажите наименование покупателя");
            if (_currentOrder.Количество_продукции < 1)
                errors.AppendLine("Укажите количество продукции");
            if (string.IsNullOrWhiteSpace(_currentOrder.Телефон_покупателя))
                errors.AppendLine("Укажите телефон покупателя");
            if (string.IsNullOrWhiteSpace(_currentOrder.Дата.ToString()))
                errors.AppendLine("Укажите дату заказа");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentOrder.Код_заказа == 0)
                Кондитерская_фабрикаEntities.GetContext().Заказы.Add(_currentOrder);

            try
            {
                Кондитерская_фабрикаEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
