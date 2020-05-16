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
    /// Логика взаимодействия для Glav.xaml
    /// </summary>
    public partial class Glav : Page
    {
        public Glav()
        {
            InitializeComponent();

        }

        private void OpAvt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
            return;
        }

        private void OpCl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Owners());
            return;
        }

        private void OpRoli_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Roli());
            return;
        }
  
    

        private void OpMast_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Masters());
            return;
        }

        private void OpIsl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Type_of());
            return;
        }

      

        private void OpOr(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orders());
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientInfo());
            
        }

        private void CarCl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Customers_cars());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите выйти?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    NavigationService.Navigate(new Page1());
                    Roly = "";
                    break;
            }
          

        }
    }
}
