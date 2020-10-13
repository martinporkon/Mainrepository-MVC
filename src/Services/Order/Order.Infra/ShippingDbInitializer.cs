using Aids.Random;
using Order.Data.ShipMethodOfParty;
using Order.Data.ShipMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Infra
{
    public class ShippingDbInitializer
    {
        internal static DateTime validFromMinimum = new DateTime(2019, 3, 1, 7, 0, 0);
        internal static DateTime validFromMaximum = DateTime.Now;

        internal static DateTime validToMinimum = DateTime.Now;
        internal static DateTime validToMaximum = new DateTime(2021, 3, 1, 7, 0, 0);
        internal static decimal minimalOrderAmount = 19.99M;
        internal static int randomDataGenerationAmount = 10;

        internal static List<ShipMethodsOfPartyData> shipmethodsOfParties = new List<ShipMethodsOfPartyData> { };
        internal static void generateShipmethodsOfParties()
        {
            for (int i = 0; i < shipmethods.Count(); i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    shipmethodsOfParties.Add(new ShipMethodsOfPartyData
                    {
                        Id = Guid.NewGuid().ToString(),
                        ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                        ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum),
                        ShipMethodId = i.ToString(),
                        PartyId = k.ToString(),
                        MinimalOrderPrice = minimalOrderAmount,
                        Price = GetRandom.Decimal(0, 15)
                    });
                }
            }
        }

        internal static List<ShipMethodData> shipmethods => new List<ShipMethodData>
        {
             new ShipMethodData{ Description = "Telli kaup läbi tellitoit.ee teenuse", Id = "0", Name = "Tellitoit.ee", ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum) },

            new ShipMethodData{ Description = "Juriidilistel põhjustel ei ole võimalik tellida alkohoolseid jooke teliimustes, " +
                "mille kohaletoimetamise aeg on vahemikus 10.00 – 12.00.", Id = "1", Name = "Kojuvedu", ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum) },

            new ShipMethodData{ Description = "Kauba väljastamine Drive-In teenuspunktist", Id = "2", Name = "Telli ja tule järgi", ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum) },

            new ShipMethodData{ Description = "Kauba väljastamine pakiautomaadist", Id = "3", Name = "Telli ja võta toit pakiautomaadist", ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum) },

        };

        private static bool initializeShipmethodOfParties(ShippingDbContext db)
        {
            if (db.ShipMethodsOfParties.Count() != 0) return false;
            generateShipmethodsOfParties();
            db.ShipMethodsOfParties.AddRange(shipmethodsOfParties);
            db.SaveChanges();
            return true;
        }
        private static bool initializeShipmethods(ShippingDbContext db)
        {
            if (db.ShipMethods.Count() != 0) return false;
            db.ShipMethods.AddRange(shipmethods);
            db.SaveChanges();
            return true;
        }

        public static bool Initialize(ShippingDbContext db)
        {
            initializeShipmethods(db);
            initializeShipmethodOfParties(db);
            return true;
        }
    }
}
