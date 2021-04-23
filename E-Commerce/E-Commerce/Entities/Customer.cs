using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public static List<ProductDetails> OrderDetail = new List<ProductDetails>();

        public static void ShowCart()
        {
            OrderDetail.ForEach((i) =>
            {
                Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
            });
        }
    }
}
