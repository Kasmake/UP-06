using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для UPpostavshik.xaml
    /// </summary>
    public partial class UPpostavshik : Window
    {
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";

        public UPpostavshik()
        {
            InitializeComponent();
        }

        private void uppostavshik_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM UPpostavshik", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string insertCommand = "INSERT INTO UPpostavshik (KompanyName, KontactLico, Adres, Tel, Mail) " +
                       "VALUES (@KompanyName, @KontactLico, @Adres, @Tel, @Mail)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                cmd.Parameters.AddWithValue("@KompanyName", KompanyName.Text);
                cmd.Parameters.AddWithValue("@KontactLico", KontactLico.Text);
                cmd.Parameters.AddWithValue("@Adres", Adres.Text);
                cmd.Parameters.AddWithValue("@Tel", Tel.Text);
                cmd.Parameters.AddWithValue("@Mail", Mail.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM UPpostavshik", connection);
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
                KompanyName.Text = selectedRow["KompanyName"].ToString();
                KontactLico.Text = selectedRow["KontactLico"].ToString();
                Adres.Text = selectedRow["Adres"].ToString();
                Tel.Text = selectedRow["Tel"].ToString();
                Mail.Text = selectedRow["Mail"].ToString();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string updateCommand = "UPDATE UPpostavshik SET KompanyName = @KompanyName, KontactLico = @KontactLico, " +
                                       "Adres = @Adres, Tel = @Tel, Mail = @Mail WHERE id_postavshika = @id_postavshika";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateCommand, conn);
                    cmd.Parameters.AddWithValue("@KompanyName", selectedRow["KompanyName"]);
                    cmd.Parameters.AddWithValue("@KontactLico", KontactLico.Text);
                    cmd.Parameters.AddWithValue("@Adres", Adres.Text);
                    cmd.Parameters.AddWithValue("@Tel", Tel.Text);
                    cmd.Parameters.AddWithValue("@Mail", Mail.Text);
                    cmd.Parameters.AddWithValue("@id_postavshika", selectedRow["id_postavshika"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPpostavshik", connection);
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
                string deleteCommand = "DELETE FROM UPpostavshik WHERE id_postavshika = @id_postavshika";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
                    cmd.Parameters.AddWithValue("@id_postavshika", selectedRow["id_postavshika"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPpostavshik", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    KompanyName.Text = "";
                    KontactLico.Text = "";
                    Adres.Text = "";
                    Tel.Text = "";
                    Mail.Text = "";
                }
            }
        }
    }
}

