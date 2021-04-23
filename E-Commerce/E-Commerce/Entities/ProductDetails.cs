using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Entities
{
    public class ProductDetails
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
    }
}
