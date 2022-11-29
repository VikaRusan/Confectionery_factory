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
    /// Логика взаимодействия для PageMenuAdmin.xaml
    /// </summary>
    public partial class PageMenuAdmin : Page
    {
        public PageMenuAdmin()
        {
            InitializeComponent();
            DGridUsers.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Пользователь.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUser(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditUser((sender as Button).DataContext as Пользователь));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Пользователь>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить следующие " + usersForRemoving.Count() + " элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var entity in DGridUsers.SelectedItems.Cast<Пользователь>().ToList())
                        Кондитерская_фабрикаEntities1.GetContext().Пользователь.Remove(entity);
                    Кондитерская_фабрикаEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridUsers.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Пользователь.ToList();
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
                DGridUsers.ItemsSource = Кондитерская_фабрикаEntities1.GetContext().Пользователь.ToList();
            }
        }
    }
}
