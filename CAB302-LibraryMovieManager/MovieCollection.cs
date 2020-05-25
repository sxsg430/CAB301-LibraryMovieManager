using System;
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
        public Movie[] MovieList = new Movie[100]; // 100 movie max for testing.

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

        // Wrapper function for InOrderTransverse. Passes InOrderTransverse the root node. Empties array used to store the result of In Order Transverse due to previous issues with duplicating results.
        public void OrderTransverseInit()
        {
            EmptyArray();
            InOrderTraverse(RootElement);
        }

        // Completes an In Order Transverse on the BST.
        private void InOrderTraverse(MovieNode first)
        {
            if (first != null) // If the provided node isn't null, continue.
            {
                InOrderTraverse(first.LeftNode); // Recursively run InOrder on the left node.
                //Console.WriteLine(first.DataNode.MovieTitle);
                MovieList[FindFirstNull()] = first.DataNode; // Write the node's data to the first null object in the movie list.
                InOrderTraverse(first.RightNode); // Recursively run InOrder on the right node.
            }
        }

        // Iterate over the BST and remove a specific movie element.
        public void RemoveMovie(Movie item)
        {
            MovieNode RootNode = RootElement; // Root Node
            MovieNode ParentNode = null; // Parent of Root. Initially set to null.
            if (item == null)
            {
                Console.WriteLine("This movie does not exist");
            } else
            {
                while ((RootNode != null) && (item.MovieTitle.CompareTo(RootNode.DataNode.MovieTitle) != 0)) // While the Root Node isn't empty and the provided Movie's title doesn't equal the root one, continue loop.
                {
                    ParentNode = RootNode;
                    if (item.MovieTitle.CompareTo(RootNode.DataNode.MovieTitle) < 0) // If the provided title is earlier in the sequence than the root node, update RootNode to its Left Node. Otherwise update to Right.
                        RootNode = RootNode.LeftNode;
                    else
                        RootNode = RootNode.RightNode;
                }

                if (RootNode != null) // If RootNode isn't null (search ran successfully), continue.
                {
                    if ((RootNode.LeftNode != null) && (RootNode.RightNode != null)) // If both nodes on the current root aren't empty, run the below code.
                    {
                        if (RootNode.LeftNode.RightNode == null) // If the Right node of the Root's current Left node is empty, update the appropriate variables.
                        {
                            RootNode.DataNode = RootNode.LeftNode.DataNode;
                            RootNode.LeftNode = RootNode.LeftNode.LeftNode;
                        }
                        else
                        {
                            MovieNode LNode = RootNode.LeftNode;
                            MovieNode LNodeParent = RootNode; // Set the Parent of Left Node to current Root Node
                            while (LNode.RightNode != null) // While the right node of the current left node is null, reassign the parent node to the current left node and the Left Node to the current one's right node.
                            {
                                LNodeParent = LNode;
                                LNode = LNode.RightNode;
                            }
                            RootNode.DataNode = LNode.DataNode; // Update the root's contents to the contents of the current Left Node
                            LNodeParent.RightNode = LNode.LeftNode; // Update the parent of the current Left Node's right branch to the contents of the left node.
                        }
                    }
                    else
                    {
                        MovieNode ChildNode;
                        if (RootNode.LeftNode != null) // If the left node of the root isn't null, assign the child node to it. Otherwise use Right
                            ChildNode = RootNode.LeftNode;
                        else
                            ChildNode = RootNode.RightNode;

                        if (RootNode == RootElement) // If the Root Node equals the one set in the main collection, reassign it to the Child Node.
                            RootElement = ChildNode;
                        else // Otherwise if the Root Node is the same as the parent's left, assign the parent's left to the Child. Otherwise assign the right.
                        {
                            if (RootNode == ParentNode.LeftNode)
                                ParentNode.LeftNode = ChildNode;
                            else
                                ParentNode.RightNode = ChildNode;
                        }
                    }
                }
            

            }
        }







        // Adds New Movie. Creates a new movie object and accepts user input to fill its options.
        public void AddNewMovie()
        {
            Movie newMovie = new Movie();
            Console.Clear();
            Console.WriteLine("Available Genres: " + newMovie.ListOfGenres()); // Print out list of Genres and Ratings to provide user with acceptable inputs.
            Console.WriteLine("Available Classification: " + newMovie.ListOfClassification());
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Movie movSearch = SearchByTitle(title);
            if (movSearch != null) // If the title already exists in the movie BST, assume it is a duplicate.
            {
                if (movSearch.MovieTitle.Equals(title)) // Notify the user about the duplicate and ask them if they want to add additional copies to the movie.
                {
                    Console.WriteLine("Another Movie already has this title.");
                    Console.Write("How many additional copies do you want to add? ");
                    int newCopy;
                    int.TryParse(Console.ReadLine(), out newCopy);
                    RemoveMovie(movSearch); // Remove old movie, update copy count and readd the movie.
                    Movie newMov = movSearch;
                    newMov.MovieCopies += newCopy;
                    AddNewInit(newMov);
                }
            }
            else
            { // Otherwise assume it is a new movie and continue asking users for input.
                newMovie.MovieTitle = title;
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
                    Console.WriteLine("Invalid Genre. Defaulting to Other.");
                    newMovie.MovieGenre = Movie.Genre.Other;
                }
                try
                {
                    Console.Write("Classification: ");
                    string inputClass = Console.ReadLine();
                    newMovie.MovieRating = (Movie.Classification)Enum.Parse(typeof(Movie.Classification), inputClass, true);
                }
                catch
                {
                    Console.WriteLine("Invalid Classification. Defaulting to General.");
                    newMovie.MovieRating = Movie.Classification.General;
                }
                Console.Write("Total Copies: ");
                int copies;
                int.TryParse(Console.ReadLine(), out copies);
                if (copies > 0) // If copy count is positive, set it. Otherwise default to 6 (my debug value). Used for handling improper (string) inputs in the copy field.
                {
                    newMovie.MovieCopies = copies;
                }
                else
                {
                    Console.WriteLine("Invalid Copy Count provided. Defaulting to 6");
                    newMovie.MovieCopies = 6;
                }

                newMovie.MovieBorrowed = 0;
                AddNewInit(newMovie);
            }
        }

        public void RemoveMovieEntry()
        {
            EmptyArray();
            OrderTransverseInit();
            Console.Clear();
            Console.WriteLine("Available Movies:");
            Console.WriteLine("-----------------");
            for (int i = 0; i < MovieList.Length; i++)
            {
                if (MovieList[i] != null)
                {
                    Console.WriteLine(i + " - " + TextPosition(i));
                }
            }
            Console.WriteLine("");
            Console.Write("Please enter the ID of the movie you would like to remove: ");
            int response = int.Parse(Console.ReadLine());
            Movie chosenMovie = MovieList[response];
            RemoveMovie(chosenMovie);
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

        // Clean and prepare the array. Fixes some issues with duplicated results.
        public void EmptyArray()
        {
            for (int i = 0; i < MovieList.Length; i++) // For all values in the Movie List array, rewrite them back to null.
            {
                MovieList[i] = null;
            }
        }

        // Get the title of a movie at a given position. Has error handling for non-existent movies.
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

        // Search array for a movie with a given title. If one is found, return the Movie object.
        public Movie SearchByTitle(string title)
        {
            OrderTransverseInit();
            for (int i = 0; i < FindFirstNull(); i++) // For all entries up to the first null value.
            {
                if (MovieList[i].MovieTitle.Equals(title)) { // If title equals the provided one, return the Movie object.
                    return MovieList[i];
                } else
                {
                    continue;
                }
            }
            return null;
        }

        // Return array of Movie objects with the null values removed.
        public Movie[] ListOfRealMovies()
        {
            OrderTransverseInit();
            return MovieList.Where(x => x != null).ToArray();
        }
    }
}
