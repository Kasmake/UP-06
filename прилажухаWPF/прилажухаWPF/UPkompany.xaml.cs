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
    /// Interaction logic for UPkompany.xaml
    /// </summary>
    public partial class UPkompany : Window
    {
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
        public UPkompany()
        {
            InitializeComponent();
        }
        private void upkompany_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM UPkompany", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string insertCommand = "INSERT INTO UPkompany (Pribil, Ubitok, KolvoOtsutZapisey, DataNachala, DataKonca) " +
                       "VALUES (@Pribil, @Ubitok, @KolvoOtsutZapisey, @DataNachala, @DataKonca)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                cmd.Parameters.AddWithValue("@Pribil", Pribil.Text);
                cmd.Parameters.AddWithValue("@Ubitok", Ubitok.Text);
                cmd.Parameters.AddWithValue("@KolvoOtsutZapisey", KolvoOtsutZapisey.Text);
                cmd.Parameters.AddWithValue("@DataNachala", DataNachala.Text);
                cmd.Parameters.AddWithValue("@DataKonca", DataKonca.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM UPkompany", connection);
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
                Pribil.Text = selectedRow["Pribil"].ToString();
                Ubitok.Text = selectedRow["Ubitok"].ToString();
                KolvoOtsutZapisey.Text = selectedRow["KolvoOtsutZapisey"].ToString();
                DataNachala.Text = selectedRow["DataNachala"].ToString();
                DataKonca.Text = selectedRow["DataKonca"].ToString();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string updateCommand = "UPDATE UPkompany SET Pribil = @Pribil, Ubitok = @Ubitok, " +
                                       "KolvoOtsutZapisey = @KolvoOtsutZapisey, DataNachala = @DataNachala, DataKonca = @DataKonca WHERE id_kompany = @id_kompany";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateCommand, conn);
                    cmd.Parameters.AddWithValue("@Pribil", selectedRow["Pribil"]);
                    cmd.Parameters.AddWithValue("@Ubitok", Ubitok.Text);
                    cmd.Parameters.AddWithValue("@KolvoOtsutZapisey", KolvoOtsutZapisey.Text);
                    cmd.Parameters.AddWithValue("@DataNachala", DataNachala.Text);
                    cmd.Parameters.AddWithValue("@DataKonca", DataKonca.Text);
                    cmd.Parameters.AddWithValue("@id_kompany", selectedRow["id_kompany"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPkompany", connection);
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
                string deleteCommand = "DELETE FROM UPkompany WHERE id_kompany = @id_kompany";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
                    cmd.Parameters.AddWithValue("@id_kompany", selectedRow["id_kompany"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPkompany", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    Pribil.Text = "";
                    Ubitok.Text = "";
                    KolvoOtsutZapisey.Text = "";
                    DataNachala.Text = "";
                    DataKonca.Text = "";
                }
            }
        }
    }
}
