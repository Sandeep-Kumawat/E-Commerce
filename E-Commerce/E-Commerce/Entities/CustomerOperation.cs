using System;
using System.Collections.Generic;
using System.Text;


namespace E_Commerce.Entities
{
    public static class CustomerOperation
    {
       public static List<Customer> customers = new List<Customer>()
        {
            new Customer
            {
                CustomerID=1,
                CustomerName="Sandeep",
                Password ="asdf"

            }
        };

        public static void CustomerLogin(int id,string pass)
        {
            customers.ForEach((i) =>
            {
                if (i.CustomerID == id && i.Password == pass)
                {
                    CustomerMenu();
                }
                else
                {
                    Console.WriteLine("Id or Password Incorrect");
                }
            });
        }

        public static void CustomerMenu()
        {
           
                Console.WriteLine("Here are all Products\n");
                ProductManagement.ListOfAllProducts();
                Console.WriteLine("Please Select Option");
                Console.WriteLine("a. Add Product in Cart");
                Console.WriteLine("b. Search Products");
                Console.WriteLine("c. Exit App!");

                char ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                    Console.WriteLine("Enter Id to be Add");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ProductManagement.productDetails.ForEach((i) =>
                    {
                        if (i.ProductID == id)
                        {
                            Console.WriteLine("Enter Quantity");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            //if(i.Quantity>=quantity)
                            //{
                            i.Quantity = i.Quantity - quantity;
                            Customer.OrderDetail.Add(new ProductDetails
                            {
                                ProductID = i.ProductID,
                                ProductName =i.ProductName,
                                Price = i.Price,
                                Quantity = quantity,
                                Manufacturer = i.Manufacturer
                            });
                                Customer.ShowCart();
                            //}
                        }
                        else
                        {
                            Console.WriteLine("Product not Found");
                        }
                    });
                   
                        break;
                    case 'b':
                        
                        break;
                    case 'c':
                       
                        
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
               
        }
        //public static void AddProductInCart(ProductDetails i,int quantity)
        //{
        //    Customer.OrderDetail.Add(i);
        //}
        public static void SearchProduct()
        {
            ProductManagement.SearchProduct();
        }
    }
}
