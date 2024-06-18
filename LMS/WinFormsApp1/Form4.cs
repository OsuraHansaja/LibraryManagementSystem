using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        string mysqlconn = "server=127.0.0.1;user=root;database=lms_sdam;password=";
        public Form4()
        {
            InitializeComponent();
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
                MessageBox.Show("An error occurred: Database Error" + ex.Message);
            }
        }

        private void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            string bookIdToRemove = textBoxBookID.Text.Trim();
            if (string.IsNullOrEmpty(bookIdToRemove))
            {
                MessageBox.Show("Please enter the ID of the book to remove.");
                return;
            }

            if (!int.TryParse(bookIdToRemove, out int bookID))
            {
                MessageBox.Show("Invalid ID. Please enter a valid ID.");
                return;
            }

            try
            {
                Library library = new Library();
                library.RemoveBook(bookID);
                MessageBox.Show("Book removed successfully.");
                LoadBooksData(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                textBoxBookID.Clear();
            }

        }

        private void labelISBN_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBookID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadBooksData();
        }

        private void pictureBoxBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();

        }
    }
}
