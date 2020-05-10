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

namespace kd2020
{
    /// <summary>
    /// Логика взаимодействия для AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Page
    {
        private Orders _currentOrders = new Orders();
        public AddOrders(Orders selectedOrders)
        {
            InitializeComponent();
            if (selectedOrders != null)
                _currentOrders = selectedOrders;

            DataContext = _currentOrders;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentOrders.orders_id <=0 )
                errors.AppendLine("Укажите номер заказа");

            if (_currentOrders.owners_id <= 0)
                errors.AppendLine("Укажите номеh клиентов");

            if (_currentOrders.cars_id <= 9999)
                errors.AppendLine("Укажите номер машины");

            if (_currentOrders.date_of_receipt == null)
                errors.AppendLine("Укажите дату начала");

            if (_currentOrders.date_expiry == null)
                errors.AppendLine("Укажите дату окончания");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrders.orders_id != 0)
                avtoserviceEntities2.GetContext().Orders.Add(_currentOrders);
            try
            {
                avtoserviceEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
