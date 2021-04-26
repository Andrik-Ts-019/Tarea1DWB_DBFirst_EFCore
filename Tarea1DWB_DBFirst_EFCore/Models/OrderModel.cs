using System;
using System.Collections.Generic;
using System.Text;

namespace DBFirst.Models
{
    public class OrderModel
    {
        public string ClientID { get; set; }
        public int? ClerkID { get; set; }
        public DateTime? CashOrderDate { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? SentDate { get; set; }
        public int? ShipperID { get; set; }
        public decimal? Cargo { get; set; }
        public string TransportName { get; set; }
        public string TransportAddress { get; set; }
        public string TransportCity { get; set; }
    }
}
