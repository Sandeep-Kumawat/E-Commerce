using ECommerceApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Menu
{
    internal class InventoryManagementMenu
    {
        SubMenu subMenu = new SubMenu();
        public void ManagerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                subMenu.AllProducts();
                Console.WriteLine("a. Add New Product");
                Console.WriteLine("b. Delete a Product");
                Console.WriteLine("c. Search a Product");
                Console.WriteLine("d. Update a Product");
                Console.WriteLine("e. Exit App!");

                char ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                        subMenu.AddProduct();

                        break;
                    case 'b':

                        subMenu.DeleteAProduct();
                        break;
                    case 'c':

                        subMenu.SearchAProduct();
                        break;
                    case 'd':
                        subMenu.UpdateAProduct();

                        break;
                    case 'e':
                        exit = true;
                        Console.WriteLine("Exit");

                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
                Console.WriteLine("Press Any to Clear");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
     internal class SubMenu {
        RepoDb repoDb; 
        public SubMenu()
        {
            repoDb = new RepoDb();
        }
        internal bool AddProduct()
            {
                Console.WriteLine("Enter Id");
                int id = -1;
                bool flag = Int32.TryParse(Console.ReadLine(), out id);
                while (!flag || id <= 0)
                {

                    Console.WriteLine("Please Enter Only Number and It can not be Empty/can not be negetive");
                    flag = Int32.TryParse(Console.ReadLine(), out id);

                }
                Console.WriteLine("Enter Product Name");
                var ProductName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(ProductName) || int.TryParse(ProductName, out _))
                {
                    Console.WriteLine("Please Enter Only Char and It can not be Empty");
                    ProductName = Console.ReadLine();

                }
                Console.WriteLine("Enter Price");
                int price = -1;
                bool flag1 = Int32.TryParse(Console.ReadLine(), out price);
                while (!flag1 || price <= 0)
                {

                    Console.WriteLine("Please Enter Only Number and It can not be Empty/can not be negetive");
                    flag1 = Int32.TryParse(Console.ReadLine(), out price);

                }
                Console.WriteLine("Enter Manufacture Name");
                var manufactureName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(manufactureName) || int.TryParse(manufactureName, out _))
                {
                    Console.WriteLine("Please Enter Only Char and It can not be Empty");
                    manufactureName = Console.ReadLine();

                }
                Console.WriteLine("Enter Product Code");
                string productCode = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(productCode) || int.TryParse(productCode, out _))
                {
                    Console.WriteLine("Please Enter Only Char and It can not be Empty");
                    productCode = Console.ReadLine();

                }
                Console.WriteLine("Enter Manufacture Date");
                DateTime manuDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Expiry Date");
                DateTime expDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            int quantity = -1;
            bool flag2 = Int32.TryParse(Console.ReadLine(), out quantity);
            while (!flag2 || quantity <= 0)
            {

                Console.WriteLine("Please Enter Only Number and It can not be Empty/can not be negetive");
                flag2 = Int32.TryParse(Console.ReadLine(), out quantity);

            }

            BasicProduct basicProduct = new BasicProduct(id, ProductName, manufactureName, productCode, manuDate, expDate, price);
                repoDb.Add<BasicProduct>(basicProduct);
            repoDb.Add<Inventory>(new Inventory(id,productCode,quantity));
               

                return true;
         }
        internal bool DeleteAProduct()
        {
            Console.WriteLine("Enter Product Code To Delete");
            string proCode = Console.ReadLine();
            bool x=repoDb.Remove<BasicProduct>(proCode);
            if(x==true)
            {
                Console.WriteLine("Product Added");
                return true;
            }
            Console.WriteLine("Product Not Found");
            return false;
        }
        internal bool SearchAProduct()
        {
            Console.WriteLine("Enter Product Code To Search");
            string proCode = Console.ReadLine();
            var data = repoDb.Search<BasicProduct>(proCode);
            if(data==null)
            {
                Console.WriteLine("Product Not Found");
                return false;
            }
            Console.WriteLine($"Product Id{data.Id}\nProduct Name{data.ProductName}\n" +
                    $"Product Manufacturer{data.Manufacturer}\nProduct Code{data.ProductCode}\n" +
                    $"Product ManufacturingDate{data.ManufacturingDate}\nProduct Expiry Date{data.ExpiryDate}\n" +
                    $"Product Amount :{data.Amount}");
            return true;
        }
        internal bool UpdateAProduct()
        {
            Console.WriteLine("Enter Product Code To Search");
            string proCode = Console.ReadLine();

            var data = repoDb.Search<Inventory>(proCode);
            if (data == null)
            {
                Console.WriteLine("Product Not Found");
                return false;
            }
            Console.WriteLine("Enter New Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            data.Quantity = quantity;
            return true;
        }
        public void AllProducts()
        {
            var products = repoDb.ListAll<BasicProduct>();
            var invantory = repoDb.ListAll<Inventory>();
            if (products == null || products.Count == 0) {
                Console.WriteLine("No Product Available");
                return;
            }
            products.ForEach((p) =>
            {
                var data = invantory.Single((i) => i.ProductCode == p.ProductCode);
                Console.WriteLine($"Product Id{p.Id}\nProduct Name{p.ProductName}\n" +
                    $"Product Manufacturer{p.Manufacturer}\nProduct Code{p.ProductCode}\n" +
                    $"Product ManufacturingDate{p.ManufacturingDate}\nProduct Expiry Date{p.ExpiryDate}\n" +
                    $"Product Amount :{p.Amount}\nProduct Quantity :{data.Quantity}");
               
            });

      

        }
    }
 }

    

