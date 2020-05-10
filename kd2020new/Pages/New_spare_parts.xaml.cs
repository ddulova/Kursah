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
    /// Логика взаимодействия для New_spare_parts.xaml
    /// </summary>
    public partial class New_spare_parts : Page
    {
        public New_spare_parts()
        {
            InitializeComponent();
            DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().New_spare_parts.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
