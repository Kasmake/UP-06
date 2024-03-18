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

namespace прилажухаWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public String ConnectString;
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            {
                string connection = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
                string command = "INSERT INTO [Users] (login, telephone, email, password) VALUES(@login, @telephone, @email, @password)";
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                    {
                        sqlConnection.Open();
                        sqlCommand.Parameters.AddWithValue("@login", loginBox.Text);
                        sqlCommand.Parameters.AddWithValue("@telephone", telefonBox.Text);
                        sqlCommand.Parameters.AddWithValue("@email", mailBox.Text);
                        sqlCommand.Parameters.AddWithValue("@password", passBox.Text);

                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0 && repassBox.Text == passBox.Text)
                        {
                            MessageBox.Show("Вы успешно зарегестрировались!");
                            sqlConnection.Close();
                            Avtorization Avtorization = new Avtorization();
                            Avtorization.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }
                }
            }
        }

        private void Autorization_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtorization Avtorization = new Avtorization();
            Avtorization.Show();
            Close();
        }
    }
}
