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
    /// Логика взаимодействия для AddOwners.xaml
    /// </summary>
    public partial class AddOwners : Page
    {
        private Owners _currentOwners = new Owners();
        private string Mode;
        private int ID;
        public AddOwners(Owners selectedOwners)
      
        {
            InitializeComponent();
            if (selectedOwners != null)
            {
                Mode = "Edit";
                IDowners.IsEnabled = false;

            }
            else
            {
                Mode = "New";
                IDowners.IsEnabled = false;

                ID = 1;
                foreach(Owners o in AE.Owners)
                {
                    if (o.owners_id == ID) ID += 1;
                    if (o.owners_id > ID) ID = o.owners_id + 1;

                }
                _currentOwners.owners_id = ID;
            }
            if (selectedOwners != null)
                _currentOwners = selectedOwners;
            

            DataContext = _currentOwners;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

         
            
            if (string.IsNullOrWhiteSpace(_currentOwners.last_name))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(_currentOwners.first_name))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentOwners.middle_name))
                errors.AppendLine("Укажите Отчество");
         
           


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (Mode == "New")
                AE.Owners.Add(_currentOwners);
            else
            {

                Owners o = AE.Owners.Find(_currentOwners.owners_id);
                o.last_name = _currentOwners.last_name;
                o.first_name = _currentOwners.first_name;
                o.middle_name = _currentOwners.middle_name;
                o.passport_number = _currentOwners.passport_number;
                o.passport_series = _currentOwners.passport_series;
                o.phone = _currentOwners.phone;
                o.city = _currentOwners.city;
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
