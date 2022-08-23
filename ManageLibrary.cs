using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLibrary
{
    internal class ManageLibrary
    {
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<string> Logs { get; set; }

        private void ReadListUsers()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\users.txt";
            string[] usersData = File.ReadAllLines(path);
            int numberUsers = int.Parse(usersData[0]);
            int currentLine = 1;
            for (int i = 1; i <= numberUsers; i++)
            {
                User user = new User();
                user.ID = int.Parse(usersData[currentLine]);
                currentLine++;
                user.Name = usersData[currentLine];
                currentLine++;
                user.Age = int.Parse(usersData[currentLine]);
                currentLine++;
                user.Location = usersData[currentLine];
                currentLine++;
                user.Role = usersData[currentLine];
                currentLine++;
                user.PhoneNumber = usersData[currentLine];
                currentLine++;
                user.UserName = usersData[currentLine];
                currentLine++;
                user.Password = usersData[currentLine];
                currentLine++;
                Users.Add(user);
            }
        }
        private void WriteListUsers()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\users.txt";
            string content = "";
            content += Users.Count.ToString();
            foreach(var user in Users)
            {
                content += System.Environment.NewLine
                         + user.ID.ToString()
                         + System.Environment.NewLine
                         + user.Name
                         + System.Environment.NewLine
                         + user.Age.ToString()
                         + System.Environment.NewLine
                         + user.Location
                         + System.Environment.NewLine
                         + user.PhoneNumber
                         + System.Environment.NewLine
                         + user.Role
                         + System.Environment.NewLine
                         + user.UserName
                         + System.Environment.NewLine
                         + user.Password;
            }
            File.WriteAllText(path, content);
        }
        private void WriteListBooks()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\books.txt";
            string content = "";
            content += Books.Count.ToString();
            foreach (var book in Books)
            {
                content += System.Environment.NewLine
                         + book.ID.ToString()
                         + System.Environment.NewLine
                         + book.Name
                         + System.Environment.NewLine
                         + book.Genre
                         + System.Environment.NewLine
                         + book.Author
                         + System.Environment.NewLine
                         + book.PublicationDate
                         + System.Environment.NewLine
                         + book.NumberUserRead.ToString()
                         + System.Environment.NewLine
                         + book.CountStar.ToString()
                         + System.Environment.NewLine
                         + book.IsBorrowed.ToString()
                         + System.Environment.NewLine
                         + book.Room.ToString()
                         + System.Environment.NewLine
                         + book.Bookshelf.ToString();
            }
            File.WriteAllText(path, content);
        }
        private void WriteListLogs()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\logs.txt";
            string content = "";
            for (int i = 0; i < Logs.Count; i++)
            {
                if (i != Logs.Count - 1)
                {
                    content += Logs[i] + System.Environment.NewLine;
                }
                else content += Logs[i];
            }
            File.WriteAllText(path, content);
        }
        public void WriteData()
        {
            WriteListUsers();
            WriteListBooks();
            WriteListLogs();
        }
        private void ReadListBooks()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\books.txt";
            string[] booksData = File.ReadAllLines(path);
            int numberBooks = int.Parse(booksData[0]);
            int currentLine = 1;
            for (int i = 1;i <= numberBooks; i++)
            {
                Book book = new Book();
                book.ID = int.Parse(booksData[currentLine]);
                currentLine++;
                book.Name = booksData[currentLine];
                currentLine++;
                book.Genre = booksData[currentLine];
                currentLine++;
                book.Author = booksData[currentLine];
                currentLine++;
                book.PublicationDate = booksData[currentLine];
                currentLine++;
                book.NumberUserRead = int.Parse(booksData[currentLine]);
                currentLine++;
                book.CountStar = double.Parse(booksData[currentLine]);
                currentLine++;
                book.IsBorrowed = bool.Parse(booksData[currentLine]);
                currentLine++;
                book.Room =int.Parse(booksData[currentLine]);
                currentLine++;
                book.Bookshelf = int.Parse(booksData[currentLine]);
                currentLine++;
                Books.Add(book);
            }
        }
        private void ReadListLogs()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm2\data\logs.txt";
            string[] logsData = File.ReadAllLines(path);
            for(int i = 0;i < logsData.Length; i++)
            {
                Logs.Add(logsData[i]);
            }
        }
        public ManageLibrary()
        {
            Users = new List<User>();
            Books = new List<Book>();
            Logs = new List<string>();
            ReadListUsers(); 
            ReadListBooks();
            ReadListLogs();
        }

        private bool CheckUserName(string userName)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == userName) return true;
            }
            return false;
        }
        public void CreateAccount()
        {
            User user = new User();
            Console.WriteLine("Registration");
            Console.Write("Please enter your name: ");
            user.Name = Console.ReadLine();
            while (true)
            {
                Console.Write("Age: ");
                user.Age = int.Parse(Console.ReadLine());
                if (user.Age < 0 || user.Age > 120)
                {
                    Console.WriteLine("Wring age. Enter again!");
                }
                else break;
            }
            Console.Write("Location: ");
            user.Location = Console.ReadLine();
            Console.Write("Please enter your phone number: ");
            user.PhoneNumber = Console.ReadLine();

            while (true)
            {
                Console.Write("User name: ");
                user.UserName = Console.ReadLine();
                if (CheckUserName(user.UserName))
                {
                    Console.WriteLine("This user name has already existed. Enter again!");
                }
                else break;
            }
            while (true)
            {
                string password;
                string rePassword;

                Console.Write("Password: ");
                password = Console.ReadLine();
                Console.Write("Please re enter your password: ");
                rePassword = Console.ReadLine();
                if (password == rePassword)
                {
                    user.Password = password;
                    break;
                }

                Console.WriteLine("Passwords do not match. Please enter again!!");
            }
            user.Role = "user";
            user.ID = Users.Count + 1;
            DateTime dt = DateTime.Now;
            string log = dt + $":  {user.ID} created an account";
            Logs.Add(log);
            Users.Add(user);
        }
        private int CheckLogIn(string userName, string password)
        {
            const int WRONG_ACCOUNT = -2;
            const int WRONG_PASSWORD = -1;
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == userName)
                {
                    if (Users[i].Password == password)
                    {
                        return i;
                    }
                    return WRONG_PASSWORD;
                }
            }
            return WRONG_ACCOUNT;
        }
        public int Login()
        {
            string userName;
            string password;
            Console.WriteLine("-------Login---------");
            Console.WriteLine();
            Console.Write("User name: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            int check = CheckLogIn(userName, password);
            if (check == -2)
            {
                Console.WriteLine("Wrong account");
            }
            else if (check == -1)
            {
                Console.WriteLine("Wrong password");
            }else
            {
                DateTime dt = DateTime.Now;
                string log = dt + $":  {Users[check].ID} logged an account";
                Logs.Add(log);
            }
            
            return check;
        }

        public void MenuAdmin()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Hi! Admin"                    );
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Your menu:");
            Console.WriteLine("Option 1: Show your infomation");
            Console.WriteLine("Option 2: Show list book");
            Console.WriteLine("Option 3: Show list log");
            Console.WriteLine("Option 4: Add a book");
            Console.WriteLine("Option 5: Remove a book");
            Console.WriteLine("Option 6: Update a book");
            Console.WriteLine("Option 7: Remove a user");
            Console.WriteLine("Option 8: Switch to user mode");
            Console.WriteLine("Option 9: Exit");
        }
        public void MenuUser(int indexUser)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Hi! {0}", Users[indexUser].Name);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Your menu:");
            Console.WriteLine("Option 1: Show your infomation");
            Console.WriteLine("Option 2: Change Name");
            Console.WriteLine("Option 3: Change Password");
            Console.WriteLine("Option 4: Show all books");
            Console.WriteLine("Option 5: Find book by name");
            Console.WriteLine("Option 6: Find book by author");
            Console.WriteLine("Option 7: Find book by genre");
            Console.WriteLine("Option 8: Find book most read books");
            Console.WriteLine("Option 9: Borrow a book");
            Console.WriteLine("Option 10: Return a book");
            Console.WriteLine("Option 11: Remove your account");
            Console.WriteLine("Option 12: Donate books to the library");
            Console.WriteLine("Option 13: Exit");
        }
        public void MenuGuest()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Hi! Have a good day!");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Your menu:");
            Console.WriteLine("Option 1: Show all books");
            Console.WriteLine("Option 2: Find book by name");
            Console.WriteLine("Option 3: Find book by author");
            Console.WriteLine("Option 4: Find book by genre");
            Console.WriteLine("Option 5: Find book most read books");
            Console.WriteLine("Option 6: Borrow a book");
            Console.WriteLine("Option 7: Exit");
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List of books of Sunny library");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < Books.Count; i++)
            {
                Books[i].ShowInfo();
            }
        }
        public void ShowLogs()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List of log");
            Console.WriteLine("------------------------------------------------");
            foreach (var log in Logs)
            {
                Console.WriteLine(log);
            }
        }
        public void ShowMostReadBooks()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                for (int j = i + 1; j < Books.Count; j++)
                {
                    double starI;
                    double starJ;
                    starI = (Books[i].NumberUserRead != 0) ? (Books[i].CountStar / Books[i].NumberUserRead) : (0);
                    starJ = (Books[j].NumberUserRead != 0) ? (Books[j].CountStar / Books[j].NumberUserRead) : (0);
                    if (starI < starJ)
                    {
                        Book book = Books[i];
                        Books[i] = Books[j];
                        Books[j] = book;
                    }
                }
            }
            ShowAllBooks();
            for (int i = 0; i < Books.Count; i++)
            {
                for (int j = i + 1; j < Books.Count; j++)
                {
                    if (Books[i].ID > Books[j].ID)
                    {
                        Book book = Books[i];
                        Books[i] = Books[j];
                        Books[j] = book;
                    }
                }
            }
        }
        public void AddABook(int IdUser)
        {
            Book book = new Book();
            Console.WriteLine("Please enter the information of the book");
            Console.Write("Name: ");
            book.Name = Console.ReadLine();
            Console.Write("Genre: ");
            book.Genre = Console.ReadLine();
            Console.Write("Author: ");
            book.Author = Console.ReadLine();
            Console.Write("PublicationDate: ");
            book.PublicationDate = Console.ReadLine();
            book.IsBorrowed = false;
            book.Room = 3;
            book.Bookshelf = Books[Books.Count - 1].Bookshelf + 1;
            book.CountStar = 0;
            book.NumberUserRead = 0;
            book.ID = Books.Count + 1;
            DateTime dt = DateTime.Now;
            string log = dt + $":  {IdUser} added a book bearing {book.ID}";
            Logs.Add(log);
            Books.Add(book);
            Console.WriteLine("Finished adding a book");
        }
        public void RemoveABook(int IdUser)
        {
            Console.WriteLine("Please enter the id of the book");
            int IDBook = int.Parse(Console.ReadLine());
            if (IDBook < 1 || IDBook > Books.Count)
            {
                Console.WriteLine("Wrong ID");
                return;
            }
            int indexBook = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ID == IDBook)
                {
                    indexBook = i;
                    break;
                }
            }
            DateTime dt = DateTime.Now;
            string log = dt + $":  {IdUser} remove a book bearing {IDBook}";
            Logs.Add(log);
            Books.RemoveAt(indexBook);
            Console.WriteLine("Finished removing a book");
        }
        public void UpdateABook(int IdUser)
        {
            Console.WriteLine("Please enter the id of the book");
            int IDBook = int.Parse(Console.ReadLine());
            if (IDBook < 1 || IDBook > Books.Count)
            {
                Console.WriteLine("Wrong ID");
                return;
            }
            int indexBook = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ID == IDBook)
                {
                    indexBook = i;
                    break;
                }
            }
            Console.WriteLine("Please enter the information of the book");
            Console.Write("Name: ");
            Books[indexBook].Name = Console.ReadLine();
            Console.Write("Genre: ");
            Books[indexBook].Genre = Console.ReadLine();
            Console.Write("Author: ");
            Books[indexBook].Author = Console.ReadLine();
            Console.Write("PublicationDate: ");
            Books[indexBook].PublicationDate = Console.ReadLine();
            DateTime dt = DateTime.Now;
            string log = dt + $":  {IdUser} update a book bearing {IDBook}";
            Logs.Add(log);
            Console.WriteLine("Finished updating a book");
        }
        public void RemoveAUser(int IdUser)
        {
            Console.WriteLine("Please enter the id of the user");
            int IDUser = int.Parse(Console.ReadLine());
            if (IDUser < 1 || IDUser > Users.Count)
            {
                Console.WriteLine("Wrong ID");
                return;
            }
            int indexUser = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ID == indexUser)
                {
                    indexUser = i;
                    break;
                }
            }
            DateTime dt = DateTime.Now;
            string log = dt + $":  {IdUser} remove a book bearing {IDUser}";
            Logs.Add(log);
            Users.RemoveAt(indexUser);
            Console.WriteLine("Finished removing a book");
        }
        public void FindBookByName()
        {
            Console.WriteLine("Please enter the name of the book");
            string name = Console.ReadLine();

            bool found = true;
            foreach (Book book in Books)
            {
                if (book.Name == name)
                {
                    book.ShowInfo();
                    found = false;
                }
            }
            if (found)
            {
                Console.WriteLine("There are no book that as such");
            }
        }
        public void FindBookByAuthor()
        {
            Console.WriteLine("Please enter the name of the book");
            string author = Console.ReadLine();

            bool found = true;
            foreach (Book book in Books)
            {
                if (book.Author == author)
                {
                    book.ShowInfo();
                    found = false;
                }
            }
            if (found)
            {
                Console.WriteLine("There are no book that as such");
            }
        }
        public void FindBookByGenre()
        {
            Console.WriteLine("Please enter the name of the book");
            string genre = Console.ReadLine();

            bool found = true;
            foreach (Book book in Books)
            {
                if (book.Genre == genre)
                {
                    book.ShowInfo();
                    found = false;
                }
            }
            if (found)
            {
                Console.WriteLine("There are no book that as such");
            }
        }
        public void BorrowABook(int indexUser)
        {
            Console.WriteLine("Please enter the id of the book");
            int IDBook = int.Parse(Console.ReadLine());
            if (IDBook < 1 || IDBook > Books.Count)
            {
                Console.WriteLine("Wrong ID");
                return;
            }
            int indexBook = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ID == IDBook)
                {
                    indexBook = i;
                    break;
                }
            }
            if (Books[indexBook].IsBorrowed)
            {
                Console.WriteLine("This book was borrowed by another person");
                return;
            }
            Books[indexBook].IsBorrowed = true;
            Books[indexBook].UserID = Users[indexUser].ID;
            DateTime dt = DateTime.Now;
            string log = dt + $":  {Users[indexUser].ID} was borrowed a book bearing {IDBook}";
            Logs.Add(log);
            Console.WriteLine("You have successfully borrowed the book");
            Books[indexBook].TakeLocation();
        }
        public void ReturnABook(int indexUser)
        {
            Console.WriteLine("Please enter the id of the book");
            int IDBook = int.Parse(Console.ReadLine());
            int indexBook = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ID == IDBook)
                {
                    indexBook = i;
                    break;
                }
            }
            DateTime dt = DateTime.Now;
            string log = dt + $":  {Users[indexUser].ID} was returned a book bearing {IDBook}";
            Logs.Add(log);
            Books[indexBook].IsBorrowed = false;
            Books[indexBook].NumberUserRead++;
            Console.WriteLine("Hope you can take a moment to rate the book");
            while (true)
            {
                double star = double.Parse(Console.ReadLine());
                if (star < 1 || star > 5)
                {
                    Console.WriteLine("Wrong start. Please enter again");
                }else
                {
                    Books[indexBook].CountStar += star;
                    break;
                }
            }
            Console.WriteLine("You have successfully returned the book");
        }
        public void RemoveAccount(int indexUser)
        {
            Console.WriteLine("Are you sure you want to delete your account?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());
            if (option == 2) return;
            DateTime dt = DateTime.Now;
            string log = dt + $":  {Users[indexUser]} was removed  account";
            Logs.Add(log);
            Users.RemoveAt(indexUser);
        }
    }
}
