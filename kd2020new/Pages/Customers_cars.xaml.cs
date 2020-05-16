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
using static kd2020.PodKey;

namespace kd2020.Pages
{
    /// <summary>
    /// Логика взаимодействия для Customers_cars.xaml
    /// </summary>
    public partial class Customers_cars : Page
    {
        public Customers_cars()
        {
            InitializeComponent();
            switch (Roly)
            {
                case "мастер":
                    BtnAdd.Visibility = Visibility.Hidden;
                    BtnAdd.IsEnabled = false;
                    BtnDelete.IsEnabled = false;
                    BtnDelete.Visibility = Visibility.Hidden;
                    break;

                case "главный мастер":
                    break;


            }
             DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Customers_cars.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCustomers(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Customers_carsForRemoving = DgridAvto.SelectedItems.Cast<kd2020.Customers_cars>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {Customers_carsForRemoving.Count} элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    avtoserviceEntities2.GetContext().Customers_cars.RemoveRange(Customers_carsForRemoving);
                    avtoserviceEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Customers_cars.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCustomers((sender as Button).DataContext as Customers_cars));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AE.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Customers_cars.ToList();
            }
        }
    }
}
