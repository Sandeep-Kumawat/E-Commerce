using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database
{
    public class Inventory:BaseRecordType
    {
        public int Id { get; private set; }
        public string ProductCode { get; private set; }
        public int Quantity { get;  set; }

        public Inventory(int id,string productCode, int quantity)
        {
            this.Id = id;
            this.Name = productCode;
            this.ProductCode = productCode;
            this.Quantity = quantity;
        }
    }
}
