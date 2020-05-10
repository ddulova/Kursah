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
    /// Логика взаимодействия для Roli.xaml
    /// </summary>
    public partial class Roli : Page
    {
        public Roli()
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
            // DgridAvto.ItemsSource = avtoserviceEntities3.GetContext().Role.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddRole(null));
        }



        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var RoleForRemoving = DgridRoli.SelectedItems.Cast<Role>().ToList();

            if (MessageBox.Show($"Удалить следующие {RoleForRemoving.Count()} записи?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    avtoserviceEntities2.GetContext().Role.RemoveRange(RoleForRemoving);
                    avtoserviceEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    DgridRoli.ItemsSource = avtoserviceEntities2.GetContext().Role.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddRole((sender as Button).DataContext as Role));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                avtoserviceEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridRoli.ItemsSource = avtoserviceEntities2.GetContext().Role.ToList();
            }
               
        }
    }
}
