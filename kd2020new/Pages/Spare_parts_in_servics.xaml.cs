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
    /// Логика взаимодействия для Spare_parts_in_servics.xaml
    /// </summary>
    public partial class Spare_parts_in_servics : Page
    {
        public Spare_parts_in_servics()
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
           // DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Spare_parts_in_servics.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSpare_parts_in_servics((sender as Button).DataContext as Spare_parts_in_servics));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSpare_parts_in_servics(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Spare_parts_in_servicsForRemoving = DgridAvto.SelectedItems.Cast<kd2020.Spare_parts_in_servics>().ToList();

            if (MessageBox.Show($"Удалить следующие {Spare_parts_in_servicsForRemoving.Count()} записи?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    avtoserviceEntities2.GetContext().Spare_parts_in_servics.RemoveRange(Spare_parts_in_servicsForRemoving);
                    avtoserviceEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Spare_parts_in_servics.ToList();
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
                avtoserviceEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Spare_parts_in_servics.ToList();
            }
        }
    }
}
