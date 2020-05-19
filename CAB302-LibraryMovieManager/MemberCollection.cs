using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class MemberCollection
    {
        Member[] LibraryMembers = new Member[10]; // Limit to 10 members

        // Accept a Member and append it to the existing array
        public void AddNewMember(Member newMember)
        {
            LibraryMembers[FindFirstNull()] = newMember;
        }

        // Search the Array for a given username. If the username is found, check to see if the password matches and return the user array position if true.
        public int FindMemberByUsername(string username, string password)
        {
            if (LibraryMembers[0] == null) // Catch login attempts when the member list hasn't been populated.
            {
                return -1;
            } else
            {
                for (int i = 0; i < LibraryMembers.Length; i++) // Iterate over members in array
                {
                    Member select = LibraryMembers[i];
                    if (select.GetUsername() == username && select.MemberPasscode == int.Parse(password)) { // If the current member's username and passcode match the ones provided return the position in the array. Continue otherwise.
                        return i;
                    } else
                    {
                        continue;
                    }
                }
                return -1;
            }
        }
        // DEBUG CODE: Returns the username of the given Member at the position, NULL if there is no user in the position.
        public string TextPosition(int pos)
        {
            if (LibraryMembers[pos] == null)
            {
                return "NULL";
            } else
            {
                return LibraryMembers[pos].GetUsername();
            }
            
        }
        // Finds the first null value in the array of members. Null signifies no user in the slot so it should be overwritten.
        private int FindFirstNull()
        {
            for (int i = 0; i < LibraryMembers.Length; i++) // For each entry in the array, if it's contents in null return its ID.
            {
                if (LibraryMembers[i] == null)
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
        // Form for taking in user input and registering a new user.
        public void RegisterNewUser()
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
            AddNewMember(newMember);
            Console.WriteLine("Registered: " + newMember.MemberFirstName + " " + newMember.MemberLastName + " - " + newMember.MemberPasscode);
        }
        
        // Authenticates a user by taking in a username and password and sending them to the function which scans the array for matching credentials.
        public int AuthenticateUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            int LoginCheck = Globals.ListOfMembers.FindMemberByUsername(username, password);
            return LoginCheck;
        }

        // Searches the array for a Member object containing a specific phone number, returns its position in the array if one is found.
        public int SearchPhoneNumber(string phone)
        {
            for (int i = 0; i < LibraryMembers.Length; i++)
            {
                Member currentMember = LibraryMembers[i];
                if (currentMember == null)
                {
                    return -1;
                } else
                {
                    if (currentMember.MemberPhoneNumber == phone)
                    {
                        return i;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return -1;
        }

        // Returns a Member object from the given position in the array.
        public Member GetMemberInfo(int id)
        {
            return LibraryMembers[id];
        }

        public void ReplaceMemberInfo(int id, Member memberInfo)
        {
            LibraryMembers[id] = memberInfo;
        }
    }
}
