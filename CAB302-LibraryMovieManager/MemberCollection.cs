using System;
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
                for (int i = 0; i < FindFirstNull(); i++) // Iterate over members in array
                {
                    Member select = LibraryMembers[i];
                    int passccode;
                    int.TryParse(password, out passccode);
                    if (select.GetUsername() == username && select.MemberPasscode == passccode)
                    { // If the current member's username and passcode match the ones provided return the position in the array. Continue otherwise.
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
            if (FindFirstNull() == -1) // If the member array is full (no more null values available to overwrite), block new registrations.
            {
                Console.WriteLine("No more members can be registered.");
            } else
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
                int userPwd;
                int.TryParse(Console.ReadLine(), out userPwd); // Convert user passcode to integer, removing non-int characters in the process
                if (userPwd.ToString().Length > 4) // If converted code is longer than 4 characters, truncate it.
                {
                    userPwd = int.Parse(userPwd.ToString().Substring(0, 4));
                    Console.WriteLine("Entered Password is longer than 4 characters, trimming it.");
                }
                newMember.MemberPasscode = userPwd;

                if (SearchUsername(newMember.GetUsername()) == -1) // If the username doesn't already exist, add it.
                {
                    AddNewMember(newMember);
                    Console.WriteLine("Registered: " + newMember.GetUsername() + " - " + newMember.MemberPasscode);
                }
                else // If username does exist, block registration since another member with the same name is already registered.
                {
                    Console.WriteLine("A User with this username already exists.");
                }
            }
        }
        
        // Authenticates a user by taking in a username and password and sending them to the function which scans the array for matching credentials.
        public int AuthenticateUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            int LoginCheck = FindMemberByUsername(username, password); // Search to find a member with a given username and password and return the result.
            return LoginCheck;
        }

        // Searches the array for a Member object containing a specific phone number, returns its position in the array if one is found.
        public int SearchPhoneNumber(string phone)
        {
            for (int i = 0; i < LibraryMembers.Length; i++) // Iterate over full list of members.
            {
                Member currentMember = LibraryMembers[i];
                if (currentMember == null)
                {
                    return -1;
                } else
                {
                    if (currentMember.MemberPhoneNumber == phone) // If the current member's phone number equals the provided one, return their array position.
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

        // Search through the array of members and return the ID of a user with a given username. Used to check for duplicates.
        public int SearchUsername (string username)
        {
            for (int i = 0; i < LibraryMembers.Length; i++)
            {
                Member currentMember = LibraryMembers[i];
                if (currentMember == null)
                {
                    return -1;
                }
                else
                {
                    if (currentMember.GetUsername() == username) // If the current member's username matches the given one, return their array position.
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
            if (LibraryMembers[id] == null)
            {
                return null;
            } else
            {
                return LibraryMembers[id];
            }
        }
    }
}
