using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    public class Movie
    {
        // Enums for Genre and Rating
        public enum Genre
        {
            Drama,
            Adventure,
            Family,
            Action,
            SciFi, // "Sci-Fi" renamed to "SciFi" due to C# rules on using special characters ("-").
            Comedy,
            Animated,
            Thriller,
            Other
        }
        public enum Classification
        {
            General,
            ParentalGuidance,
            Mature,
            MatureAccompanied

        }

        // Getters/Setters
        public string MovieTitle { get; set; }
        public string MovieStarring { get; set; }
        public string MovieDirector { get; set; }
        public string MovieDuration { get; set; }
        public Genre MovieGenre { get; set; }
        public Classification MovieRating { get; set; }
        public int MovieCopies { get; set; }
        public int MovieBorrowed { get; set; }

        // Obtain list of genres for displaying to users.
        public string ListOfGenres()
        {
            string genres = "";
            foreach (string i in Enum.GetNames(typeof(Genre))) // Convert names of enum values into strings and append them to the main string to be returned.
            {
                genres = genres + i + " ";
            }
            return genres;
        }
        // Obtain list of rating classifications for displaying to users.
        public string ListOfClassification()
        {
            string genres = "";
            foreach (string i in Enum.GetNames(typeof(Classification))) // Convert names of enum values into strings and append them to the main string to be returned.
            {
                genres = genres + i + " ";
            }
            return genres;
        }
    }
}
