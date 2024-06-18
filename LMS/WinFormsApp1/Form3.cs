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
    public partial class Form3 : Form
    {
        string mysqlconn = "server=127.0.0.1;user=root;database=lms_sdam;password=";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show("An error occurred: Database Error" + ex.Message);
            }
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string bookName = textBoxBook.Text.Trim();
            string author = textBoxAuthorName.Text.Trim();
            string isbn = textBoxISBN.Text.Trim();

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            if (!int.TryParse(isbn, out int isbnNumber))
            {
                MessageBox.Show("ISBN must be a valid integer.");
                return;
            }


            try
            {

                Library library = new Library();
                library.AddBook(bookName, author, isbn, true);
                MessageBox.Show("Book added successfully.");
                LoadBooksData(); // Refresh the DataGridView

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                textBoxBook.Clear();
                textBoxAuthorName.Clear();
                textBoxISBN.Clear();
            }
        }

        private void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBoxAuthorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBook_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
