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
using System.Data;

namespace прилажухаWPF
{
    /// <summary>
    /// Логика взаимодействия для UPklient.xaml
    /// </summary>
    public partial class UPklient : Window
    {
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
        public UPklient()
        {
            InitializeComponent();
        }

        private void upklient_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM UPklient", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string insertCommand = "INSERT INTO UPklient (FIO, Adres, Tel, Mail) " +
                       "VALUES (@FIO, @Adres, @Tel, @Mail)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                cmd.Parameters.AddWithValue("@FIO", FIO.Text);
                cmd.Parameters.AddWithValue("@Adres", Adres.Text);
                cmd.Parameters.AddWithValue("@Tel", Tel.Text);
                cmd.Parameters.AddWithValue("@Mail", Mail.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM UPklient", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }
        private DataRowView selectedRow;
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = (DataRowView)dataGrid.SelectedItem;

            if (selectedRow != null)
            {
                FIO.Text = selectedRow["FIO"].ToString();
                Adres.Text = selectedRow["Adres"].ToString();
                Tel.Text = selectedRow["Tel"].ToString();
                Mail.Text = selectedRow["Mail"].ToString();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string updateCommand = "UPDATE UPklient SET FIO = @FIO, Adres = @Adres, " +
                                       "Tel = @Tel, Mail = @Mail WHERE id_klienta = @id_klienta";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateCommand, conn);
                    cmd.Parameters.AddWithValue("@FIO", selectedRow["FIO"]);
                    cmd.Parameters.AddWithValue("@Adres", Adres.Text);
                    cmd.Parameters.AddWithValue("@Tel", Tel.Text);
                    cmd.Parameters.AddWithValue("@Mail", Mail.Text);
                    cmd.Parameters.AddWithValue("@id_klienta", selectedRow["id_klienta"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPklient", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string deleteCommand = "DELETE FROM UPklient WHERE id_klienta = @id_klienta";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
                    cmd.Parameters.AddWithValue("@id_klienta", selectedRow["id_klienta"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPklient", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    FIO.Text = "";
                    Adres.Text = "";
                    Tel.Text = "";
                    Mail.Text = "";
                }
            }
        }
    }
}
