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
    /// Логика взаимодействия для AddCustomers.xaml
    /// </summary>
    public partial class AddCustomers : Page
    {
        private Customers_cars _currentCustomers_cars = new Customers_cars();
        public AddCustomers(Customers_cars selectedCustomers_cars)
        {
            InitializeComponent();
            if (selectedCustomers_cars != null)
                _currentCustomers_cars = selectedCustomers_cars;

            DataContext = _currentCustomers_cars;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
             

            //if (_currentCustomers_cars.date_of_purchase == null)
            //    errors.AppendLine("Укажите дату выпуска");

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            //if (_currentCustomers_cars.cars_id != 0)
            //    avtoserviceEntities2.GetContext().Customers_cars.Add(_currentCustomers_cars);
            //try
            //{
            //    avtoserviceEntities2.GetContext().SaveChanges();
            //    MessageBox.Show("Информация сохранена");
            //    Manager.MainFrame.GoBack();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
    }
}
