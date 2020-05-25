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

        public string[] CurrentLoans() // Return an array of strings based on the contents of the master MemberLoans array but with any potential null entries removed.
        {
            string[] filteredLoans = MemberLoans.Where(x => x != null).ToArray();
            return filteredLoans;
        }

        // Add a new title to the user's loan list.
        public void AddMovieLoan(string title)
        {
            MemberLoans[FindFirstNull()] = title; // Find first entry in the MemberLoans array which is null and insert the movie into it.
        }

        // Remove the title at a given position and reset it back to null
        public void DelMovieLoan(int position)
        {
            string MovieNM = MemberLoans[position]; // Obtain the title of the movie located at the given position in the loan list.
            Movie respMovie = Globals.ListOfMovies.SearchByTitle(MovieNM); // Search the BST using the title to get the Movie object for the movie.
            if (respMovie != null) // if the Movie object isn't null (null would signify the movie being removed from the master BST of movies by a staff member), continue.
            {
                Globals.ListOfMovies.RemoveMovie(respMovie); // Remove the original movie from the BST, increase its available copy count by 1 and readd it to the BST.
                respMovie.MovieCopies++;
                Globals.ListOfMovies.AddNewInit(respMovie);
            }
            MemberLoans[position] = null;
        }
    }
}
