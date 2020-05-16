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
    /// Логика взаимодействия для AddMasters.xaml
    /// </summary>
    public partial class AddMasters : Page
        
    {
        private Masters _currentMasters = new Masters();
        private string Mode;
        private int ID;
        public AddMasters(Masters selectedMasters)
        {
            InitializeComponent();
            if (selectedMasters != null)
            {
                Mode = "Edit";
                IDmasters.IsEnabled = false;

            }
            else
            {
                Mode = "New";
                IDmasters.IsEnabled = false;

                ID = 0;
                foreach (Masters o in AE.Masters)
                {
                    if (o.masters_id == ID) ID += 1;
                    if (o.masters_id> ID) ID = o.masters_id + 1;

                }
                _currentMasters.masters_id = ID;
            }
            if (selectedMasters != null)
                _currentMasters = selectedMasters;

            DataContext = _currentMasters;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (string.IsNullOrWhiteSpace(_currentMasters.last_name))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(_currentMasters.first_name))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentMasters.middle_name))
                errors.AppendLine("Укажите Отчество");
            if (_currentMasters.date_of_employment == null)
                errors.AppendLine("Укажите дату зачисления");
            if (_currentMasters.specialty == null)
                errors.AppendLine("Укажите специальность");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (Mode == "New")
                AE.Masters.Add(_currentMasters);
            else
            {

                Masters o = AE.Masters.Find(_currentMasters.masters_id);
                o.last_name = _currentMasters.last_name;
                o.first_name = _currentMasters.first_name;
                o.middle_name = _currentMasters.middle_name;
                o.passport_number = _currentMasters.passport_number;
                o.passport_series = _currentMasters.passport_series;
                o.phone = _currentMasters.phone;
                o.specialty = _currentMasters.specialty;
                o.date_of_employment = _currentMasters.date_of_employment;
                o.city = _currentMasters.city;
                o.birth = _currentMasters.birth;
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
