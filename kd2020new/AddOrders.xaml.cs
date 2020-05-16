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

namespace kd2020
{
    /// <summary>
    /// Логика взаимодействия для AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Page
    {
        private Orders _currentOrders = new Orders();
        private string Mode;
        private int ID;
        public AddOrders(Orders selectedOrders)
        {
            InitializeComponent();
            if (selectedOrders != null)
            {
                Mode = "Edit";
                IDorders.IsEnabled = false;

            }
            else
            {
                Mode = "New";
                IDorders.IsEnabled = false;

                ID = 1;
                foreach (Orders o in AE.Orders)
                {
                    if (o.orders_id == ID) ID += 1;
                    if (o.orders_id > ID) ID = o.orders_id + 1;

                }
                _currentOrders.orders_id = ID;
            }
            StackPanel sp = new StackPanel();
            foreach (Type_of_jobs TJ in AE.Type_of_jobs)
            {
                CheckBox r = new CheckBox();
                r.Content = TJ.names; r.Tag = "TypeR";
                sp.Children.Add(r);
            }
            TypeR.Content = sp;
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

            List<Type_of_jobs> ltoj = new List<Type_of_jobs>();
            StackPanel sp = (StackPanel) TypeR.Content;
            foreach (CheckBox ra in sp.Children)
            {
                if (ra.IsChecked == true)
                {
                    foreach (Type_of_jobs TJ in AE.Type_of_jobs)
                    {
                        if (ra.Content == TJ.names)
                        {
                            ltoj.Add(TJ);/* MessageBox.Show(TJ.names);*/
                            break;
                        }

                    }
                    
                }
            }

            List<Servicess> ls = new List<Servicess>();

            Random r = new Random();
            int min = 1000, max = -1;

            foreach (Masters m in AE.Masters)
            {
                if (min > m.masters_id) min = m.masters_id;
                if (max < m.masters_id) max = m.masters_id;
            }
            foreach (Type_of_jobs TJ in ltoj)
            {
                Servicess s = new Servicess();
                s.Type_of_jobs = TJ;
                s.Orders = _currentOrders;
                s.orders_id = _currentOrders.orders_id;
                s.servicess_id = 1;
                s.masters_id = 1;
                s.id_type = TJ.id_type;
                foreach (Servicess SE in AE.Servicess)
                {
                    if (s.servicess_id < SE.servicess_id) s.servicess_id = SE.servicess_id + 1;
                    if (s.servicess_id == SE.servicess_id) s.servicess_id += 1;

                }
                foreach (Servicess sn in ls)
                {
                    if (s.servicess_id < sn.servicess_id) s.servicess_id = sn.servicess_id + 1;
                    if (s.servicess_id == sn.servicess_id) s.servicess_id += 1;
                }
                ls.Add(s);
            }
      
          
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //if (_currentOrders.orders_id != 0)
            //{
            //    AE.Orders.Add(_currentOrders);
            //    foreach(Servicess sk in ls)
            //    {
            //        AE.Servicess.Add(sk);
            //    }

            //}
            
            if (Mode == "New")
            {
                foreach (Servicess sk in ls)
                {
                    AE.Servicess.Add(sk);
   
                }
                AE.Orders.Add(_currentOrders);
     
            }
           
            else
            {

                Orders o = AE.Orders.Find(_currentOrders.orders_id);
                o.cars_id = _currentOrders.cars_id;
                o.date_expiry = _currentOrders.date_expiry;
                o.date_of_receipt = _currentOrders.date_of_receipt;
                o.owners_id = _currentOrders.owners_id;
         
            }

            try
            {
                AE.SaveChanges();
      
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
