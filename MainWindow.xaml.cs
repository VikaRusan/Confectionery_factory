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
using System.IO;

namespace Confectionery_factory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            AppConnect.modelOdb = new Кондитерская_фабрикаEntities1();
            MainFrame.Navigate(new Authorization());
            
        }
        private void ImportImages()
        {
            var fileData = File.ReadAllLines(@"C:\Users\New\Практика\Desktop\изделия.txt");
            var images = Directory.GetFiles(@"C:\Users\New\source\repos\VikaRusan\Confectionery_factory\image");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');
                var tempTour = new Изделия
                {
                    Код_категории = int.Parse(data[0]),
                    Наименование = data[1].Replace("\"", ""),
                    Цена_шт = int.Parse(data[2])
                };
                try
                {
                    tempTour.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Наименование)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Кондитерская_фабрикаEntities1.GetContext().Изделия.Add(tempTour);
                Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Authorization());
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
