using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class StaffMenu
    {
        
        public static void StaffMenuInit()
        {
            int result = StaffMainMenu();
            if (result == 1)
            {
                Movie newMovie = new Movie();
                Console.Clear();
                Console.WriteLine("Available Genres: " + newMovie.ListOfGenres());
                Console.WriteLine("Available Classification: " + newMovie.ListOfClassification());
                Console.Write("Title: ");
                newMovie.MovieTitle = Console.ReadLine();
                Console.Write("Starring: ");
                newMovie.MovieStarring = Console.ReadLine();
                Console.Write("Director: ");
                newMovie.MovieDirector = Console.ReadLine();
                Console.Write("Duration: ");
                newMovie.MovieDuration = Console.ReadLine();
                try
                {
                    Console.Write("Genre: ");
                    string inputGen = Console.ReadLine();
                    newMovie.MovieGenre = (Movie.Genre)Enum.Parse(typeof(Movie.Genre), inputGen, true);
                } catch
                {
                    Console.WriteLine("Invalid Genre.");
                    Console.ReadLine();
                }
                try
                {
                    Console.Write("Classification: ");
                    string inputClass = Console.ReadLine();
                    newMovie.MovieRating = (Movie.Classification)Enum.Parse(typeof(Movie.Classification), inputClass, true);
                }
                catch
                {
                    Console.WriteLine("Invalid Classification.");
                    Console.ReadLine();
                }
                Console.Write("Total Copies: ");
                newMovie.MovieCopies = int.Parse(Console.ReadLine());
                Console.ReadLine();
            }
            else if (result == 3)
            {
                Globals.ListOfMembers.RegisterNewUser();
                StaffMenuInit();
            } else if (result == 4)
            {
                Console.Clear();
                Console.Write("Enter a Phone Number: ");
                string phone = Console.ReadLine();
                int memberID = Globals.ListOfMembers.SearchPhoneNumber(phone);
                if (memberID == -1)
                {
                    Console.WriteLine("This number doesn't exist.");
                    Console.ReadLine();
                    StaffMenuInit();
                } else
                {
                    Member knownMember = Globals.ListOfMembers.GetMemberInfo(memberID);
                    Console.Clear();
                    Console.WriteLine("Name: " + knownMember.MemberFirstName + " " + knownMember.MemberLastName);
                    Console.WriteLine("Address: " + knownMember.MemberAddress);
                    Console.WriteLine("Phone Number: " + knownMember.MemberPhoneNumber);
                    Console.WriteLine("Username: " + knownMember.GetUsername());
                    Console.WriteLine("Passcode: " + knownMember.MemberPasscode);
                    Console.ReadLine();
                    StaffMenuInit();

                }
            }
            else if (result == 0)
            {
                Program.MainMenuStart();
            }
        }
        public static int StaffMainMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Staff Menu============");
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
