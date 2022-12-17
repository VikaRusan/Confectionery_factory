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
    /// Логика взаимодействия для AddEditSupplyRawMaterials.xaml
    /// </summary>
    public partial class AddEditSupplyRawMaterials : Page
    {
        private Поставки_сырья _currentRawMaterials = new Поставки_сырья();
        public AddEditSupplyRawMaterials(Поставки_сырья selectedRawMaterials)
        {
            if (selectedRawMaterials != null)
            {
                _currentRawMaterials = selectedRawMaterials;
            }
            InitializeComponent();
            DataContext = _currentRawMaterials;
            ComboRawMaterials.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Сырье.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
            StringBuilder errors = new StringBuilder();
            _currentRawMaterials.Дата_поставки = Convert.ToDateTime(DPicker.Text);
            if (string.IsNullOrWhiteSpace(_currentRawMaterials.Организация_поставщика))
                errors.AppendLine("Укажите организацию поставщика");
            if (string.IsNullOrWhiteSpace(_currentRawMaterials.ФИО_менеджера))
                errors.AppendLine("Укажите ФИО менеджера");
            if (_currentRawMaterials.Количество_сырья < 1)
                errors.AppendLine("Укажите количество сырья");
            if (string.IsNullOrWhiteSpace(_currentRawMaterials.Телефон_поставщика))
                errors.AppendLine("Укажите телефон поставщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentRawMaterials.Код_поставки == 0)
                Кондитерская_фабрикаEntities1.GetContext().Поставки_сырья.Add(_currentRawMaterials);

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
