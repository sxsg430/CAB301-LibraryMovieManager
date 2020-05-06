using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class Program
    {
        public static int MainMenuInterface ()
        {
            Console.Clear();
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

        static void Main(string[] args)
        {
            int mainMenuResult = MainMenuInterface();
            if (mainMenuResult == 0)
            {
                
            } else if (mainMenuResult == 1)
            {
                Console.WriteLine("Staff Login Here");
                Console.Write("Staff Username: ");
                string username = Console.ReadLine();
                Console.Write("Staff Password: ");
                string password = Console.ReadLine();
                if (username.Equals("staff") && password.Equals("today123"))
                {
                    Console.WriteLine("Success");
                    StaffMenu.StaffMainMenu();
                } else
                {
                    Console.WriteLine("Fail");
                }
            } else if (mainMenuResult == 2)
            {
                Console.WriteLine("User Login Here");
            }
            Console.ReadLine();
        }
    }
}
