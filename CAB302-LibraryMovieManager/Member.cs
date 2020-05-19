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
        private string[] MemberLoans = new string[10]; // Hold the titles of all movies loaned by the member. Max size of 10 since that is what members are allowed to have.
        public string GetUsername()
        {
            return MemberLastName + MemberFirstName; // Combine Last and First names for the appropriate username structure.
        }

        private int FindFirstNull()
        {
            for (int i = 0; i < MemberLoans.Length; i++) // For each entry in the array, if it's contents in null return its ID.
            {
                if (MemberLoans[i] == null)
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

        // Add a new title to the user's loan list.
        public void AddMovieLoan(string title)
        {
            MemberLoans[FindFirstNull()] = title;
        }

        // Remove the title at a given position and reset it back to null
        public void DelMovieLoan(int position)
        {
            MemberLoans[position] = null;
        }
    }
}
