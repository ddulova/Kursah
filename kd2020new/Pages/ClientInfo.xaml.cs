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
using System.IO;


namespace kd2020.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientInfo.xaml
    /// </summary>
    
     
    public partial class ClientInfo : Page
    {
        int types;
        public ClientInfo()
        {
            InitializeComponent();
            StackPanel sp = new StackPanel();
            foreach(kd2020.Owners o in AE.Owners)
            {
                RadioButton r = new RadioButton();
                r.GroupName = "Own";
                r.Content = o.last_name + " " + o.first_name;
                r.Checked += CheckOwners;
                sp.Children.Add(r);

            }

            ClInfo.Content = sp;

            sp = new StackPanel();
            foreach (kd2020.Cars o in AE.Cars)
            {
                RadioButton r = new RadioButton();
                r.GroupName = "Carss";
                r.Content = o.cars_id;
                r.Checked += CheckCars;
                sp.Children.Add(r);

            }
            CarInfo.Content = sp;

        }
        public class OwnerView
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public int pasportNum { get; set; }
            public int pasportSer { get; set; }
            public string Yslga { get; set; }
            public int priCe { get; set; }
            public string phoneT { get; set; }
            public DateTime dateN { get; set; }
            public DateTime dateO { get; set; }
            public int order_id { get; set; }

            public int cars_id { get; set; }


        }
        List<OwnerView> outOwners;
        private void CheckOwners(object sender, RoutedEventArgs e)
        {

            OwnerView ow;
            string last_name = "", first_name="", phone = ""; int ps=0, pn=0;
            if (sender is RadioButton)
            {

                int id_owners = 0;
                RadioButton r = (RadioButton)sender;
                foreach (kd2020.Owners o in AE.Owners)
                {
                    if (o.last_name + " " + o.first_name == (string)r.Content)
                    {

                        id_owners = o.owners_id;
                        first_name = o.first_name;
                        last_name = o.last_name;
                        phone = o.phone;
                        ps = (int)o.passport_series;
                        pn = (int)o.passport_number;

                    }
                }
            List<OwnerView> Lo = new List<OwnerView>();
                foreach (Servicess s in AE.Servicess)
                {
                    if (s.Orders.owners_id == id_owners)
                    {
                        ow = new OwnerView();
                        ow.order_id = s.Orders.orders_id;
                        ow.priCe =(int) s.Type_of_jobs.price;
                        ow.Yslga = s.Type_of_jobs.names;
                        ow.dateO =(DateTime) s.Orders.date_expiry;
                        ow.dateN = (DateTime)s.Orders.date_of_receipt;
                        ow.cars_id = (int)s.Orders.cars_id;
                        ow.firstName = first_name;
                        ow.lastName = last_name;
                        ow.phoneT = phone;
                        ow.pasportSer = ps;
                        ow.pasportNum = pn;
                        Lo.Add(ow);
                    }

                }


            
                InfoCl.ItemsSource = Lo;
                outOwners = Lo;
                                                                                             
            }
        }



        private void CheckCars(object sender, RoutedEventArgs e)
        {

            OwnerView ow;
            
            if (sender is RadioButton)
            {

                int id_owners = 0;
                string last_name = "", first_name = "", phone = ""; int ps = 0, pn = 0;
                RadioButton r = (RadioButton)sender;
                foreach (kd2020.Customers_cars o in AE.Customers_cars)
                {
                    if (o.cars_id == (int)r.Content)
                    {
                        id_owners = o.owners_id;
                        last_name = AE.Owners.Find(id_owners).last_name;
                        first_name = AE.Owners.Find(id_owners).first_name;
                        phone = AE.Owners.Find(id_owners).phone;
                        ps = (int)AE.Owners.Find(id_owners).passport_series;
                        pn = (int) AE.Owners.Find(id_owners).passport_number;

                    }
                }
                List<OwnerView> Lo = new List<OwnerView>();
                foreach (Servicess s in AE.Servicess)
                {
                    if (s.Orders.owners_id == id_owners)
                    {
                        ow = new OwnerView();
                        ow.order_id = s.Orders.orders_id;
                        ow.priCe = (int)s.Type_of_jobs.price;
                        ow.Yslga = s.Type_of_jobs.names;
                        ow.dateO = (DateTime)s.Orders.date_expiry;
                        ow.dateN = (DateTime)s.Orders.date_of_receipt;
                        ow.cars_id = (int)s.Orders.cars_id;
                        ow.firstName = first_name;
                        ow.lastName = last_name;
                        ow.phoneT = phone;
                        ow.pasportSer = ps;
                        ow.pasportNum = pn;
                        Lo.Add(ow);
                    }

                }
                InfoCl.ItemsSource = Lo;
                outOwners = Lo;

            }
        }



        private void Pesh_Click(object sender, RoutedEventArgs e)
        {
            int Summ = 0;
            StreamWriter sw = new StreamWriter("out.txt");
            sw.WriteLine("Чек на услугу");
            sw.WriteLine("Клиент: " + outOwners[0].lastName + " " + outOwners[0].firstName + " " + outOwners[0].pasportSer + " " + outOwners[0].pasportNum);
            foreach (OwnerView o in outOwners)
            {
                Summ += o.priCe;
                sw.WriteLine( "Наименование услуги: " + o.Yslga + " Номер машины: " + o.cars_id + " Цена: " + o.priCe + " Дата окончания: " + o.dateO);
            }
            sw.WriteLine("_____________________________________________");
            sw.WriteLine("На общую сумму: " + Summ);
            sw.WriteLine("_____________________________________________");
            sw.WriteLine("Спасибо, что пользуетесь нашим автосервисом!");
            sw.Close();
            MessageBox.Show("Сохранено");
        }

        private void ChangeTypeSearch(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton r)
            {
                PolePoi.Visibility = Visibility.Visible;
                PB.Visibility = Visibility.Visible;
                switch (r.Content)
                {
                    case "По клиенту":
                        CarInfo.Visibility = Visibility.Hidden; CarInfo.IsEnabled = false;
                        ClInfo.Visibility = Visibility.Visible; ClInfo.IsEnabled = true;
                        types = 1;

                        break;
                    case "По машине":
                        ClInfo.Visibility = Visibility.Hidden; ClInfo.IsEnabled = false;
                        CarInfo.Visibility = Visibility.Visible; CarInfo.IsEnabled = true;
                        types = 0;
                        break;
                }
            }
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            if(PolePoi.Text != "")
            {
                switch (types)
                {
                    case 1:
                        StackPanel sp = new StackPanel();
                        foreach (kd2020.Owners o in AE.Owners)
                        {
                            if ((o.last_name + " " + o.first_name).Contains(PolePoi.Text))
                            {

                                RadioButton r = new RadioButton();
                                r.GroupName = "Own";
                                r.Content = o.last_name + " " + o.first_name;
                                r.Checked += CheckOwners;
                                sp.Children.Add(r);

                            }
                        }

                        ClInfo.Content = sp;
                        break;
                    case 0:
                        StackPanel sc = new StackPanel();
                        foreach (kd2020.Cars o in AE.Cars)
                        {
                            if ((o.cars_id == Convert.ToInt32(PolePoi.Text))||(o.mark == PolePoi.Text))
                            {

                                RadioButton r = new RadioButton();
                                r.GroupName = "Carss";
                                r.Content = o.cars_id;
                                r.Checked += CheckCars;
                                sc.Children.Add(r);

                            }
                        }

                        CarInfo.Content = sc;
                        break;
                }
            }
            else
            {
                NavigationService.Navigate(new ClientInfo());

            }
        }

        private void PolePoi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
