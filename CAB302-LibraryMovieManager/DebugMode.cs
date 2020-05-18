using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class DebugMode
    {
        public static void FillDebugMembers()
        {
            Member member1 = new Member();
            member1.MemberFirstName = "User";
            member1.MemberLastName = "Demo1";
            member1.MemberPhoneNumber = "01001010";
            member1.MemberAddress = "Example Addr 1";
            member1.MemberPasscode = 1111;
            Globals.ListOfMembers.AddNewMember(member1);

            Member member2 = new Member();
            member2.MemberFirstName = "User";
            member2.MemberLastName = "Demo2";
            member2.MemberPhoneNumber = "01001010";
            member2.MemberAddress = "Example Addr 2";
            member2.MemberPasscode = 1111;
            Globals.ListOfMembers.AddNewMember(member2);
        }

        public static void FillDebugMovies()
        {
            Movie movie1 = new Movie();
            movie1.MovieTitle = "Demo Movie #1";
            movie1.MovieStarring = "Example Star";
            movie1.MovieDirector = "Example Director";
            movie1.MovieDuration = "1:33";
            movie1.MovieGenre = Movie.Genre.Drama;
            movie1.MovieRating = Movie.Classification.General;
            movie1.MovieCopies = 3;
            Globals.ListOfMovies.AddNewInit(movie1);

            Movie movie2 = new Movie();
            movie2.MovieTitle = "Demo Movie #2";
            movie2.MovieStarring = "Example Star";
            movie2.MovieDirector = "Example Director";
            movie2.MovieDuration = "1:33";
            movie2.MovieGenre = Movie.Genre.Drama;
            movie2.MovieRating = Movie.Classification.General;
            movie2.MovieCopies = 3;
            Globals.ListOfMovies.AddNewInit(movie2);
        }
    }
}
