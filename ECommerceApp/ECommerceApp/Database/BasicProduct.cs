using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database
{
    public class BasicProduct:BaseRecordType
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public string Manufacturer { get; private set; }
        public string ProductCode { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public int  Amount { get; private set; }

        public BasicProduct(int id,string name,string manufacturer,string procode,DateTime manufacturerDate,DateTime expiryDate,int amount)
        {
            this.Id = id;
            this.ProductName = name;
            this.Manufacturer = manufacturer;
            this.ProductCode = procode;
            this.Name = procode;
            this.ManufacturingDate = manufacturerDate;
            this.ExpiryDate = expiryDate;
            this.Amount = amount;
        }

    }

    //public class Coke : BasicProduct
    //{
    //    public bool SugarFree { get; private set; }
    //    private decimal _price;
    //    public decimal SizeInLitres
    //    {
    //        get { return _price; }

    //        private set
    //        { //you may put validation here  }
    //        }

    //    }
    //}
}
