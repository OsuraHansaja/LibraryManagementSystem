using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [STAThread]
        internal static void Main()
        {
            //Allocating a console for the current calling process
            AllocConsole();
            //handling option exits
            bool exitRequested = false;
            //calling methods to display options and get user inputs
            while (!exitRequested)
            {
                displayOptions();
                string userInput = getUserInput();
                exitRequested = handleUserOption(userInput);

                if (!exitRequested)
                {
                    exitRequested = !continueExecution();
                }
            }
        }
        //Basic initilizations
        private static string username;
        private static string password;
        private static bool isLoggedIn = false;
        private static Member member = new Member("", 0000);
        private static Librarian librarian = new Librarian("", 0000,"");
        private static Book book = new Book(0000,"","","",true);
        private static void displayOptions()
        {
            Console.WriteLine("..........................");
            Console.WriteLine("Library Management System");
            Console.WriteLine("..........................");
            Console.WriteLine("1. Manage Members");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Check Availability");
            Console.WriteLine("5. Open GUI");
            Console.WriteLine("6. Exit");
        }
        private static string getUserInput()
        {
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        private static bool handleUserOption(string option)
        {
            switch (option)
            {
                case "1":
                    if (!isLoggedIn) // Check login status
                    {
                        if (!login()) // If not logged in, attempt to login
                        {
                            Console.WriteLine("Login failed. Access denied.");
                            return false; // Return false to stay in the menu loop
                        }
                        else
                        {
                            isLoggedIn = true; // Set login status to true
                        }
                    }
                    displayManageMembersOptions(); // Proceed with managing members
                    break;
                case "2":
                    member.BorrowBook();
                    break;
                case "3":
                    member.ReturnBook();
                    break;
                case "4":
                    CheckBookAvailability();
                    break;
                case "5":
                    openGUI();
                    break;
                case "6":
                    return true; // Exit
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            return false;
        }
        //Displaying Manage Members options which is only accesible for the librarian user.
        private static void displayManageMembersOptions()
        {
            if (!isLoggedIn) // Check if the user is logged in
            {
                if (!login()) // If not logged in, attempt to log in
                {
                    Console.WriteLine("Login failed. Access denied.");
                    return;
                }
            }

            bool returnToPreviousMenu = false;
            //creating a loop to take options but also leave when needed to the previous menu
            while (!returnToPreviousMenu)
            {
                Console.WriteLine("Manage Members Options:");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Remove Member");
                Console.WriteLine("3. Go back to previous menu");
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        librarian.AddMember();
                        break;
                    case "2":
                        librarian.RemoveMember();
                        break;
                    case "3":
                        // Log out librarian before returning to main menu
                        isLoggedIn = false;
                        returnToPreviousMenu = true; // Set flag to return to previous menu
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        //the login method for librarian
        private static bool login()
        {
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            if (librarian.IsLibrarian(username, password))
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                return false;
            }
        }
        //check book availability method for books using CheckAvailability() from book class
        private static void CheckBookAvailability()
        {
            Console.Write("Enter the name of the book to check availability: ");
            string bookName = Console.ReadLine();

            book.CheckAvailability(bookName);
        }
        //Continuing option selction
        private static bool continueExecution()
        {
            Console.Write("Do you want to continue? (y/n): ");
            string input = Console.ReadLine().Trim().ToLower();
            return input == "y" || input == "Y";
        }
        private static void openGUI()
        {
            // Start the Windows Forms application
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}