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
    /// Логика взаимодействия для AddMasters.xaml
    /// </summary>
    public partial class AddMasters : Page
    {
        private Masters _currentMasters = new Masters();
        public AddMasters(Masters selectedMasters)
        {
            InitializeComponent();

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
    

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentMasters.masters_id != 0)
                avtoserviceEntities2.GetContext().Masters.Add(_currentMasters);
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
