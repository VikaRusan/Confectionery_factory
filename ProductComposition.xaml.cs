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
    /// Логика взаимодействия для ProductComposition.xaml
    /// </summary>
    public partial class ProductComposition : Page
    {
        private Изделия _currentProduct = new Изделия();
        public ProductComposition(Изделия selectedProduct)
        {
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
            }

            InitializeComponent();
            DataContext = _currentProduct;

                var productComposition = Кондитерская_фабрикаEntities1.GetContext().Затраты.Where(p => p.Код_изделия == _currentProduct.Код_изделия).ToList();

            DGridComposition.ItemsSource = productComposition;

            var summa = Кондитерская_фабрикаEntities1.GetContext().Затраты.Where(p => p.Код_изделия == _currentProduct.Код_изделия).Sum(p => p.Стоимость).ToString();
            summ.Text = "Стоимость: " + summa + "руб";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductComposition(null));
        }
        private void BtnVisualization_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new VisualizationComposition((sender as Button).DataContext as Затраты));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductComposition((sender as Button).DataContext as Затраты));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var compositionForRemoving = DGridComposition.SelectedItems.Cast<Затраты>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить следующие " + compositionForRemoving.Count() + " элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var entity in DGridComposition.SelectedItems.Cast<Затраты>().ToList())
                        Кондитерская_фабрикаEntities1.GetContext().Затраты.Remove(entity);
                    Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridComposition.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Затраты.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
