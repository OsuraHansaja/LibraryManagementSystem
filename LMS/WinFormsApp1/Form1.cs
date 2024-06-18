using MySql.Data.MySqlClient;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string mysqlconn = "server=127.0.0.1;user=root;database=lms_sdam;password=";
        bool isLoggedIn = false; // Track login status
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EnableManagementButtons()
        {
            buttonManageBooks.Enabled = true;
            buttonTransactions.Enabled = true;
        }

        private void DisableManagementButtons()
        {
            buttonManageBooks.Enabled = false;
            buttonTransactions.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableManagementButtons(); // Disable management buttons initially
            LoadBooksData();
        }

        private void LoadBooksData()
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn))
                {
                    mySqlConnection.Open();
                    string query = "SELECT book_id, book_name, author, isbn, availability FROM books";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection))
                    {
                        DataTable booksTable = new DataTable();
                        adapter.Fill(booksTable);
                        dataGridViewBooks.DataSource = booksTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonManageBooks_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Please login first.");
            }

        }

        private void buttonTransactions_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Please login first.");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUserName.Text;
                string password = textBoxPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("No Empty Fields Allowed");
                    return;
                }

                using (MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn))
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM login WHERE user_name = @username AND password = @password", mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@username", username);
                        mySqlCommand.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("Login Success");
                                isLoggedIn = true; // Set login status to true
                                EnableManagementButtons(); // Enable management buttons
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Clearing password for security
                textBoxPassword.Clear();
            }

        }
    }
}