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
    /// Логика взаимодействия для AddRole.xaml
    /// </summary> 
    public partial class AddRole : Page
    {
        private Role _currentRoli = new Role();
        public AddRole(Role selectedRole)
        {
            InitializeComponent();

            if (selectedRole != null)
                _currentRoli = selectedRole;

            DataContext = _currentRoli;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentRoli.password == null)
                errors.AppendLine("Введите логин");

            if (_currentRoli.login ==null)
                errors.AppendLine("Логин");
            if (_currentRoli.role1 == null)
                errors.AppendLine("Укажите роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentRoli.masters_id != 0)
                avtoserviceEntities2.GetContext().Role.Add(_currentRoli);
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
