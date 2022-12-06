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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            Manager.MainFrameMenu = MainFrameMenu;
            InitializeComponent();
        }
        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainFrameMenu.Navigate(new Products());
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            MainFrameMenu.Navigate(new Orders());
        }

        private void SupplyRawMaterials_Click(object sender, RoutedEventArgs e)
        {
            MainFrameMenu.Navigate(new SupplyRawMaterialsPage());
        }
    }
}
