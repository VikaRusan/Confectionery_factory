using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Confectionery_factory
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditOrder : Page
    {
        private Заказы _currentOrder = new Заказы();
        public AddEditOrder(Заказы selectedOrder)
        {
            if (selectedOrder != null)
            {
                _currentOrder = selectedOrder;
            }
            InitializeComponent();
            
            DataContext = _currentOrder;
            ComboConfectionery.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentOrder.Наименование_покупателя))
                errors.AppendLine("Укажите наименование покупателя");
            if (string.IsNullOrWhiteSpace(_currentOrder.ФИО_менеджера))
                errors.AppendLine("Укажите ФИО менеджера");
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
                Кондитерская_фабрикаEntities1.GetContext().Заказы.Add(_currentOrder);
            var er = new List<string>();
            if (_currentOrder.Код_изделия != 0)
            {
                var cost = Кондитерская_фабрикаEntities1.GetContext().Затраты.Where(p => p.Код_изделия == _currentOrder.Код_изделия).AsEnumerable();
               
                foreach (var i in cost)
                {
                    var materials = Кондитерская_фабрикаEntities1.GetContext().Сырье.Where(p => p.Код_сырья == i.Код_сырья).FirstOrDefault();
                    var count = i.Объем_затрат * _currentOrder.Количество_продукции;
                    if (count <= materials.Количество_на_складе)
                    {
                        materials.Количество_на_складе = materials.Количество_на_складе - count;
                    }
                    else
                    {
                        er.Add(i.Сырье.Вид);
                    }
                }
                
            }

            try
            {
                if (er.Count() != 0)
                {
                    string str = "Недостаточно сырья на складе: ";
                    foreach (var i in er)
                    {
                        str += "\n" + i + "\n";
                    }
                    Кондитерская_фабрикаEntities1.GetContext().Заказы.Remove(_currentOrder);

                    if (MessageBox.Show(str + "Вы хотите закупить сырье сейчас?", "Уведомление",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        Manager.MainFrame.Navigate(new AddEditSupplyRawMaterials(null));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager.MainFrame.GoBack();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
