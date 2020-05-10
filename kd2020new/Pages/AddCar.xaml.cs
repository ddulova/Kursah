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

namespace kd2020.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Page
    {
        private Cars _currentCars = new Cars();
        public AddCar(Cars selectedCars)
        {
            InitializeComponent();

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

                    if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentCars.cars_id != 0 && _currentCars.cars_id > 9999)
                avtoserviceEntities2.GetContext().Cars.Add(_currentCars);
             try
            {
                avtoserviceEntities2.GetContext().SaveChanges();
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
