using Microsoft.EntityFrameworkCore;
using Order.Data.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using Sooduskorv_MVC.Aids.Random;

namespace Order.Infra
{
    public class OrderDbInitializer : DbContext
    {
        internal static DateTime validFromMinimum = new DateTime(2019, 3, 1, 7, 0, 0);
        internal static DateTime validFromMaximum = DateTime.Now;

        internal static DateTime validToMinimum = DateTime.Now;
        internal static DateTime validToMaximum = new DateTime(2021, 3, 1, 7, 0, 0);

        internal static int randomDataGenerationAmount = 10;

        internal static List<OrderData> orders = new List<OrderData> { };
        internal static void generateOrders()
        {
            for (int i = 0; i < randomDataGenerationAmount; i++)
            {
                orders.Add(new OrderData
                {
                    ConfirmationDate = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                    Description = "",
                    Id = i.ToString(),
                    OrderStatus = GetRandom.Enum<OrderStatus>(),
                    ShipMethodsOfPartyId = Guid.NewGuid().ToString(),
                    ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                    ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)
                });
            }
        }
        
        private static bool initializeOrders(OrderDbContext db)
        {
            if (db.Orders.Count() != 0) return false;
            generateOrders();
            db.Orders.AddRange(orders);
            db.SaveChanges();
            return true;
        }
        
        public static bool Initialize(OrderDbContext db)
        {
            initializeOrders(db);
            return true;
        }

    }
}
