using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class DebugMode
    {
        // Generate some example users and add them to the member list for testing purposes.
        public static void FillDebugMembers()
        {
            Member member1 = new Member();
            member1.MemberFirstName = "User";
            member1.MemberLastName = "Demo1";
            member1.MemberPhoneNumber = "12";
            member1.MemberAddress = "Example Addr 1";
            member1.MemberPasscode = 1111;
            Globals.ListOfMembers.AddNewMember(member1);

            Member member2 = new Member();
            member2.MemberFirstName = "User";
            member2.MemberLastName = "Demo2";
            member2.MemberPhoneNumber = "123";
            member2.MemberAddress = "Example Addr 2";
            member2.MemberPasscode = 1111;
            Globals.ListOfMembers.AddNewMember(member2);
        }
        // Generate some example movies and add them to the movies list for testing purposes.
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

            Movie movie3 = new Movie();
            movie3.MovieTitle = "Demo Movie #0";
            movie3.MovieStarring = "Example Star";
            movie3.MovieDirector = "Example Director";
            movie3.MovieDuration = "1:33";
            movie3.MovieGenre = Movie.Genre.Drama;
            movie3.MovieRating = Movie.Classification.General;
            movie3.MovieCopies = 3;
            Globals.ListOfMovies.AddNewInit(movie3);
        }
    }
}
