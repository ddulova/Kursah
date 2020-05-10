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
    /// Логика взаимодействия для Masters.xaml
    /// </summary>
    public partial class Masters : Page
    {
        public Masters()
        {
            InitializeComponent();
            switch (Roly)
            {
                case "мастер":
                    BtnAdd.Visibility = Visibility.Hidden;
                    BtnAdd.IsEnabled = false;
                    BtnDelete.IsEnabled = false;
                    BtnDelete.Visibility = Visibility.Hidden;
                    break;

                case "главный мастер":
                    break;


            }
            DgridAvto.ItemsSource = avtoserviceEntities2.GetContext().Masters.ToList();
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
