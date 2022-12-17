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
    /// Логика взаимодействия для SupplyProducts.xaml
    /// </summary>
    public partial class SupplyProducts : Page
    {
        public SupplyProducts()
        {
            InitializeComponent();
            DGridSupplyProducts.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Поставки_изделий.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyRawMaterials(null));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyRawMaterials(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSupplyRawMaterials((sender as Button).DataContext as Поставки_сырья));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var supplyRawMaterialsForRemoving = DGridSupplyProducts.SelectedItems.Cast<Поставки_изделий>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить следующие " + supplyRawMaterialsForRemoving.Count() + " элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var entity in DGridSupplyProducts.SelectedItems.Cast<Поставки_изделий>().ToList())
                        Кондитерская_фабрикаEntities1.GetContext().Поставки_изделий.Remove(entity);
                    Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridSupplyProducts.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Поставки_изделий.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Кондитерская_фабрикаEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridSupplyProducts.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Поставки_изделий.ToList();
            }
        }
    }
}
