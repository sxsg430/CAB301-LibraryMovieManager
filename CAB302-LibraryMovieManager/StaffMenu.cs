using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class StaffMenu
    {
        // Inits staff menu and handles its input results.
        public static void StaffMenuInit()
        {
            int result = StaffMainMenu();
            if (result == 1)
            {
                Globals.ListOfMovies.AddNewMovie();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                StaffMenuInit();
            }
            else if (result == 2)
            {
                Globals.ListOfMovies.RemoveMovieEntry();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                StaffMenuInit();
            }
            else if (result == 3)
            {
                Globals.ListOfMembers.RegisterNewUser();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                StaffMenuInit();
            } else if (result == 4)
            {
                Console.Clear();
                SearchPhoneNumber();
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
                StaffMenuInit();
            }
            else if (result == 0)
            {
                Program.MainMenuStart();
            } else
            {
                StaffMenuInit();
            }
        }

        // Draws the staff menu.
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
        // Asks the user to provide a phone number and searches the Array to see if a user has it. If it finds one, it prints out the info about the user.
        public static void SearchPhoneNumber()
        {
            Console.Write("Enter a Phone Number: ");
            string phone = Console.ReadLine();
            int memberID = Globals.ListOfMembers.SearchPhoneNumber(phone); // Search Member array for the phone number.
            if (memberID == -1) // If -1 returned, no users have this number.
            {
                Console.WriteLine("No user exists with this phone number.");
            }
            else // Print out information about the known member. If multiple users share the number, the earliest one in the array will be returned.
            {
                Member knownMember = Globals.ListOfMembers.GetMemberInfo(memberID);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Name: " + knownMember.MemberFirstName + " " + knownMember.MemberLastName);
                Console.WriteLine("Address: " + knownMember.MemberAddress);
                Console.WriteLine("Phone Number: " + knownMember.MemberPhoneNumber);
                Console.WriteLine("Username: " + knownMember.GetUsername());
                Console.WriteLine("Passcode: " + knownMember.MemberPasscode);
                string borrowedMovies = "";
                for (int i = 0; i < knownMember.CurrentLoans().Length; i++) // Convert the array of borrowed movies to a string.
                {
                    borrowedMovies = borrowedMovies + knownMember.CurrentLoans()[i] + ", ";
                }
                Console.WriteLine("Borrowed Movies: " + borrowedMovies);
            }
        }
    }
}
