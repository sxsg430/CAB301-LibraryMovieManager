using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class UserMenu
    {
        public static void UserMenuInit()
        {
            int result = UserMainMenu();
        }
        public static int UserMainMenu()
        {
            Console.Clear();
            Console.WriteLine(Globals.CurrentUser);
            Console.WriteLine("===========User Menu============");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.Write("Please make a selection (1-4 or 0 to return to main menu): ");
            return int.Parse(Console.ReadLine());
        }
    }
}
