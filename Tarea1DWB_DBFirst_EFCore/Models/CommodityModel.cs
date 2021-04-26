using System;
using System.Collections.Generic;
using System.Text;

namespace DBFirst.Models
{
    public class CommodityModel
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public decimal? Price { get; set; }
        public short Stock {get; set;}
    }
}
