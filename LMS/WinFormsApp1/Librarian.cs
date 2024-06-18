using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Librarian : Person
    {
        public int UID { get; private set; }
        public string Password { get; private set; }

        private MySqlConnection connection;

        public Librarian(string name, int uID, string password) : base(name)
        {
            Name = name;
            UID = uID;
            Password = password;
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

        public bool IsLibrarian(string username, string password)
        {
            bool isLibrarian = false;

            try
            {
                connection.Open();
                string query = "SELECT * FROM login WHERE user_name = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                object isLibrarianObj = command.ExecuteScalar();
                if (isLibrarianObj != null && Convert.ToBoolean(isLibrarianObj))
                {
                    isLibrarian = true;
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

            return isLibrarian;
        }

        public void AddMember()
        {
            Console.Write("Enter member name: ");
            string memberName = Console.ReadLine();
            try
            {
                connection.Open();
                string query = "INSERT INTO members (name) " +
                               "VALUES (@name); SELECT LAST_INSERT_ID();";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", memberName);

                // Executing the insert query and get the last inserted ID
                int memberId = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine(" ");
                Console.WriteLine($"Member '{memberName}' added successfully with ID: {memberId}");
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
        public void RemoveMember()
        {
            Console.WriteLine(" ");
            Console.Write("Enter member ID to remove: ");
            int memberIdToRemove;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out memberIdToRemove))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            try
            {
                connection.Open();
                string query = "DELETE FROM members WHERE membership_id = @memberId";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@memberId", memberIdToRemove);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Member with ID {memberIdToRemove} removed successfully.");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Member with ID {memberIdToRemove} not found.");
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
