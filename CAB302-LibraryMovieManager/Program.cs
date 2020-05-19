using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    static class Globals
    {
        public static int DebugMode = 1; // Controls Debug Mode. 1 fills users and movies for testing.
        public static MemberCollection ListOfMembers = new MemberCollection(); // Collection of Members
        public static MovieCollection ListOfMovies = new MovieCollection(); // Collection of Movies
        public static int CurrentUser = -1; // Indicator of the current user. Simplifies accessing user data.
        
    }
    class Program
    {
        // Main Menu. Displays options, takes and returns the user's input.
        public static int MainMenuInterface ()
        {
            Globals.CurrentUser = -1; // Reset CurrentUser to -1. If this menu is open, no user should be logged in.
            Console.Clear();
            Console.WriteLine(Globals.ListOfMembers.TextPosition(0)); // DEBUG CODE
            Globals.ListOfMovies.OrderTransverseInit();
            Console.WriteLine(Globals.ListOfMovies.TextPosition(0)); // DEBUG CODE
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("===========Main Menu============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");
            Console.WriteLine("");
            Console.Write("Please make a selection (1-2, or 0 to exit): ");
            int result = int.Parse(Console.ReadLine());
            return result;
        }

        // Starts the main menu and handles the results from the user's input.
        public static void MainMenuStart()
        {
            int mainMenuResult = MainMenuInterface();
            if (mainMenuResult == 0)
            {
                Console.WriteLine("");
                Console.Write("Exiting...");
                Console.ReadLine();
            }
            else if (mainMenuResult == 1)
            {
                Console.Write("Staff Username: ");
                string username = Console.ReadLine();
                Console.Write("Staff Password: ");
                string password = Console.ReadLine();
                if (username.Equals("staff") && password.Equals("today123"))
                {
                    Console.WriteLine("Success");
                    StaffMenu.StaffMenuInit();
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }
            else if (mainMenuResult == 2)
            {
                int loginResult = Globals.ListOfMembers.AuthenticateUser();
                if (loginResult != -1)
                {
                    Globals.CurrentUser = loginResult;
                    UserMenu.UserMenuInit();
                } else
                {
                    Console.WriteLine("Login Error. Credentials may be incorrect.");
                    Console.ReadLine();
                }
                
            }
        }

        // Init Function, delcares the Arrays. If DebugMode is enabled, it calls the functions to fill the arrays with example content and then starts the Main Menu.
        static void Main(string[] args)
        {
            Globals.ListOfMembers = new MemberCollection();
            Globals.ListOfMovies = new MovieCollection();
            Globals.ListOfMovies.EmptyArray();
            if (Globals.DebugMode == 1)
            {
                DebugMode.FillDebugMembers();
                DebugMode.FillDebugMovies();
            }
            MainMenuStart();
        }
    }
}
