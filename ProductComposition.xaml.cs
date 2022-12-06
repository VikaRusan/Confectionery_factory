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
        }
    }
}
