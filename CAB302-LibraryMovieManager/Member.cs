using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class Member
    {


        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPhoneNumber { get; set; }
        public int MemberPasscode { get; set; }
        public string GetUsername()
        {
            return MemberLastName + MemberFirstName; // Combine Last and First names for the appropriate username structure.
        }
    }
}
