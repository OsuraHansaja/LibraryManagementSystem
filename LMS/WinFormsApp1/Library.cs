using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Library
    {
        private MySqlConnection connection;

        public Library()
        {
            InitializeDatabase();
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

        public void AddBook(string bookName, string author, string isbn, bool availability)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO books (book_name, author, isbn, availability) VALUES (@bookName, @author, @isbn, 1)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@bookName", bookName);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveBook(int book_idToRemove)
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM books WHERE book_id = @book_id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@book_id", book_idToRemove);
                int rowsAffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //public void DisplayAvailableBooks()
        //{
        //    try
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM books WHERE availability = true";

        //        MySqlCommand command = new MySqlCommand(query, connection);
        //        MySqlDataReader reader = command.ExecuteReader();

        //        Console.WriteLine("Available Books:");
        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"Title: {reader["title"]}");
        //            Console.WriteLine($"Author: {reader["author"]}");
        //            Console.WriteLine($"ISBN: {reader["ISBN"]}");
        //            Console.WriteLine($"Availability: {(bool)reader["availability"]}");
        //            Console.WriteLine();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
