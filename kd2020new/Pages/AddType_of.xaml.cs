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
    /// Логика взаимодействия для AddType_of.xaml
    /// </summary>
    public partial class AddType_of : Page
    {
        private Type_of_jobs _currentType = new Type_of_jobs();
        private string Mode;
        private int ID;
        public AddType_of(Type_of_jobs selectedType_of_jobs)
        {
            InitializeComponent();
            if (selectedType_of_jobs != null)
            {
                Mode = "Edit";
                IDtype.IsEnabled = false;

            }
            else
            {
                Mode = "New";
                IDtype.IsEnabled = false;

                ID = 0;
                foreach (Type_of_jobs o in AE.Type_of_jobs)
                {
                    if (o.id_type == ID) ID += 1;
                    if (o.id_type > ID) ID = o.id_type + 1;

                }
                _currentType.id_type = ID;
            }
            if (selectedType_of_jobs != null)
                _currentType = selectedType_of_jobs;

            DataContext = _currentType;
        }

    

    private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
        StringBuilder errors = new StringBuilder();


        if (string.IsNullOrWhiteSpace(_currentType.names))
            errors.AppendLine("Укажите Фамилию");
        
        if (_currentType.guarantee == null)
            errors.AppendLine("Укажите гарантию");
        if (_currentType.price == null)
            errors.AppendLine("Укажите цену");


        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        if (Mode == "New")
            AE.Type_of_jobs.Add(_currentType);
        else
        {

            Type_of_jobs o = AE.Type_of_jobs.Find(_currentType.id_type);
                o.price = _currentType.price;
                o.names = _currentType.names;
                o.guarantee = _currentType.guarantee;
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
