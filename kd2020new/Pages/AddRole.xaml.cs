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
    /// Логика взаимодействия для AddRole.xaml
    /// </summary> 
    public partial class AddRole : Page
    {
        private Role _currentRole = new Role();
        private string Mode;
        private int ID;
        public AddRole(Role selectedRole)
        {
            InitializeComponent();
             if (selectedRole != null)
            {
                Mode = "Edit";
                IDmas.IsEnabled = false;

            }
            else
            {
                Mode = "New";
                IDmas.IsEnabled = false;

                ID = 0;
                foreach (Role o in AE.Role)
                {
                    if (o.masters_id == ID) ID += 1;
                    if (o.masters_id > ID) ID = o.masters_id + 1;

                }
                _currentRole.masters_id = ID;
            }
            if (selectedRole != null)
                _currentRole = selectedRole;


            DataContext = _currentRole;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentRole.password == null)
                errors.AppendLine("Введите пароль");

            if (_currentRole.login ==null)
                errors.AppendLine("логин");
            if (_currentRole.role1 == null)
                errors.AppendLine("Укажите роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (Mode == "New")
                AE.Role.Add(_currentRole);
            else
            {

                Role o = AE.Role.Find(_currentRole.masters_id,_currentRole.login);
                o.login = _currentRole.login;
                o.password = _currentRole.password;
                o.role1 = _currentRole.role1;
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
