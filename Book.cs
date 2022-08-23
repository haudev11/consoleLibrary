using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLibrary
{
    internal class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string PublicationDate { get; set; }
        public int NumberUserRead { get; set; }
        public double CountStar { get; set; }
        public bool IsBorrowed { get; set; }
        public int Room { get; set; }
        public int Bookshelf { get; set; }

        public int UserID { get; set; }

        public Book()
        {

        }

        private void CheckBorrow()
        {
            if (IsBorrowed)
            {
                Console.WriteLine("This book has been borrowed by someone else");
            } else
            {
                Console.WriteLine("This book is still on the bookshelf");
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Information book");
            Console.WriteLine("Name       : {0}", Name);
            Console.WriteLine("ID         : {0}", ID);
            Console.WriteLine("Author     : {0}", Author);
            Console.WriteLine("Genre      : {0}", Genre);
            Console.WriteLine("PublicationDate      : {0}", PublicationDate);
            Console.WriteLine("Number of readers is : {0}", NumberUserRead);
            Console.WriteLine("Number of stars is   : {0:F1}", (NumberUserRead !=0)? (CountStar / NumberUserRead):(0));
            CheckBorrow();
            Console.WriteLine("--------------------------------------------");
        }
        public void TakeLocation()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("This book is located in room {0} and on bookshelf number {1}",Room, Bookshelf);
            Console.WriteLine("-------------------------------------------------------------------");
        }

    }
}
