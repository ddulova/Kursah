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
using kd2020.Pages;
using static kd2020.PodKey;
namespace kd2020
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {// Удаление данных <Д
                //AE.Servicess.RemoveRange(AE.Servicess);
                //AE.Orders.RemoveRange(AE.Orders);
                //AE.Customers_cars.RemoveRange(AE.Customers_cars);
                //AE.Cars.RemoveRange(AE.Cars);
                //AE.Owners.RemoveRange(AE.Owners);
                //AE.SaveChanges();
            }
            MainFrame.Navigate(new Page1());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }
    }
}
