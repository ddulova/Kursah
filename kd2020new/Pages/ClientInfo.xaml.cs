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
    /// Логика взаимодействия для ClientInfo.xaml
    /// </summary>
    public partial class ClientInfo : Page
    {
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

        }
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
                       
                       id_owners= o.owners_id;
                        first_name = o.first_name;
                        last_name = o.last_name;
                        phone = o.phone;
                        ps = (int)o.passport_series;
                        pn = (int)o.passport_number;

                    }
                }
                List<OwnerView> Lo = new List<OwnerView>();
                foreach (kd2020.Orders o in AE.Orders)
                {
                    if (id_owners == o.owners_id)
                    {
                        ow = new OwnerView();
                        ow.order_id = o.orders_id;
                        ow.dateN = (DateTime)o.date_of_receipt;
                        ow.dateO = (DateTime)o.date_expiry;
                        foreach (Servicess s in AE.Servicess)
                        {
                            if (s.orders_id == ow.order_id)
                            {
                                foreach (Type_of_jobs TJ in AE.Type_of_jobs)
                                {
                                    if (s.id_type == TJ.id_type)
                                    {
                                        ow.Yslga = TJ.names;
                                        ow.priCe = (int)TJ.price;
                                    }
                                }
                            }
                        }
                        ow.firstName = first_name;
                        ow.lastName = last_name;
                        ow.phoneT = phone;
                        ow.pasportSer = ps;
                        ow.pasportNum = pn;
                        Lo.Add(ow);

                    }

                }
               
                InfoCl.ItemsSource = Lo;
            }
        }
    }
}
