using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Кондитерская_фабрикаEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridProducts.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
            }
        }
    }
   
}
