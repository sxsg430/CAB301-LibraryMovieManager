using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    static class Globals
    {
        public static MemberCollection ListOfMembers = new MemberCollection();
        public static MovieCollection ListOfMovies = new MovieCollection();
        public static int CurrentUser = -1;
    }
    class Program
    {
        public static int MainMenuInterface ()
        {
            Console.Clear();
            Console.WriteLine(Globals.ListOfMembers.TextPosition(0));
            Globals.ListOfMovies.OrderTransverseInit();
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
        static void Main(string[] args)
        {
            Globals.ListOfMembers = new MemberCollection();
            Globals.ListOfMovies = new MovieCollection();
            MainMenuStart();
        }
    }
}
