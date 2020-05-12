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
        public void AddNewMember(Member newMember)
        {
            LibraryMembers.Append(newMember);
        }
        public int FindMemberByUsername(string username, string password)
        {
            if (LibraryMembers[0] == null) // Catch login attempts when the member list hasn't been populated.
            {
                return -1;
            } else
            {
                for (int i = 0; i < LibraryMembers.Length; i++)
                {
                    Member select = LibraryMembers[i];
                    Console.WriteLine(i + " - " + select.MemberFirstName + " - " + select.MemberLastName);
                    return 0;
                    /*if (select.GetUsername().Equals(username) && select.MemberPasscode.Equals(password))
                    {
                        return i;
                    }*/
                }
                return -1;
            }
        }
        public string TextPosition(int pos)
        {
            if (LibraryMembers[0] == null)
            {
                return "NULL";
            } else
            {
                return LibraryMembers[pos].GetUsername();
            }
            
        }
        public int SetLength()
        {
            return LibraryMembers.Length;
        }
        private int FindFirstNull()
        {
            for (int i = 0; i < LibraryMembers.Length; i++)
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
            LibraryMembers[FindFirstNull()] = newMember;
            Console.WriteLine("Registered: " + newMember.MemberFirstName + " " + newMember.MemberLastName + " - " + newMember.MemberPasscode);
        }
        
        public int AuthenticateUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine(FindFirstNull());
            /*int LoginCheck = Globals.ListOfMembers.FindMemberByUsername(username, password);
            if (LoginCheck == -1)
            {
                Console.WriteLine("Login Error");
            }
            else
            {
                Console.WriteLine("Login Success");
            }
            */
            return 0;
        }
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

        public Member GetMemberInfo(int id)
        {
            return LibraryMembers[id];
        }
    }
}
