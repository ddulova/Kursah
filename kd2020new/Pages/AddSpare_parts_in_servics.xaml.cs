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
    /// Логика взаимодействия для AddSpare_parts_in_servics.xaml
    /// </summary>
    public partial class AddSpare_parts_in_servics : Page
    {
        private Spare_parts_in_servics _currentSpare_parts_in_servics = new Spare_parts_in_servics();
        public AddSpare_parts_in_servics(Spare_parts_in_servics selectedSpare_parts_in_servics)
        {
            InitializeComponent();
            if (selectedSpare_parts_in_servics != null)
                _currentSpare_parts_in_servics = selectedSpare_parts_in_servics;

            DataContext = _currentSpare_parts_in_servics;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //StringBuilder errors = new StringBuilder();
        

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            //if (_currentSpare_parts_in_servics == 0)
            //    avtoserviceEntities2.GetContext().Spare_parts_in_servics.Add(_currentSpare_parts_in_servics);
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
