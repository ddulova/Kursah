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
using System.Data.SqlClient;
using static kd2020.PodKey;

namespace kd2020.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
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
            // DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Cars.ToList();
            // Заполнение DataGrid
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AE.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Cars.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCar(null));

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCar((sender as Button).DataContext as kd2020.Cars));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRemoving = DgridAvto.SelectedItems.Cast<Cars>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {CarsForRemoving.Count} элементов?", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    avtoserviceEntities2.GetContext().Cars.RemoveRange(CarsForRemoving);
                    avtoserviceEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Cars.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
    


    

        
    

