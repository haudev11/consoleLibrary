using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLibrary
{
    class Program
    {
        public static void MenuAdmin(ManageLibrary manageLibrary, int indexUser)
        {
            manageLibrary.MenuAdmin();
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1) manageLibrary.Users[indexUser].ShowInfo();
            else if (option == 2) manageLibrary.ShowAllBooks();
            else if (option == 3) manageLibrary.ShowLogs();
            else if (option == 4) manageLibrary.AddABook(manageLibrary.Users[indexUser].ID);
            else if (option == 5) manageLibrary.RemoveABook(manageLibrary.Users[indexUser].ID);
            else if (option == 6) manageLibrary.UpdateABook(manageLibrary.Users[indexUser].ID);
            else if (option == 7) manageLibrary.RemoveAUser(manageLibrary.Users[indexUser].ID);
            else if (option == 8) MenuUser(manageLibrary, indexUser);
            else return;
            MenuAdmin(manageLibrary, indexUser);
        }
        public static void MenuUser(ManageLibrary manageLibrary, int indexUser)
        {
            manageLibrary.MenuUser(indexUser);
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1) manageLibrary.Users[indexUser].ShowInfo();
            else if (option == 2) manageLibrary.Users[indexUser].ChangeName();
            else if (option == 3) manageLibrary.Users[indexUser].ChangePassword();
            else if (option == 4) manageLibrary.ShowAllBooks();
            else if (option == 5) manageLibrary.FindBookByName();
            else if (option == 6) manageLibrary.FindBookByAuthor();
            else if (option == 7) manageLibrary.FindBookByGenre();
            else if (option == 8) manageLibrary.ShowMostReadBooks();
            else if (option == 9) manageLibrary.BorrowABook(indexUser);
            else if (option == 10) manageLibrary.ReturnABook(indexUser);
            else if (option == 11) manageLibrary.RemoveAccount(indexUser);
            else if (option == 12) manageLibrary.AddABook(manageLibrary.Users[indexUser].ID);
            else return;
            MenuUser(manageLibrary, indexUser);
        }
        public static void MenuGuest(ManageLibrary manageLibrary)
        {
            manageLibrary.MenuGuest();
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1) manageLibrary.ShowAllBooks();
            else if (option == 2) manageLibrary.FindBookByName();
            else if (option == 3) manageLibrary.FindBookByAuthor();
            else if (option == 4) manageLibrary.FindBookByGenre();
            else if (option == 5) manageLibrary.ShowMostReadBooks();
            else if (option == 6)
            {
                Console.WriteLine("You should create an account before borrowing books");
                Menu(manageLibrary);
            }
            else return;
            MenuGuest(manageLibrary);
        }

        public static void Menu(ManageLibrary manageLibrary)
        {
            Console.WriteLine();
            Console.WriteLine("Your options:");
            Console.WriteLine("Option 1: Login");
            Console.WriteLine("Option 2: Create a account");
            Console.WriteLine("Option 3: Login as guest");
            Console.WriteLine("Option 4: Exit");
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());
            int indexUser = 0;
            if (option == 1)
            {
                indexUser = manageLibrary.Login();
                if (indexUser >= 0)
                {
                    if (manageLibrary.Users[indexUser].Role == "admin") MenuAdmin(manageLibrary, indexUser);
                    if (manageLibrary.Users[indexUser].Role == "user") MenuUser(manageLibrary, indexUser);
                    return;
                }
            }
            else if (option == 2)
            {
                manageLibrary.CreateAccount();
            }
            else if (option == 3)
            {
                MenuGuest(manageLibrary);
                return;
            }
            else return;
            Menu(manageLibrary);
        }
        public static void Main()
        {
            ManageLibrary manageLibrary = new ManageLibrary();
            Console.WriteLine("------------  Welcome to Sunny Library  ------------  ");
            Menu(manageLibrary);
            manageLibrary.WriteData();
        }
    }
}
