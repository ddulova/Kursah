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
using System.Data.SqlClient;
using static kd2020.PodKey;
using kd2020.Pages;


namespace kd2020.Pages



{
    public partial class Page1 : Page
    {
        

        public Page1()
        {

            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                List<Role> rols = AE.Role.ToList();
                foreach (Role r in rols)
                {

                    if (r.login == login.Text && r.password == password.Text)
                    {
                        MessageBox.Show("Вход выполнен"); Roly = r.role1;


                        NavigationService.Navigate(new Glav());
                    }
                    
                }
            }
          
        }
    }
}

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //        connectionString = @"Data Source=LAPTOP-JFBLDFC0\SQLEXPRESS02;Initial Catalog=avtoservice;Integrated Security=true;";

//        }



//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            SqlConnection connection = new SqlConnection(connectionString);
//            try
//            {
//                connection.Open();
//                MessageBox.Show("Подключение выполнено!");
//                string query = "SELECT login, password, role FROM dbo.Role WHERE login=@login AND password=@password";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@login", login.Text);
//                command.Parameters.AddWithValue("@password", password.Text);
//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    NavigationService.Navigate(new Glav());
//                    return;
//                }
//                MessageBox.Show("Пользователь не найден!");
//            }
//            catch (SqlException ex)

//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//    }
//}



/*  using (var context = new PodKey())
  {
      var user = context.Role.FirstOrDefault(x => x.login == login.Text && x.password==password.Text);

      if (user != null)
          NavigationService.Navigate(new Glav());

  }*/








