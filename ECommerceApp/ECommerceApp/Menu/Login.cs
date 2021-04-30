using ECommerceApp.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu
{
    public class Login
    {
        public void LoginMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter User Name");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string userPass = Console.ReadLine();
                string res = AuthManager.AcceptLoginCreds(userName, userPass);


                if (res == "Customer")
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.DrawMenu();
                }

                else if (res == "Manager")
                {
                    InventoryManagementMenu inventoryManagementMenu = new InventoryManagementMenu();
                    inventoryManagementMenu.ManagerMenu();
                }
                else
                {
                    Console.WriteLine("Username or Password Incorrect");
                    Console.WriteLine("Do you want to Exit write yes or no");
                    string input = Console.ReadLine();
                    if(input=="yes")
                    {
                        exit = true;
                    }
                    
                   
                }
                
            }
            

        }
    }
}
