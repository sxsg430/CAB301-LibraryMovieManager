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
        private IComparable Data;

        public MovieNode(IComparable item)
        {
            this.Data = item;
            LeftObj = null;
            RightObj = null;
        }

        public IComparable DataNode
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
/*        public void AddNew(IComparable item)
        {
            if (RootElement == null)
            {
                RootElement = new MovieNode(item);
            } else
            {
                AddNewNonRoot(item, RootElement);
            }
        }*/

        private void AddNew(IComparable item, MovieNode node)
        {
            if (RootElement == null)
            {
                RootElement = new MovieNode(item);
            } else
            {
                if (item.CompareTo(node.DataNode) < 0)
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
        public void AddNewInit(IComparable item)
        {
            AddNew(item, RootElement);
        }

        public void OrderTransverseInit()
        {
            Console.Write("InOrder: ");
            InOrderTraverse(RootElement);
            Console.WriteLine();
        }
        private void InOrderTraverse(MovieNode first)
        {
            if (first != null)
            {
                InOrderTraverse(first.LeftNode);
                Console.Write(first.DataNode);
                InOrderTraverse(first.RightNode);
            }
        }
    }
}
