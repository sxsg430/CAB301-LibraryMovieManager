using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                ListAllMovieDetails();
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
                TopTenMovies();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                UserMenuInit();
            }
            else if (result == 0)
            {
                Program.MainMenuStart();
            } else
            {
                UserMenuInit();
            }
        }

        // Display user menu.
        public static int UserMainMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Member Menu===========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current burrowed movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=================================");
            Console.Write("Please make a selection (1-5 or 0 to return to main menu): ");
            return int.Parse(Console.ReadLine());
        }

        // Generate a list of all movies currently available in the Movie Collection.
        public static void ListAllMovies()
        {
            Console.Clear();
            Globals.ListOfMovies.OrderTransverseInit();
            Console.WriteLine("Available Movies:");
            Console.WriteLine("-----------------");
            for (int i = 0; i < Globals.ListOfMovies.MovieList.Length; i++) // For all non-null movies in the In Order Sorted array, print their position and title.
            {
                if (Globals.ListOfMovies.MovieList[i] != null)
                {
                    Console.WriteLine(i + " - " + Globals.ListOfMovies.MovieList[i].MovieTitle);
                }
                
            }
        }

        // Borrows a movie from a list and adds it to the user's data.
        public static void BorrowNewMovie()
        {
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            if (user.CurrentLoans().Length == 10) // If the user's borrow list is 10 (the max), block any new loans.
            {
                Console.WriteLine("You have reached your limit of borrowed titles. Please return a movie before continuing.");
            } else
            {
                ListAllMovies();
                Console.WriteLine("You have used " + user.CurrentLoans().Length + " of your 10 loans."); // Print out how many loans the user has remaining.
                Console.Write("Please enter the ID of the movie you would like to borrow: ");
                string respInput = Console.ReadLine();
                if (Regex.IsMatch(respInput, @"^\d+$") == false) // Regex to catch non-numerical inputs and return an error message.
                {
                    Console.WriteLine("Not a valid ID");
                } else
                {
                    int response;
                    int.TryParse(respInput, out response);
                    Movie respMovie = Globals.ListOfMovies.MovieList[response];
                    if (respMovie != null)
                    {
                        if (user.CurrentLoans().Contains(respMovie.MovieTitle)) // If User's borrowed list already contains this movie, return an error.
                        {
                            Console.WriteLine("You have already borrowed this movie.");
                        }
                        else if (respMovie.MovieCopies == 0) // If no copies are available, return an error.
                        {
                            Console.WriteLine("There are no copies of this movie available to borrow.");
                        }
                        else
                        {
                            Globals.ListOfMovies.RemoveMovie(respMovie); // Remove the old copy of the movie from the BST, decrease its copy count, increase its borrow frequency and add it back to the BST and member's loan list.
                            respMovie.MovieCopies--;
                            respMovie.MovieBorrowed++;
                            Globals.ListOfMovies.AddNewInit(respMovie);
                            user.AddMovieLoan(respMovie.MovieTitle);
                            Console.WriteLine("Movie Borrowed.");
                        }
                    } else
                    {
                        Console.WriteLine("Not a valid ID");
                    }
                }
            }
        }

        // Return a movie a user has borrowed.
        public static void ReturnMovie()
        {
            Console.Clear();
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            if (user.CurrentLoans().Length == 0) // If user hasn't borrowed any movies, return an error.
            {
                Console.WriteLine("You have not borrowed any movies. Please borrow one before you can return them.");
            } else
            {
                ListBorrowedMovies(); // Display list of borrowed movies and the total current loans.
                Console.WriteLine("You have used " + user.CurrentLoans().Length + " of your 10 loans.");
                Console.Write("Please enter the ID of the movie you would like to return: ");
                string responseStr = Console.ReadLine();
                if (Regex.IsMatch(responseStr, @"^\d+$") == false) // Regex to check for non-int characters, return an error if any found.
                {
                    Console.WriteLine("Not a valid ID");
                } else
                {
                    int response;
                    int.TryParse(responseStr, out response);
                    if (response > user.CurrentLoans().Length) // Catch inputs outside the range of the loan list.
                    {
                        Console.WriteLine("Not a valid ID");
                    } else
                    {
                        user.DelMovieLoan(response); // Return the movie.
                        Console.WriteLine("Movie Returned");
                    }
                }
                
            }
            
        }

        // Generate and display a list of borrowed movies for a given user.
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

        // List the detais of all movies.
        public static void ListAllMovieDetails()
        {
            Console.Clear();
            Globals.ListOfMovies.OrderTransverseInit(); // Generate the In Order Transverse array.
            Member user = Globals.ListOfMembers.GetMemberInfo(Globals.CurrentUser);
            Console.WriteLine("Available Movies (" + user.CurrentLoans().Length + "/10 Loans Used):");
            Console.WriteLine();
            for (int i = 0; i < Globals.ListOfMovies.MovieList.Length; i++) // For all non-null movies in the array, print out all their infomation.
            {
                if (Globals.ListOfMovies.MovieList[i] != null)
                {
                    Console.WriteLine(Globals.ListOfMovies.MovieList[i].MovieTitle);
                    Console.WriteLine("Starring: " + Globals.ListOfMovies.MovieList[i].MovieStarring);
                    Console.WriteLine("Director: " + Globals.ListOfMovies.MovieList[i].MovieDirector);
                    Console.WriteLine("Duration: " + Globals.ListOfMovies.MovieList[i].MovieDuration);
                    Console.WriteLine("Genre: " + Globals.ListOfMovies.MovieList[i].MovieGenre);
                    Console.WriteLine("Classification: " + Globals.ListOfMovies.MovieList[i].MovieRating);
                    Console.WriteLine("Available Copies: " + Globals.ListOfMovies.MovieList[i].MovieCopies);
                    Console.WriteLine("Total Borrowed: " + Globals.ListOfMovies.MovieList[i].MovieBorrowed);
                    Console.WriteLine();
                }

            }
        }
        // Quicksort sorting function.
        private static Movie[] QuickSort(Movie[] array)
        {
            Movie[] beforePivot = new Movie[100]; // Using 100 max size for these arrays for testing since the rest of the code only allows less movies. Means I don't have to use any generic/list elements.
            Movie[] Pivot = new Movie[100];
            Movie[] afterPivot = new Movie[100];
            if (array.Length <= 1) // If array only has 1 element, just return it. No reason to sort a list with one element.
            {
                return array;
            } else
            {
                Movie localPivot = array[array.Length / 2]; // Define the middle element as the initial pivot.
                for (int i = 0; i< array.Length; i++) // REVERSED - Reversed for decending order.
                {
                    if (array[i].MovieBorrowed > localPivot.MovieBorrowed) // If the borrow count of the given element is after the pivot, add it to the before list.
                    {
                        beforePivot[FindFirstNull(beforePivot)] = array[i];
                    } else if (array[i].MovieBorrowed < localPivot.MovieBorrowed) // If the borrow count of the given element is before the pivot, add it to the after list.
                    {
                        afterPivot[FindFirstNull(afterPivot)] = array[i];
                    }
                    else // Otherwise add it to the pivot list.
                    {
                        Pivot[FindFirstNull(Pivot)] = array[i];
                    }
                }
                Movie[] runBefore = QuickSort(beforePivot.Where(x => x != null).ToArray()).Where(x => x != null).ToArray(); // Recursively call QuickSort on the before array, filtering out potential null values (potential sideeffect of my code).
                Movie[] runAfter = QuickSort(afterPivot.Where(x => x != null).ToArray()).Where(x => x != null).ToArray(); // Recursively call QuickSort on the after array, filtering out potential null values (potential sideeffect of my code).

                return runBefore.Concat(Pivot.Concat(runAfter)).ToArray(); // Concatenate the three lists together and convert to array.
            }
        }
        
        // Main function for sorting the Top 10 Borrowed Movies.
        public static void TopTenMovies()
        {
            Console.Clear(); // Clear screen and console.
            Movie[] FullMovies = Globals.ListOfMovies.ListOfRealMovies(); // Define list for holding base movie objects.
            Movie[] MovieQuicksort = QuickSort(FullMovies); // Perform quicksort on the list of movies.
            Console.WriteLine("Top 10 Most Borrowed Movies");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Title         | Frequency"); // Adjusted for the Debug content
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(MovieQuicksort[i].MovieTitle + " | " + MovieQuicksort[i].MovieBorrowed);
            }
        }

        // Another function for checking for the first null value.
        private static int FindFirstNull(Movie[] array)
        {
            for (int i = 0; i < array.Length; i++) // For each entry in the array, if it's contents in null return its ID.
            {
                if (array[i] == null)
                {
                    return i;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }
    }
}
