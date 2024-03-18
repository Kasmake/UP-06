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
    /// Логика взаимодействия для UPzakaz.xaml
    /// </summary>
    public partial class UPzakaz : Window
    {
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
        public UPzakaz()
        {
            InitializeComponent();
        }

        private void UPzakaz1_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM UPzakaz", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string insertCommand = "INSERT INTO UPzakaz (id_klienta, id_zapisi, DataZakaza, SummaZakaza, OtsutstvieZapisi) " +
                       "VALUES (@id_klienta, @id_zapisi, @DataZakaza, @SummaZakaza, @OtsutstvieZapisi)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                cmd.Parameters.AddWithValue("@id_klienta", id_klienta.Text);
                cmd.Parameters.AddWithValue("@id_zapisi", id_zapisi.Text);
                cmd.Parameters.AddWithValue("@DataZakaza", DataZakaza.Text);
                cmd.Parameters.AddWithValue("@SummaZakaza", SummaZakaza.Text);
                cmd.Parameters.AddWithValue("@OtsutstvieZapisi", OtsutstvieZapisi.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM UPzakaz", connection);
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
                id_klienta.Text = selectedRow["id_klienta"].ToString();
                id_zapisi.Text = selectedRow["id_zapisi"].ToString();
                DataZakaza.Text = selectedRow["DataZakaza"].ToString();
                SummaZakaza.Text = selectedRow["SummaZakaza"].ToString();
                OtsutstvieZapisi.Text = selectedRow["OtsutstvieZapisi"].ToString();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string updateCommand = "UPDATE UPzakaz SET id_klienta = @id_klienta, id_zapisi = @id_zapisi, " +
                                       "DataZakaza = @DataZakaza, SummaZakaza = @SummaZakaza, OtsutstvieZapisi = @OtsutstvieZapisi WHERE id_zakaza = @id_zakaza";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateCommand, conn);
                    cmd.Parameters.AddWithValue("@id_klienta", selectedRow["id_klienta"]);
                    cmd.Parameters.AddWithValue("@id_zapisi", id_zapisi.Text);
                    cmd.Parameters.AddWithValue("@DataZakaza", DataZakaza.Text);
                    cmd.Parameters.AddWithValue("@SummaZakaza", SummaZakaza.Text);
                    cmd.Parameters.AddWithValue("@OtsutstvieZapisi", OtsutstvieZapisi.Text);
                    cmd.Parameters.AddWithValue("@id_zakaza", selectedRow["id_zakaza"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPzakaz", connection);
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
                string deleteCommand = "DELETE FROM UPzakaz WHERE id_zakaza = @id_zakaza";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
                    cmd.Parameters.AddWithValue("@id_zakaza", selectedRow["id_zakaza"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPzakaz", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    id_klienta.Text = "";
                    id_zapisi.Text = "";
                    DataZakaza.Text = "";
                    SummaZakaza.Text = "";
                    OtsutstvieZapisi.Text = "";
                }
            }
        }
    }
}
