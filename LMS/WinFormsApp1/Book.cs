using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool IsAvailable { get; private set; }

        private MySqlConnection connection;

        public Book(int bookId, string title, string author, string isbn, bool isAvailable)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;
        }

        private void InitializeDatabase()
        {
            string server = "127.0.0.1";
            string database = "lms_sdam";
            string uid = "root";
            string password = "";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }
        //Check avaiability method to see if a book is available or not
        public void CheckAvailability(string bookName)
        {
            try
            {
                InitializeDatabase(); // Initialize the database connection

                connection.Open();

                string query = "SELECT availability FROM books WHERE book_name = @bookName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bookName", bookName);

                object availabilityObj = command.ExecuteScalar();
                if (availabilityObj != null && availabilityObj != DBNull.Value)
                {
                    bool isAvailable = Convert.ToBoolean(availabilityObj);
                    Console.WriteLine($"Book '{bookName}' is {(isAvailable ? "available" : "not available")}.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close(); // Close the database connection
                }
            }
        }

    }
}
