using E_Commerce.Entities;
using System;

namespace E_Commerce
{
    class Program
    {
        static void Main(string[] args)
        {
           
                Console.WriteLine("--WelCome to EasyCart--\n");
                Console.WriteLine("Hello, Please Select any Option");
                Console.WriteLine("a. Login as a User");
                Console.WriteLine("b. Login as a Manager");
                Console.WriteLine("c. Exit App!");

                char ch = Convert.ToChar(Console.ReadLine());

            switch (ch)
            {
                case 'a':
                    Console.WriteLine("Enter User Id");
                    int userId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Password");
                    var userPass = Console.ReadLine();
                    CustomerOperation.CustomerLogin(userId, userPass);
                    break;
                case 'b':
                    Console.WriteLine("Enter Manager Id");
                    int managerId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Password");
                    var managerPass = Console.ReadLine();
                    CustomerOperation.CustomerLogin(managerId, managerPass);
                    break;
                case 'c':
                    Console.WriteLine("Exit");

                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
               
            }
            

        
    }
}
