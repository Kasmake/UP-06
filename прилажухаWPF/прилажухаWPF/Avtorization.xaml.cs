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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace прилажухаWPF
{
    /// <summary>
    /// Interaction logic for Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Window
    {
        public Avtorization()
        {
            InitializeComponent();
        }

        private void Autorization_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }
        public String ConnectString;
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string ConnectString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection connect = new SqlConnection(ConnectString);
            string command = "SELECT COUNT(*) FROM [Users] WHERE login=@login AND password=@password";
            SqlCommand cmd = new SqlCommand(command, connect);
            cmd.Parameters.AddWithValue("@login", loginBox.Text);
            cmd.Parameters.AddWithValue("@password", passBox.Text);

            connect.Open();

            int count = (int)cmd.ExecuteScalar();

            connect.Close();

            if (count == 1)
            {
                MessageBox.Show("Вы успешно вошли в аккаунт!");

                if (loginBox.Text == "Admin" && passBox.Text == "Admin")
                {
                    Panel Panel = new Panel();
                    Panel.Show();
                    MessageBox.Show("Вы успешно вошли в панель!");
                    Hide();
                }
                else
                {
                    Panel Panel = new Panel();
                    Panel.Show();
                    MessageBox.Show("Вы успешно вошли в панель!");
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
