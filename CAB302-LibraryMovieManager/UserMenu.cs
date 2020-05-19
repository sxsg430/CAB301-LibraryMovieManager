using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class UserMenu
    {
        // Init user menu.
        public static void UserMenuInit()
        {
            int result = UserMainMenu();
            if (result == 1)
            {
                ListAllMovies();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                UserMenuInit();
            }
            else if (result == 2)
            {
                BorrowNewMovie();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                UserMenuInit();
            }
            else if (result == 3)
            {
                ReturnMovie();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                UserMenuInit();
            }
            else if (result == 4)
            {
                ListBorrowedMovies();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                UserMenuInit();
            }
            else if (result == 5)
            {
                // Placeholder
            }
            else if (result == 0)
            {
                Program.MainMenuStart();
            }
        }

        // Display user menu.
        public static int UserMainMenu()
        {
            Console.Clear();
            Console.WriteLine(Globals.CurrentUser);
            Console.WriteLine("===========Member Menu===========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current burrowed movie DVDs");
            Console.WriteLine("5. Display top 10 must popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.Write("Please make a selection (1-5 or 0 to return to main menu): ");
            return int.Parse(Console.ReadLine());
        }

        // Generate a list of all movies currently available in the Movie Collection.
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
        }

        public static void BorrowNewMovie()
        {
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            if (user.CurrentLoans().Length == 10)
            {
                Console.WriteLine("You have reached your limit of borrowed titles. Please return a movie before continuing.");
            } else
            {
                ListAllMovies();
                // TODO: Update the Movie's Copy Count
                Console.WriteLine("You have used " + user.CurrentLoans().Length + " of your 10 loans.");
                Console.Write("Please enter the ID of the movie you would like to borrow: ");
                int response = int.Parse(Console.ReadLine());
                string MovieTitle = Globals.ListOfMovies.MovieList[response].MovieTitle;
                if (user.CurrentLoans().Contains(MovieTitle))
                {
                    Console.WriteLine("You have already borrowed this movie.");
                }
                else
                {
                    user.AddMovieLoan(MovieTitle);
                    Console.WriteLine("Movie Borrowed.");
                }
            }
        }

        public static void ReturnMovie()
        {
            Console.Clear();
            // TODO: Update the Movie's Copy Count
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            if (user.CurrentLoans().Length == 0)
            {
                Console.WriteLine("You have not borrowed any movies. Please borrow one before you can return them.");
            } else
            {
                ListBorrowedMovies();
                Console.WriteLine("You have used " + user.CurrentLoans().Length + " of your 10 loans.");
                Console.Write("Please enter the ID of the movie you would like to return: ");
                int response = int.Parse(Console.ReadLine());
                user.DelMovieLoan(response);
                Console.WriteLine("Movie Returned");
            }
            
        }

        public static void ListBorrowedMovies()
        {
            Console.Clear();
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            Console.WriteLine("Borrowed Movies:");
            Console.WriteLine("----------------");
            for (int i = 0; i < user.CurrentLoans().Length; i++)
            {
                if (user.CurrentLoans()[i] != null)
                {
                    Console.WriteLine(i + " - " + user.CurrentLoans()[i]);
                }

            }
        }
    }
}
