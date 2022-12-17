using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Confectionery_factory
{
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditOrder(null));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditOrder(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditOrder((sender as Button).DataContext as Заказы));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ordersForRemoving = DGridOrders.SelectedItems.Cast<Заказы>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить следующие " + ordersForRemoving.Count() + " элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var entity in DGridOrders.SelectedItems.Cast<Заказы>().ToList())
                        Кондитерская_фабрикаEntities1.GetContext().Заказы.Remove(entity);
                    Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridOrders.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Кондитерская_фабрикаEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridOrders.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Заказы.ToList();
            }
        }

        private void BtnStat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrderStatistics());
        }
    }
}
