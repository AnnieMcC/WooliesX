using System;
namespace WooliesX.Core.Models
{
    public class Product : BaseId<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
