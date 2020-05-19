using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB302_LibraryMovieManager
{
    class MovieNode
    {
        private MovieNode LeftObj;
        private MovieNode RightObj;
        private Movie Data;
        

        public MovieNode(Movie item)
        {
            this.Data = item;
            LeftObj = null;
            RightObj = null;
        }

        public Movie DataNode
        {
            get { return Data; }
            set { Data = value; }
        }
        public MovieNode LeftNode
        {
            get { return LeftObj; }
            set { LeftObj = value; }
        }
        public MovieNode RightNode
        {
            get { return RightObj; }
            set { RightObj = value; }
        }

    }
    class MovieCollection
    {
        public MovieNode RootElement { get; set; }
        public Movie[] MovieList = new Movie[20]; // 20 movie max for testing.

        // Add New Movie to the BST.
        private void AddNew(Movie item, MovieNode node)
        {
            if (RootElement == null)
            {
                RootElement = new MovieNode(item); // If the root element is null, construct a node with the given movie and write to it.
            } else
            {
                if (item.MovieTitle.CompareTo(node.DataNode.MovieTitle) < 0) // If String.CompareTo returns less than 0 when comparing the passed movie's title vs the one in the node. Continue in Left branch.
                {
                    if (node.LeftNode == null) // If the left Node of the provided node is empty, set it to the provided movie.
                    {
                        node.LeftNode = new MovieNode(item);
                    }
                    else
                    {
                        AddNew(item, node.LeftNode); // Otherwise, recursively call AddNew again with the same movie and the left node.
                    }
                }
                else
                {
                    if (node.RightNode == null) // If the right Node of the provided node is empty, set it to the provided movie.
                    {
                        node.RightNode = new MovieNode(item);
                    }
                    else
                    {
                        AddNew(item, node.RightNode); // Otherwise, recursively call AddNew again with the same movie and the right node.
                    }
                }
            }
        }

        // Wrapper function for AddNew. Calls AddNew with the provided Movie and the RootElement.
        public void AddNewInit(Movie item)
        {
            AddNew(item, RootElement);
        }

        // Wrapper function for InOrderTransverse. Passes InOrderTransverse the root node.
        public void OrderTransverseInit()
        {
            InOrderTraverse(RootElement);
            
        }

        // Completes an In Order Transverse on the BST.
        private void InOrderTraverse(MovieNode first)
        {
            if (first != null) // If the provided node isn't null, continue.
            {
                InOrderTraverse(first.LeftNode); // Recursively run InOrder on the left node.
                MovieList[FindFirstNull()] = first.DataNode; // Write the node's data to the first null object in the movie list.
                InOrderTraverse(first.RightNode); // Recursively run InOrder on the right node.
            }
        }


        // Adds New Movie. Creates a new movie object and accepts user input to fill its options.
        public void AddNewMovie()
        {
            Movie newMovie = new Movie();
            Console.Clear();
            Console.WriteLine("Available Genres: " + newMovie.ListOfGenres());
            Console.WriteLine("Available Classification: " + newMovie.ListOfClassification());
            Console.Write("Title: ");
            newMovie.MovieTitle = Console.ReadLine();
            Console.Write("Starring: ");
            newMovie.MovieStarring = Console.ReadLine();
            Console.Write("Director: ");
            newMovie.MovieDirector = Console.ReadLine();
            Console.Write("Duration: ");
            newMovie.MovieDuration = Console.ReadLine();
            try
            {
                Console.Write("Genre: ");
                string inputGen = Console.ReadLine();
                newMovie.MovieGenre = (Movie.Genre)Enum.Parse(typeof(Movie.Genre), inputGen, true);
            }
            catch
            {
                Console.WriteLine("Invalid Genre.");
                Console.ReadLine();
            }
            try
            {
                Console.Write("Classification: ");
                string inputClass = Console.ReadLine();
                newMovie.MovieRating = (Movie.Classification)Enum.Parse(typeof(Movie.Classification), inputClass, true);
            }
            catch
            {
                Console.WriteLine("Invalid Classification.");
                Console.ReadLine();
            }
            Console.Write("Total Copies: ");
            newMovie.MovieCopies = int.Parse(Console.ReadLine());
            try
            {
                AddNewInit(newMovie);
                Console.WriteLine("Add Successful");
            } catch
            {
                Console.WriteLine("Add Failed");
            }
            

            Console.ReadLine();
            StaffMenu.StaffMenuInit();
        }

        // Finds the first null value in the array of members. Null signifies no user in the slot so it should be overwritten.
        private int FindFirstNull()
        {
            for (int i = 0; i < MovieList.Length; i++) // For each entry in the array, if it's contents in null return its ID.
            {
                if (MovieList[i] == null)
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

        // Clean and prepare the array. Unsure if required but at one stage the code needed it.
        public void prepareArray()
        {
            MovieList.Initialize();
        }

        // DEBUG CODE: Returns the username of the given Member at the position, NULL if there is no user in the position.
        public string TextPosition(int pos)
        {
            if (MovieList[pos] == null)
            {
                return "NULL";
            }
            else
            {
                return MovieList[pos].MovieTitle;
            }

        }

    }
}
