using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class StaffMenu
    {
        private static void RegisterNewUser(MemberCollection existingSet)
        {
            Member newMember = new Member();
            Console.Clear();
            Console.WriteLine("Register a new Member");
            Console.WriteLine("=====================");
            Console.Write("First Name: ");
            newMember.MemberFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            newMember.MemberLastName = Console.ReadLine();
            Console.Write("Address: ");
            newMember.MemberAddress = Console.ReadLine();
            Console.Write("Phone Number: ");
            newMember.MemberPhoneNumber = Console.ReadLine();
            Console.Write("Passcode: ");
            newMember.MemberPasscode = int.Parse(Console.ReadLine());
            existingSet.AddNewMember(newMember);
            Console.WriteLine("Registered: " + newMember.MemberFirstName + " " + newMember.MemberLastName + " - " + newMember.MemberPasscode);
        }




        public static void StaffMainMenu(MemberCollection memberSet)
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
            int result = int.Parse(Console.ReadLine());
            if (result == 3)
            {
                RegisterNewUser(memberSet);
            }
        }
    }
}
