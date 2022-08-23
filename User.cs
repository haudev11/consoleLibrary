using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLibrary
{
    internal class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User()
        {

        }

        public void ShowInfo()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age : {0}", Age);
            Console.WriteLine("Location : {0}", Location);
            Console.WriteLine("User name: {0}", UserName);
            Console.Write("Phone number: ");
            for (int i = 0; i < PhoneNumber.Length; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == PhoneNumber.Length - 1 || i == PhoneNumber.Length - 2)
                {
                    Console.Write(PhoneNumber[i]);
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine("Money");
            Console.WriteLine("-----------------------------------------------------");
        }
        public void ChangeName()
        {
            Console.WriteLine("Please enter new name");
            string newName = Console.ReadLine();
            Name = newName;
            Console.WriteLine("Name change successful");
        }
        public void ChangePassword()
        {
            string newPassword;
            string reNewPassword;
            Console.Write("Please enter new password: ");
            newPassword = Console.ReadLine();
            Console.Write("Re-enter:");
            reNewPassword = Console.ReadLine();
            if (newPassword != reNewPassword)
            {
                Console.WriteLine("No password match");
                ChangePassword();
            }
            Password = newPassword;
            Console.WriteLine("Change password successfully");
        }
    }
}
