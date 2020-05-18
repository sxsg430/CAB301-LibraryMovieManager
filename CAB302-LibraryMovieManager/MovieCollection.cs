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
        Movie[] MovieList = new Movie[10];

        private void AddNew(Movie item, MovieNode node)
        {
            if (RootElement == null)
            {
                RootElement = new MovieNode(item);
            } else
            {
                if (item.MovieTitle.CompareTo(node.DataNode.MovieTitle) == 0)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new MovieNode(item);
                    }
                    else
                    {
                        AddNew(item, node.LeftNode);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = new MovieNode(item);
                    }
                    else
                    {
                        AddNew(item, node.RightNode);
                    }
                }
            }
        }
        public void AddNewInit(Movie item)
        {
            AddNew(item, RootElement);
        }

        public void OrderTransverseInit()
        {
            InOrderTraverse(RootElement);
            
        }
        private void InOrderTraverse(MovieNode first)
        {
            if (first != null)
            {
                InOrderTraverse(first.LeftNode);
                MovieList[FindFirstNull()] = first.DataNode;
                InOrderTraverse(first.RightNode);
            }
        }



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
