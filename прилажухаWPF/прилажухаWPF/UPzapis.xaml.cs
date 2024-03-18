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
    /// Логика взаимодействия для UPzapis.xaml
    /// </summary>
    public partial class UPzapis : Window
    {
        private string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user227_db;user id=user227_db;password=user227;MultipleActiveResultSets=True;App=EntityFramework";
        public UPzapis()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM UPzapis", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string insertCommand = "INSERT INTO UPzapis (id_postavshika, id_avtor, id_vidjanra, id_vidNositelya, Nazvanie, Cena, OptovayaCena, GodVipuska, KolichestvoVnalichii, Proizvoditel, Prodano) " +
                       "VALUES (@id_postavshika, @id_avtor, @id_vidjanra, @id_vidNositelya, @Nazvanie, @Cena, @OptovayaCena, @GodVipuska, @KolichestvoVnalichii, @Proizvoditel, @Prodano)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(insertCommand, conn);
                cmd.Parameters.AddWithValue("@id_postavshika", id_postavshika.Text);
                cmd.Parameters.AddWithValue("@id_avtor", id_avtor.Text);
                cmd.Parameters.AddWithValue("@id_vidjanra", id_vidjanra.Text);
                cmd.Parameters.AddWithValue("@id_vidNositelya", id_vidNositelya.Text);
                cmd.Parameters.AddWithValue("@Nazvanie", Nazvanie.Text);
                cmd.Parameters.AddWithValue("@Cena", Cena.Text);
                cmd.Parameters.AddWithValue("@OptovayaCena", OptovayaCena.Text);
                cmd.Parameters.AddWithValue("@GodVipuska", GodVipuska.Text);
                cmd.Parameters.AddWithValue("@KolichestvoVnalichii", KolichestvoVnalichii.Text);
                cmd.Parameters.AddWithValue("@Proizvoditel", Proizvoditel.Text);
                cmd.Parameters.AddWithValue("@Prodano", Prodano.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM UPzapis", connection);
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
                id_postavshika.Text = selectedRow["id_postavshika"].ToString();
                id_avtor.Text = selectedRow["id_avtor"].ToString();
                id_vidjanra.Text = selectedRow["id_vidjanra"].ToString();
                id_vidNositelya.Text = selectedRow["id_vidNositelya"].ToString();
                Nazvanie.Text = selectedRow["Nazvanie"].ToString();
                Cena.Text = selectedRow["Cena"].ToString();
                OptovayaCena.Text = selectedRow["OptovayaCena"].ToString();
                GodVipuska.Text = selectedRow["GodVipuska"].ToString();
                KolichestvoVnalichii.Text = selectedRow["KolichestvoVnalichii"].ToString();
                Proizvoditel.Text = selectedRow["Proizvoditel"].ToString();
                Prodano.Text = selectedRow["Prodano"].ToString();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                string updateCommand = "UPDATE UPzapis SET id_postavshika = @id_postavshika, id_avtor = @id_avtor, " +
                                       "id_vidjanra = @id_vidjanra, id_vidNositelya = @id_vidNositelya, Nazvanie = @Nazvanie, Cena = @Cena, " +
                                       "OptovayaCena = @OptovayaCena, GodVipuska = @GodVipuska, KolichestvoVnalichii = @KolichestvoVnalichii, " +
                                       "Proizvoditel = @Proizvoditel, Prodano = @Prodano WHERE id_zapisi = @id_zapisi";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(updateCommand, conn);
                    cmd.Parameters.AddWithValue("@id_postavshika", selectedRow["id_postavshika"]);
                    cmd.Parameters.AddWithValue("@id_avtor", id_avtor.Text);
                    cmd.Parameters.AddWithValue("@id_vidjanra", id_vidjanra.Text);
                    cmd.Parameters.AddWithValue("@id_vidNositelya", id_vidNositelya.Text);
                    cmd.Parameters.AddWithValue("@Nazvanie", Nazvanie.Text);
                    cmd.Parameters.AddWithValue("@Cena", Cena.Text);
                    cmd.Parameters.AddWithValue("@OptovayaCena", OptovayaCena.Text);
                    cmd.Parameters.AddWithValue("@GodVipuska", GodVipuska.Text);
                    cmd.Parameters.AddWithValue("@KolichestvoVnalichii", KolichestvoVnalichii.Text);
                    cmd.Parameters.AddWithValue("@Proizvoditel", Proizvoditel.Text);
                    cmd.Parameters.AddWithValue("@Prodano", Prodano.Text);
                    cmd.Parameters.AddWithValue("@id_zapisi", selectedRow["id_zapisi"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPzapis", connection);
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
                string deleteCommand = "DELETE FROM UPzapis WHERE id_zapisi = @id_zapisi";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
                    cmd.Parameters.AddWithValue("@id_zapisi", selectedRow["id_zapisi"]);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM UPzapis", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGrid.ItemsSource = dataTable.DefaultView;
                    }
                    id_postavshika.Text = "";
                    id_avtor.Text = "";
                    id_vidjanra.Text = "";
                    id_vidNositelya.Text = "";
                    Nazvanie.Text = "";
                    Cena.Text = "";
                    OptovayaCena.Text = "";
                    GodVipuska.Text = "";
                    KolichestvoVnalichii.Text = "";
                    Proizvoditel.Text = "";
                    Prodano.Text = "";
                }
            }
        }
    }
}
