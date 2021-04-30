using ECommerceApp.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu
{
   
    internal class CustomerSubMenu
    {
        RepoDb repoDb = new RepoDb();

        internal bool AddProductToCart()
        {
            
            repoDb.ListAll<BasicProduct>();
            //Console.WriteLine("Enter Product Id to be Add in Cart");
            //int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Code");
            string productCode = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Inventory inventory = new Inventory(-1, productCode, quantity);
            repoDb.AddCart(inventory);
           

            return true;
        }
        internal bool SearchProduct()
        {
           
            Console.WriteLine("Enter Product Code to Search");
            string procode = Console.ReadLine();
            repoDb.Search<BasicProduct>(procode);
            return true;
        }
        internal bool ShowCart()
        {
            repoDb.ShowCart();
            return true;
        }
       
    }

    internal class CustomerMenu
    {
       
        internal void DrawMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("a. Add Product in Cart");
                Console.WriteLine("b. Search Products");
                Console.WriteLine("c. Show Cart");
                Console.WriteLine("d. Exit!");

                char ch = Convert.ToChar(Console.ReadLine());
                CustomerSubMenu subMenu = new CustomerSubMenu();

                switch (ch)
                {
                    case 'a':

                        subMenu.AddProductToCart();
                        break;
                    case 'b':
                        subMenu.SearchProduct();
                        break;
                    case 'c':
                        subMenu.ShowCart();
                        break;
                    case 'd':
                        exit = true;
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }
      
    }
}
