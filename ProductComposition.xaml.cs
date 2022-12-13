using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Confectionery_factory
{
    /// <summary>
    /// Логика взаимодействия для ProductComposition.xaml
    /// </summary>
    public partial class ProductComposition : Page
    {
        private Изделия _currentProduct = new Изделия();
        private Кондитерская_фабрикаEntities1 _context = new Кондитерская_фабрикаEntities1();

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

            ChartComposition.ChartAreas.Add(new ChartArea(_currentProduct.Наименование));

            var currentComposition = new Series("Затраты")
            {
                IsValueShownAsLabel = true
            };
            ChartComposition.Series.Add(currentComposition);

            ComboChart.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

        }
        private void BtnAddComposition_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductComposition(null));
        }
        private void BtnEditComposition_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditProductComposition((sender as Button).DataContext as Затраты));
        }
        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if (ComboChart.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = ChartComposition.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();

                var compositionList = _context.Сырье.ToList();
                foreach (var composition in compositionList)
                {
                    currentSeries.Points.AddXY(
                        composition.Вид,
                        _context.Затраты.ToList().Where(p => p.Код_изделия == _currentProduct.Код_изделия
                        && p.Код_сырья == composition.Код_сырья).Sum(p => p.Объем_затрат));
                }
            }
        }
        private void BtnDeleteComposition_Click(object sender, RoutedEventArgs e)
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
