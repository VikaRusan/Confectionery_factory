using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Confectionery_factory
{
    /// <summary>
    /// Логика взаимодействия для OrderStatistics.xaml
    /// </summary>
    public partial class OrderStatistics : Page
    {
        private Изделия prod = new Изделия();
        public OrderStatistics()
        {
            InitializeComponent();
            var orders = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();
            var products = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();

            var orderStatistics = orders
                .GroupBy(p => p.Изделия.Наименование)
                .Select(k => new
                {
                    name = k.Key.ToString(),
                    sum = k.Sum(f => f.Количество_продукции)
                });
            DGridOrderStatictics.ItemsSource = orderStatistics;


            ChartComposition.ChartAreas.Add(new ChartArea(prod.Наименование));

            var currentComposition = new Series("Заказы")
            {
                IsValueShownAsLabel = true
            };
            ChartComposition.Series.Add(currentComposition);

            ComboChart.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

        }
        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            var orders = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();
            var products = Кондитерская_фабрикаEntities1.GetContext().Изделия.ToList();

            if (ComboChart.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = ChartComposition.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();

                foreach (var item in products)
                {
                    currentSeries.Points.AddXY(
                        item.Наименование,
                        orders.Where(p => p.Код_изделия == item.Код_изделия).Sum(f => f.Количество_продукции));
                }
            }
        }
    }
}
