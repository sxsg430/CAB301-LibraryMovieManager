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
            member1.AddMovieLoan("Demo Movie #1");
            member1.AddMovieLoan("Demo Movie #0");
            member1.AddMovieLoan("Demo Movie #A");
            member1.AddMovieLoan("Demo Movie #C");
            member1.AddMovieLoan("Demo Movie #K");
            Globals.ListOfMembers.AddNewMember(member1);

            Member member2 = new Member();
            member2.MemberFirstName = "User";
            member2.MemberLastName = "Demo2";
            member2.MemberPhoneNumber = "123";
            member2.MemberAddress = "Example Addr 2";
            member2.MemberPasscode = 1111;
            member2.AddMovieLoan("Demo Movie #D");
            member2.AddMovieLoan("Demo Movie #K");
            member2.AddMovieLoan("Demo Movie #M");
            member2.AddMovieLoan("Demo Movie #N");
            member2.AddMovieLoan("Demo Movie #Q");
            Globals.ListOfMembers.AddNewMember(member2);

            Member member3 = new Member();
            member3.MemberFirstName = "User";
            member3.MemberLastName = "Demo3";
            member3.MemberPhoneNumber = "123";
            member3.MemberAddress = "Example Addr 2";
            member3.MemberPasscode = 1111;
            member3.AddMovieLoan("Demo Movie #0");
            member3.AddMovieLoan("Demo Movie #1");
            member3.AddMovieLoan("Demo Movie #2");
            member3.AddMovieLoan("Demo Movie #N");
            member3.AddMovieLoan("Demo Movie #Q");
            Globals.ListOfMembers.AddNewMember(member3);

            Member member4 = new Member();
            member4.MemberFirstName = "User";
            member4.MemberLastName = "Demo4";
            member4.MemberPhoneNumber = "123";
            member4.MemberAddress = "Example Addr 2";
            member4.MemberPasscode = 1111;
            member4.AddMovieLoan("Demo Movie #1");
            member4.AddMovieLoan("Demo Movie #2");
            member4.AddMovieLoan("Demo Movie #C");
            member4.AddMovieLoan("Demo Movie #D");
            member4.AddMovieLoan("Demo Movie #K");
            Globals.ListOfMembers.AddNewMember(member4);


            Member member5 = new Member();
            member5.MemberFirstName = "User";
            member5.MemberLastName = "Demo5";
            member5.MemberPhoneNumber = "123";
            member5.MemberAddress = "Example Addr 2";
            member5.MemberPasscode = 1111;
            member5.AddMovieLoan("Demo Movie #0");
            member5.AddMovieLoan("Demo Movie #2");
            member5.AddMovieLoan("Demo Movie #C");
            member5.AddMovieLoan("Demo Movie #K");
            member5.AddMovieLoan("Demo Movie #N");
            Globals.ListOfMembers.AddNewMember(member5);

            Member member6 = new Member();
            member6.MemberFirstName = "User";
            member6.MemberLastName = "Demo6";
            member6.MemberPhoneNumber = "123";
            member6.MemberAddress = "Example Addr 2";
            member6.MemberPasscode = 1111;
            member6.AddMovieLoan("Demo Movie #Q");
            member6.AddMovieLoan("Demo Movie #A");
            member6.AddMovieLoan("Demo Movie #B");
            member6.AddMovieLoan("Demo Movie #D");
            member6.AddMovieLoan("Demo Movie #M");
            Globals.ListOfMembers.AddNewMember(member6);

            Member member7 = new Member();
            member7.MemberFirstName = "User";
            member7.MemberLastName = "Demo7";
            member7.MemberPhoneNumber = "123";
            member7.MemberAddress = "Example Addr 2";
            member7.MemberPasscode = 1111;
            member7.AddMovieLoan("Demo Movie #Q");
            member7.AddMovieLoan("Demo Movie #A");
            member7.AddMovieLoan("Demo Movie #2");
            member7.AddMovieLoan("Demo Movie #0");
            member7.AddMovieLoan("Demo Movie #B");
            Globals.ListOfMembers.AddNewMember(member7);
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
            movie1.MovieBorrowed = 6;
            Globals.ListOfMovies.AddNewInit(movie1);

            Movie movie2 = new Movie();
            movie2.MovieTitle = "Demo Movie #2";
            movie2.MovieStarring = "Example Star";
            movie2.MovieDirector = "Example Director";
            movie2.MovieDuration = "1:33";
            movie2.MovieGenre = Movie.Genre.Action;
            movie2.MovieRating = Movie.Classification.Mature;
            movie2.MovieCopies = 2;
            movie2.MovieBorrowed = 4;
            Globals.ListOfMovies.AddNewInit(movie2);

            Movie movie3 = new Movie();
            movie3.MovieTitle = "Demo Movie #0";
            movie3.MovieStarring = "Example Star";
            movie3.MovieDirector = "Example Director";
            movie3.MovieDuration = "1:33";
            movie3.MovieGenre = Movie.Genre.Adventure;
            movie3.MovieRating = Movie.Classification.MatureAccompanied;
            movie3.MovieCopies = 2;
            movie3.MovieBorrowed = 4;
            Globals.ListOfMovies.AddNewInit(movie3);

            Movie movie4 = new Movie();
            movie4.MovieTitle = "Demo Movie #A";
            movie4.MovieStarring = "Example Star";
            movie4.MovieDirector = "Example Director";
            movie4.MovieDuration = "1:33";
            movie4.MovieGenre = Movie.Genre.Animated;
            movie4.MovieRating = Movie.Classification.ParentalGuidance;
            movie4.MovieCopies = 3;
            movie4.MovieBorrowed = 7;
            Globals.ListOfMovies.AddNewInit(movie4);

            Movie movie5 = new Movie();
            movie5.MovieTitle = "Demo Movie #Q";
            movie5.MovieStarring = "Example Star";
            movie5.MovieDirector = "Example Director";
            movie5.MovieDuration = "1:33";
            movie5.MovieGenre = Movie.Genre.Comedy;
            movie5.MovieRating = Movie.Classification.General;
            movie5.MovieCopies = 2;
            movie5.MovieBorrowed = 6;
            Globals.ListOfMovies.AddNewInit(movie5);

            Movie movie6 = new Movie();
            movie6.MovieTitle = "Demo Movie #C";
            movie6.MovieStarring = "Example Star";
            movie6.MovieDirector = "Example Director";
            movie6.MovieDuration = "1:33";
            movie6.MovieGenre = Movie.Genre.Drama;
            movie6.MovieRating = Movie.Classification.General;
            movie6.MovieCopies = 3;
            movie6.MovieBorrowed = 3;
            Globals.ListOfMovies.AddNewInit(movie6);

            Movie movie7 = new Movie();
            movie7.MovieTitle = "Demo Movie #M";
            movie7.MovieStarring = "Example Star";
            movie7.MovieDirector = "Example Director";
            movie7.MovieDuration = "1:33";
            movie7.MovieGenre = Movie.Genre.Family;
            movie7.MovieRating = Movie.Classification.General;
            movie7.MovieCopies = 4;
            movie7.MovieBorrowed = 2;
            Globals.ListOfMovies.AddNewInit(movie7);

            Movie movie8 = new Movie();
            movie8.MovieTitle = "Demo Movie #B";
            movie8.MovieStarring = "Example Star";
            movie8.MovieDirector = "Example Director";
            movie8.MovieDuration = "1:33";
            movie8.MovieGenre = Movie.Genre.Other;
            movie8.MovieRating = Movie.Classification.General;
            movie8.MovieCopies = 4;
            movie8.MovieBorrowed = 3;
            Globals.ListOfMovies.AddNewInit(movie8);

            Movie movie9 = new Movie();
            movie9.MovieTitle = "Demo Movie #D";
            movie9.MovieStarring = "Example Star";
            movie9.MovieDirector = "Example Director";
            movie9.MovieDuration = "1:33";
            movie9.MovieGenre = Movie.Genre.SciFi;
            movie9.MovieRating = Movie.Classification.General;
            movie9.MovieCopies = 3;
            movie9.MovieBorrowed = 7;
            Globals.ListOfMovies.AddNewInit(movie9);

            Movie movie10 = new Movie();
            movie10.MovieTitle = "Demo Movie #N";
            movie10.MovieStarring = "Example Star";
            movie10.MovieDirector = "Example Director";
            movie10.MovieDuration = "1:33";
            movie10.MovieGenre = Movie.Genre.SciFi;
            movie10.MovieRating = Movie.Classification.General;
            movie10.MovieCopies = 3;
            movie10.MovieBorrowed = 8;
            Globals.ListOfMovies.AddNewInit(movie10);

            Movie movie11 = new Movie();
            movie11.MovieTitle = "Demo Movie #K";
            movie11.MovieStarring = "Example Star";
            movie11.MovieDirector = "Example Director";
            movie11.MovieDuration = "1:33";
            movie11.MovieGenre = Movie.Genre.Drama;
            movie11.MovieRating = Movie.Classification.General;
            movie11.MovieCopies = 2;
            movie11.MovieBorrowed = 4;
            Globals.ListOfMovies.AddNewInit(movie11);
        }
    }
}
