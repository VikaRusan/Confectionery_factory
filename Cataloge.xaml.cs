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
        public Cataloge()
        {
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
                currentConfectionery = currentConfectionery.Where(p => p.Затраты.Contains(ComboType.SelectedItem as Затраты)).ToList();
          
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
    }
}
