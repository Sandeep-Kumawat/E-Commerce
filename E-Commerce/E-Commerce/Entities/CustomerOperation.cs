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
                Console.WriteLine("c. Exit!");

                char ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                    Console.WriteLine("Enter Id to be Add");
                    int id = Convert.ToInt32(Console.ReadLine());
                    
                    AddProductToCart(id,0);
                    break;
                    case 'b':
                    SearchProduct();
                        break;
                    case 'c':

                    Console.WriteLine("Exit");
                    break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
               
        }
        public static void AddProductToCart(int id,int totalPrice)
        {
            
            ProductManagement.productDetails.ForEach((i) =>
            {
                if (i.ProductID == id)
                {
                    Console.WriteLine("Enter Quantity");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    
                    if (i.Quantity >= quantity)
                    {
                        
                        i.Quantity = i.Quantity - quantity;
                        Customer.OrderDetail.Add(new ProductDetails
                        {
                            ProductID = i.ProductID,
                            ProductName = i.ProductName,
                            Price = i.Price,
                            Quantity = quantity,
                            Manufacturer = i.Manufacturer
                        });
                        totalPrice += (i.Price * quantity);
                        Console.WriteLine("Product added into Cart Successfully");
                        Console.WriteLine("You want to Add more Products then write yes else no");
                        var input = Console.ReadLine();
                        if(input=="yes")
                        {
                            Console.WriteLine("Enter Id to be Add");
                            int id = Convert.ToInt32(Console.ReadLine());
                            AddProductToCart(id,totalPrice);
                        }
                        else if(input=="no")
                        {
                            Customer.ShowCart();
                            Console.WriteLine("Total Price For Order :" + totalPrice);
                            CustomerMenu();
                        }


                    }
                    else
                    {
                        Console.WriteLine("Product is Out of Stocks");
                    }
                }
                              
            });
            Console.WriteLine("Do you want to login as a Manager write yes or no");
            var input1 = Console.ReadLine();
            if (input1 == "yes")
            {
                Console.WriteLine("Enter Manager Id");
                int managerId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Password");
                var managerPass = Console.ReadLine();
                ManagerOperation.ManagerLogin(managerId,managerPass);

            }
        }
            public static void SearchProduct()
        {
            ProductManagement.SearchProduct();
        }
    }
}
