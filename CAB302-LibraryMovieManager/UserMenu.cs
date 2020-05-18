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
            if (result == 1)
            {
                ListAllMovies();
            } else if (result == 0)
            {
                Program.MainMenuStart();
            }
        }
        public static int UserMainMenu()
        {
            Console.Clear();
            Console.WriteLine(Globals.CurrentUser);
            Console.WriteLine("===========Member Menu===========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Burrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current burrowed movie DVDs");
            Console.WriteLine("5. Display top 10 must popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.Write("Please make a selection (1-5 or 0 to return to main menu): ");
            return int.Parse(Console.ReadLine());
        }

        public static void ListAllMovies()
        {
            Console.Clear();
            Console.WriteLine("Available Movies:");
            Console.WriteLine("-----------------");
            for (int i = 0; i < Globals.ListOfMovies.MovieList.Length; i++)
            {
                if (Globals.ListOfMovies.MovieList[i] != null)
                {
                    Console.WriteLine(i + " - " + Globals.ListOfMovies.MovieList[i].MovieTitle);
                }
                
            }
            
            Console.ReadLine();
        }
    }
}
