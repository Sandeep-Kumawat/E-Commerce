using ECommerceApp.Auth;
using ECommerceApp.Managers;
using ECommerceApp.Menu;
using System;

namespace ECommerceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Welcome To EasyCart--");
            Console.WriteLine(" Login");
            Login login = new Login();
            login.LoginMenu();


        }
    }
}


