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
                    if (select.GetUsername().Equals(username) && select.MemberPasscode.Equals(password))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
    }
}
