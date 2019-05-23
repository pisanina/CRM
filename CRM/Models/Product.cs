using System;

namespace CRM.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
    }
}