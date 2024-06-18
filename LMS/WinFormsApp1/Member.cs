using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Member : Person
    {
        public int MembershipID { get; private set; }

        private MySqlConnection connection;

        public Member(string name, int membershipID) : base(name)
        {
            Name = name;
            MembershipID = membershipID;
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

        public void BorrowBook()
        {
            // Accepting a valid member ID
            int memberId;
            while (true)
            {
                Console.Write("Enter your membership ID: ");
                string input = Console.ReadLine();

                try
                {
                    memberId = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            // Check if the provided membership ID exists in the database
            if (!IsMemberExists(memberId))
            {
                Console.WriteLine("Invalid membership ID. Borrowing book failed.");
                return;
            }

            Console.Write("Enter the title of the book to borrow: ");
            string bookTitle = Console.ReadLine();

            try
            {
                connection.Open();

                // Check if the book is available
                string checkAvailabilityQuery = "SELECT * FROM books WHERE book_name = @book_name AND availability = true";
                MySqlCommand checkAvailabilityCmd = new MySqlCommand(checkAvailabilityQuery, connection);
                checkAvailabilityCmd.Parameters.AddWithValue("@book_name", bookTitle);
                using (MySqlDataReader bookReader = checkAvailabilityCmd.ExecuteReader())
                {
                    if (bookReader.Read())
                    {
                        // Book found, displaying its details
                        Console.WriteLine("------------");
                        Console.WriteLine("Book Details");
                        Console.WriteLine("------------");
                        Console.WriteLine($"Book ID: {bookReader["book_id"]}");
                        Console.WriteLine($"Book Name: {bookReader["book_name"]}");
                        Console.WriteLine($"Author: {bookReader["author"]}");
                        Console.WriteLine($"ISBN: {bookReader["isbn"]}");

                        int bookId = Convert.ToInt32(bookReader["book_id"]);

                        // Close the bookReader before executing the INSERT command
                        bookReader.Close();

                        // Insert transaction record
                        string borrowQuery = "INSERT INTO transactions (member_id, book_id, transaction_type, transaction_date) " +
                                             "VALUES (@memberId, @bookId, 'borrow', NOW())";
                        MySqlCommand borrowCmd = new MySqlCommand(borrowQuery, connection);
                        borrowCmd.Parameters.AddWithValue("@memberId", memberId);
                        borrowCmd.Parameters.AddWithValue("@bookId", bookId);
                        borrowCmd.ExecuteNonQuery();

                        // Update book availability to false
                        UpdateBookAvailability(bookId, false);

                        Console.WriteLine("");
                        Console.WriteLine($"Member with ID '{memberId}' has borrowed '{bookTitle}'.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Book is not available for borrowing.");
                    }
                }
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
        public void ReturnBook()
        {
            //Accepting a valid member ID
            int memberId;
            while (true)
            {
                Console.Write("Enter your membership ID: ");
                string input = Console.ReadLine();

                try
                {
                    memberId = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            // Checking if the provided membership ID exists in the database
            if (!IsMemberExists(memberId))
            {
                Console.WriteLine("Invalid membership ID. Returning book failed.");
                return;
            }

            Console.Write("Enter the title of the book to return: ");
            string bookTitle = Console.ReadLine();

            try
            {
                connection.Open();
                // Retrieve the book ID
                string getBookIdQuery = "SELECT book_id FROM books WHERE book_name = @book_name";
                MySqlCommand getBookIdCmd = new MySqlCommand(getBookIdQuery, connection);
                getBookIdCmd.Parameters.AddWithValue("@book_name", bookTitle);
                object bookIdObj = getBookIdCmd.ExecuteScalar();
                if (bookIdObj == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                int bookId = Convert.ToInt32(bookIdObj);

                // Checking if the member has borrowed the book
                string checkBorrowQuery = "SELECT transaction_id FROM transactions WHERE member_id = @memberId AND book_id = @bookId AND transaction_type = 'borrow'";
                MySqlCommand checkBorrowCmd = new MySqlCommand(checkBorrowQuery, connection);
                checkBorrowCmd.Parameters.AddWithValue("@memberId", memberId); 
                checkBorrowCmd.Parameters.AddWithValue("@bookId", bookId);
                object transactionIdObj = checkBorrowCmd.ExecuteScalar();
                if (transactionIdObj == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Member with ID '{memberId}' has not borrowed '{bookTitle}'.");
                    return;
                }

                // Insert transaction record for returning book
                string returnQuery = "INSERT INTO transactions (member_id, book_id, transaction_type, transaction_date) " +
                                     "VALUES (@memberId, @bookId, 'return', NOW())";
                MySqlCommand returnCmd = new MySqlCommand(returnQuery, connection);
                returnCmd.Parameters.AddWithValue("@memberId", memberId); 
                returnCmd.Parameters.AddWithValue("@bookId", bookId);
                returnCmd.ExecuteNonQuery();

                // Update book availability to true
                UpdateBookAvailability(bookId, true);
                Console.WriteLine("");
                Console.WriteLine($"Member with ID '{memberId}' has returned '{bookTitle}'.");
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

        //Checking to see if the memebr actually exists or not
        private bool IsMemberExists(int memberId)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM members WHERE membership_id = @memberId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@memberId", memberId);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        //Updating the books availability
        private void UpdateBookAvailability(int bookId, bool availability)
        {
            string query = "UPDATE books SET availability = @availability WHERE book_id = @bookId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@availability", availability);
            command.Parameters.AddWithValue("@bookId", bookId);
            command.ExecuteNonQuery();
        }

        public void DisplayBorrowedBooks()
        {
            try
            {
                connection.Open();
                string query = "SELECT b.* FROM transactions t " +
                               "JOIN books b ON t.book_id = b.book_id " +
                               "WHERE t.member_id = @memberId AND t.transaction_type = 'borrow'";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@memberId", MembershipID);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"{Name}'s Borrowed Books:");
                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["title"]}");
                    Console.WriteLine($"Author: {reader["author"]}");
                    Console.WriteLine($"ISBN: {reader["ISBN"]}");
                    Console.WriteLine($"Availability: {(bool)reader["availability"]}");
                }
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


    }
}
