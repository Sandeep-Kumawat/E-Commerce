using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Database
{
    public class RepoDb
    {

        public static List<User> users = new List<User>()

        {
             new User
             (
                 "Sandeep",
                 "asdf",
                 "Customer"
             ),
              new User
              (
                 "Surojeet",
                 "asdf",
                 "Manager"
              )
            
        };
        public static List<BasicProduct> products = new List<BasicProduct>();
        public static List<Inventory> inventories = new List<Inventory>();
        
        public static List<Inventory> orders = new List<Inventory>();



        private Dictionary<string, object> tblLookUp = new Dictionary<string, object>();

        public RepoDb()
        {
            tblLookUp.Add(typeof(User).Name, users);
            tblLookUp.Add(typeof(BasicProduct).Name, products);
            tblLookUp.Add(typeof(Inventory).Name,inventories );
            //tblLookUp.Add(typeof(Inventory).Name, orders);
        }
       
        public void AddCart(Inventory inventory)
        {
           
                orders.Add(inventory);
                
          
        }
        public void ShowCart()
        {
            int totalPrice = 0;
            orders.ForEach((i) =>
            {
                var data = products.Single((p) => p.ProductCode == i.ProductCode);
                Console.WriteLine($"Product Id{data.Id}\nProduct Name{data.ProductName}\n" +
                    $"Product Manufacturer{data.Manufacturer}\nProduct Code{data.ProductCode}\n" +
                    $"Product ManufacturingDate{data.ManufacturingDate}\nProduct Expiry Date{data.ExpiryDate}\n" +
                    $"Product Amount :{data.Amount}\nProduct Quantity :{i.Quantity}");
                totalPrice += data.Amount * i.Quantity;
                inventories.Single((x) => x.ProductCode == i.ProductCode).Quantity -= i.Quantity;
            });

            Console.WriteLine("Total Price " + totalPrice);
          
        }
        public bool Add<T>(T record)
        {
            if (!tblLookUp.ContainsKey(typeof(T).Name))
            {
                return false;
            }
            var list = (List<T>)tblLookUp[typeof(T).Name];
            list.Add(record);
            return true;


            //if (record.GetType() == typeof(User)) {
            //    users.Add(record as User);
            //    return true;
            //}
            //else if(record.GetType()==typeof(BasicProduct))
            //{
            //    products.Add(record as BasicProduct);
            //    return true;
            //}
            //return false;

        }

        public bool Remove<T>(string name) where T : BaseRecordType
        {
            if (!tblLookUp.ContainsKey(typeof(T).Name))
            {
                return false;
            }
            var list = (List<T>)tblLookUp[typeof(T).Name];
            try
            {
                var data = list.Single((i) => i.Name == name);
                list.Remove(data);
                return true;
            }
           catch
            {

                return false;
            }
           

            //if(typeof(T) == typeof(User)) { 

            //    var data = users.Single((i) => i.LoginName == name);
            //    if(data==null)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        users.Remove(data);
            //        return true;
            //    }
            //}
            //else if(typeof(T) == typeof(BasicProduct))
            //{
            //    var data = products.Single((i) => i.Name == name);
            //    if (data == null)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        products.Remove(data);
            //        return true;
            //    }
            //}
            //return false;
        }

        public T Search<T>(string name) where T:BaseRecordType
        {
            if (!tblLookUp.ContainsKey(typeof(T).Name))
            {
                return null;
            }
            var list = (List<T>)tblLookUp[typeof(T).Name];
            try
            {
                var data = list.Single((i) => i.Name == name);
                return data;
            }
            catch
            {
                return null;
            }
           

            //if (typeof(T) == typeof(BasicProduct))
            //{
            //    var data = products.Single((i) => i.ProductName == name);
            //    return (T)Convert.ChangeType(data, typeof(T));
            //}
            //else if(typeof(T) == typeof(User))
            //{
            //    var data = users.Single((i) => i.LoginName == name);
            //    return (T)Convert.ChangeType(data, typeof(T));
            //}
            //return null;

        }
        public List<T> ListAll<T>() where T : BaseRecordType
        {
            if (!tblLookUp.ContainsKey(typeof(T).Name))
            {
                return null;
            }
            return (List<T>)tblLookUp[typeof(T).Name];


            //if (typeof(T) == typeof(BasicProduct))
            //{
            //    return (List<T>)Convert.ChangeType(products, typeof(List<T>));
            //}
            //else if (typeof(T) == typeof(User))
            //{
            //   return (List<T>)Convert.ChangeType(users, typeof(List<T>));
            //}
            //return null;

        }

       
    }
}
