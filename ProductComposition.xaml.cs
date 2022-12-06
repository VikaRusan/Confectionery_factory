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
            //DGridComposition.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Сырье.ToList();
           // UpdateProductComposition();
        }
       /* private void UpdateProductComposition()
        {
            var currentProduct = Кондитерская_фабрикаEntities1.GetContext().Сырье.ToList();
            if (ComboComposition.SelectedIndex > 0)
                currentProduct = currentProduct.Where(p => p.Изделия.Contains(ComboComposition.SelectedItem as Изделия)).ToList();
        }
        private void ComboComposition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductComposition();
        }*/
    }
}
