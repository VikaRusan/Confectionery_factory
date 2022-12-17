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
    /// Логика взаимодействия для AddEditProductComposition.xaml
    /// </summary>
    public partial class AddEditProductComposition : Page
    {
        private Затраты _currentComposition = new Затраты();
        public AddEditProductComposition(Затраты selectedComposition)
        {

            if (selectedComposition != null)
            {
                _currentComposition = selectedComposition;
            }

            InitializeComponent();
            DataContext = _currentComposition;
            ComboComposition.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Сырье.ToList();
          

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (txbCount.Text == "0.00")
            {
                txbCount.BorderBrush = Brushes.Red;
                BtnAddSupply.IsEnabled = true;
                BtnSave.IsEnabled = false;
                errors.AppendLine("Закончилось сырье на складе");
            }
            else
            {
                BtnAddSupply.IsEnabled = false;
                BtnSave.IsEnabled = true;
            }
            if (_currentComposition.Объем_затрат == 0)
                errors.AppendLine("Укажите количество требуемого сырья");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentComposition.Код_затрат == 0)
                Кондитерская_фабрикаEntities1.GetContext().Затраты.Add(_currentComposition);

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

        private void BtnAddSupply_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyRawMaterials(null));
        }
    }
}
