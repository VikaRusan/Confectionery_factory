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
    /// Логика взаимодействия для Cataloge.xaml
    /// </summary>
    public partial class Cataloge : Page
    {
        int role;
        public Cataloge(int selectedRole)
        {
            if(selectedRole != 0)
            {
                role = selectedRole;
            }
            InitializeComponent();
            var allTypes = Кондитерская_фабрикаEntities1.GetContext().Категории.ToList();
            allTypes.Insert(0, new Категории
            {
                Наименование = "Все категории"
            });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;
            UpdateCataloge();
            var currentConfectionery = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
            LViewTours.ItemsSource = currentConfectionery;
            
        }
        private void UpdateCataloge()
        {
            var currentConfectionery = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
            if (ComboType.SelectedIndex > 0)
                currentConfectionery = currentConfectionery.Where(p => p.Категории == ComboType.SelectedValue).ToList();

            currentConfectionery = currentConfectionery.Where(p => p.Наименование.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewTours.ItemsSource = currentConfectionery.OrderBy(p => p.Цена_шт).ToList();
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCataloge();
        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCataloge();
        }

        private void btnComposition_Click(object sender, RoutedEventArgs e)
        {
            if (role == 3)
            {
                ProductComposition page = new ProductComposition((sender as Button).DataContext as Изделия);
                page.BtnAddComposition.Visibility = Visibility.Hidden;
                page.BtnAddComposition.IsEnabled = false;
                page.BtnDeleteComposition.Visibility = Visibility.Hidden;
                page.BtnDeleteComposition.IsEnabled = false;
                page.DGridTemp.Visibility = Visibility.Hidden;
                Manager.MainFrame.Navigate(page);
            }
            else
            {
                ProductComposition page = new ProductComposition((sender as Button).DataContext as Изделия);
                page.BtnAddComposition.Visibility = Visibility.Visible;
                page.BtnAddComposition.IsEnabled = true;
                page.BtnDeleteComposition.Visibility = Visibility.Visible;
                page.BtnDeleteComposition.IsEnabled = true;
                page.DGridTemp.Visibility = Visibility.Visible;
                Manager.MainFrame.Navigate(page); 
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Кондитерская_фабрикаEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var currentConfectionery = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
                LViewTours.ItemsSource = currentConfectionery;
            }
        }
    }
}
