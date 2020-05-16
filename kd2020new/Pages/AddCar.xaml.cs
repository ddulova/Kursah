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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Page
    {
        private string Mode;
        private Cars _currentCars = new Cars();
        public AddCar(Cars selectedCars)
        {
            InitializeComponent();
            if (selectedCars != null)
            {
                OwnersList.Visibility = Visibility.Hidden;
                Mode = "Edit";
                IDCAR.IsEnabled = false;


            }
            else
            {
                OwnersList.Visibility = Visibility.Visible;
                StackPanel sp = new StackPanel();
                foreach (kd2020.Owners o in AE.Owners)
                {
                    RadioButton r = new RadioButton();
                    r.Content = o.last_name + " " + o.first_name;
                    r.GroupName = "Owners_names";
                    sp.Children.Add(r);
                }
                OwnersList.Content = sp;
                Mode = "New";
                IDCAR.IsEnabled = true;

            }

            if (selectedCars != null)
                _currentCars = selectedCars;

            DataContext = _currentCars;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentCars.cars_id <= 9999)
                errors.AppendLine("Укажите пятизначный номер");
            

            if (string.IsNullOrWhiteSpace(_currentCars.mark))
                errors.AppendLine("Укажите марку машины");
            if (_currentCars.year_of_issue == null)
                errors.AppendLine("Укажите дату выпуска");
            int oId = -1;
            if (Mode == "New")
            {
                StackPanel sp = (StackPanel)OwnersList.Content;
                
                foreach (RadioButton r in sp.Children)
                {
                    if (r.IsChecked == true)
                    {
                        foreach (kd2020.Owners o in AE.Owners)
                        {
                            //MessageBox.Show((o.last_name + " " + o.first_name)+" " +(r.Content));
                            if ((o.last_name + " " + o.first_name) == (string)(r.Content)) 
                            {
                                oId = o.owners_id;
                               
                                
                            }
                        }
                        
                    }
                }
                if (oId == -1) errors.AppendLine("Выберите владельца машины");
            }
          
                    if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;

            }

            if (Mode == "New")
            {

                AE.Cars.Add(_currentCars);
                kd2020.Customers_cars cc = new kd2020.Customers_cars();
                cc.Owners = AE.Owners.Find(oId);
                cc.Cars = _currentCars;
                cc.date_of_purchase = _currentCars.year_of_issue;
                AE.Customers_cars.Add(cc);
            }
            else
            {

                Cars o = AE.Cars.Find(_currentCars.cars_id);
                o.mark = _currentCars.mark;
                o.year_of_issue = _currentCars.year_of_issue;
            }

            try
            {
                AE.SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
