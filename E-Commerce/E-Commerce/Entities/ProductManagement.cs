using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.Entities
{
    public static class ProductManagement
    {
        public static List<ProductDetails> productDetails = new List<ProductDetails>()
        {
            new ProductDetails
            {
                ProductID=1,
                ProductName="Pen",
                Price=20,
                Quantity=10,
                Manufacturer="Linc"
            },
             new ProductDetails
            {
                ProductID=2,
                ProductName="Book",
                Price=200,
                Quantity=20,
                Manufacturer="Classmate"
            },
              new ProductDetails
            {
                ProductID=3,
                ProductName="Laptop",
                Price=20000,
                Quantity=5,
                Manufacturer="Dell"
            },
               new ProductDetails
            {
                ProductID=4,
                ProductName="Mobile",
                Price=15000,
                Quantity=10,
                Manufacturer="Redmi"
            }

        };
        public static void AddProduct(int id,string name,int price,int quantity,string manufacturer)
        {
            productDetails.Add(new ProductDetails
            {
                ProductID = id,
                ProductName = name,
                Price = price,
                Quantity = quantity,
                Manufacturer = manufacturer

            });
        }

        public static void ListOfAllProducts()
        {
           
            productDetails.ForEach((i) =>
            {
                Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
            });
            
        }
        public static void DeleteProduct()
        {
            ListOfAllProducts();
            Console.WriteLine("a. Delete By ID");
            Console.WriteLine("b. Delete By Name");
            char ch2 = Convert.ToChar(Console.ReadLine());
            switch (ch2)
            {
                case 'a':
                    Console.WriteLine("Enter Id Number to delete");
                    int a = Convert.ToInt32(Console.ReadLine());
                    DeleteById(a);
                    break;
                case 'b':
                    Console.WriteLine("Enter Product Name to Delete");
                    var sc = Console.ReadLine();
                    DeleteByName(sc);
                    break;
            }
        }
        public static void DeleteById(int id)
        {

            try
            {
                var data = productDetails.Single((i) => i.ProductID == id);
                productDetails.Remove(data);
                ListOfAllProducts();
            }
            catch
            {
                Console.WriteLine("Id not Found");
            }
        }
        public static void DeleteByName(string name)
        {
            try
            {
                var data = productDetails.Single((i) => i.ProductName == name);
                productDetails.Remove(data);
                ListOfAllProducts();
            }
            catch
            {
                Console.WriteLine("Name not Found");
            }
        }
        public static void SearchProduct()
        {
            Console.WriteLine("a. Search By ID");
            Console.WriteLine("b. Search By Name");
            Console.WriteLine("c. Search By Price");
            char ch3 = Convert.ToChar(Console.ReadLine());
            switch (ch3)
            {
                case 'a':
                    Console.WriteLine("Enter Id Number to Search");
                    int a = Convert.ToInt32(Console.ReadLine());
                    SearchByID(a);
                    break;
                case 'b':
                    Console.WriteLine("Enter Neme of Product to Search");
                    var name = Console.ReadLine();
                    SearchByName(name);
                    break;
               case 'c':
                    Console.WriteLine("Enter Price of Product to Search");
                    SearchByPrice();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public static void SearchByID(int Id)
        {
            var data = productDetails.FindAll((i) => i.ProductID == Id);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
                
            });
            }
            else
            {
                Console.WriteLine("Id Not Found");
            }
        }
        public static void SearchByName(string name)
        {
            var data = productDetails.FindAll((i) => i.ProductName == name);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
                });
            }
            else
            {
                Console.WriteLine("Name Not Found");
            }
        }
        public static void SearchByPrice()
        {
            Console.WriteLine("a. Search By Equal Price");
            Console.WriteLine("b. Search By Greater Price");
            Console.WriteLine("c. Search By Lesser Price");
            char ch = Convert.ToChar(Console.ReadLine());
            switch (ch)
            {
                case 'a':
                    Console.WriteLine("Enter Price for Equal Search");
                    int price = Convert.ToInt32(Console.ReadLine());
                    EqualPrice(price);
                    break;
                case 'b':
                    Console.WriteLine("Enter Price for Greater Search");
                    int greaterPrice = Convert.ToInt32(Console.ReadLine());
                    GraterPrice(greaterPrice);
                    break;
                case 'c':
                    Console.WriteLine("Enter Price for lesser Search");
                    int lesserPricerice = Convert.ToInt32(Console.ReadLine());
                    LesserPrice(lesserPricerice);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }
        public static void EqualPrice(int price)
        {
            var data = productDetails.FindAll((i) => i.Price == price);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
                });
            }
            else
            {
                Console.WriteLine("Price not Found");
            }

        }
        public static void GraterPrice(int price)
        {
            var data = productDetails.FindAll((i) => i.Price > price);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
                });
            }
            else
            {
                Console.WriteLine("Price not Found");
            }

        }
        public static void LesserPrice(int price)
        {
            var data = productDetails.FindAll((i) => i.Price < price);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($" Product ID :{i.ProductID} \n Product Name :{i.ProductName}\n Product Price :{i.Price}\n Product Quantity :{i.Quantity}\n Product Manufacturer :{i.Manufacturer}");
                });
            }
            else
            {
                Console.WriteLine("Price not Found");
            }

        }
        public static void UpdateProduct(int id)
        {
            var data = productDetails.Find((i) => i.ProductID == id);
            if(data == null)
            {
                Console.WriteLine("Product not Found");
            }
            data.Price = 30;
            ProductManagement.ListOfAllProducts();
        }
    }
}
