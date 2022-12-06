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
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
            DGridProducts.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductComposition((sender as Button).DataContext as Изделия));
        }
    }
}
