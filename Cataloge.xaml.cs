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

            var currentTours = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();
            LViewTours.ItemsSource = currentTours;
        }
        private void UpdateTours()
        {
            var currentTours = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();

            currentTours = currentTours.Where(p => p.Наименование.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
