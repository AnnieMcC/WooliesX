using System;
using System.Collections.Generic;

namespace WooliesX.Core.Models
{
    public class ShopperHistory : BaseId<int>
    {
        public int CustomerId { get; set; }

        public List<Product> Products { get; set; }
    }
}
