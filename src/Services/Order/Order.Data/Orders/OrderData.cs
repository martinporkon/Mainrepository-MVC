using System;
using CommonData;

namespace Order.Data.Orders
{
    public sealed class OrderData : PeriodData
    {
        public string ShipMethodId { get; set; }
        public string OrderID { get; set; }
        public string Description { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}