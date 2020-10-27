using Aids.Enums;
using Aids.Random;
using Order.Data.Addresses;
using Order.Data.AddressOfCustomer;
using Order.Data.AddressOfParty;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Infra
{
    public class AddressDbInitializer
    {
        internal static DateTime validFromMinimum = new DateTime(2019, 3, 1, 7, 0, 0);
        internal static DateTime validFromMaximum = DateTime.Now;

        internal static DateTime validToMinimum = DateTime.Now;
        internal static DateTime validToMaximum = new DateTime(2021, 3, 1, 7, 0, 0);
  
        internal static int randomDataGenerationAmount = 10;

        internal static List<AddressData> addresses = new List<AddressData> { };
        internal static void generateAddresses()
        {
            for (int i = 0; i < randomDataGenerationAmount; i++)
            {
                addresses.Add(new AddressData
                {
                    Address = GetRandom.String() + " linn, " + GetRandom.String() + " " + GetRandom.Int8(1, 99),
                    Area = GetRandom.Enum<Areas>().ToString(),
                    EmailAddress = GetRandom.Email(),
                    Id = i.ToString(),
                    Phone = GetRandom.Int32(50000000, 59999999).ToString(),
                    PostalCode = GetRandom.UInt16(10000, 65534).ToString(),
                    ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                    ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)
                });
            }
        }

        internal static List<AddressOfCustomerData> addressesOfCustomers = new List<AddressOfCustomerData> { };
        internal static void generateAddressOfCustomers()
        {
            for (int i = 0; i < addresses.Count(); i++)
            {
                addressesOfCustomers.Add(new AddressOfCustomerData
                {
                    AddressId = i.ToString(),
                    BuyerId = GetRandom.Int32(0, randomDataGenerationAmount).ToString(),
                    Id = i.ToString(),
                    ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                    ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)
                });
            }
        }

        internal static List<AddressOfPartyData> addressesOfParties = new List<AddressOfPartyData> { };
        internal static void generateAddressOfParties()
        {
            for (int i = 0; i < randomDataGenerationAmount; i++)
            {
                addressesOfParties.Add(new AddressOfPartyData
                {
                    AddressId = i.ToString(),
                    PartyId = i.ToString(),
                    Id = i.ToString(),
                    ValidFrom = GetRandom.DateTime(validFromMinimum, validFromMaximum),
                    ValidTo = GetRandom.DateTime(validToMinimum, validToMaximum)
                });
            }
        }
        private static bool initializeAddresses(AddressDbContext db)
        {
            if (db.Addresses.Count() != 0) return false;
            generateAddresses();
            db.Addresses.AddRange(addresses);
            db.SaveChanges();
            return true;
        }
        private static bool initializeAddressesOfCustomers(AddressDbContext db)
        {
            if (db.AddressOfCustomers.Count() != 0) return false;
            generateAddressOfCustomers();
            db.AddressOfCustomers.AddRange(addressesOfCustomers);
            db.SaveChanges();
            return true;
        }

        private static bool initializeAddressesOfParties(AddressDbContext db)
        {
            if (db.AddressOfParties.Count() != 0) return false;
            generateAddressOfParties();
            db.AddressOfParties.AddRange(addressesOfParties);
            db.SaveChanges();
            return true;
        }
        public static bool Initialize(AddressDbContext db)
        {
            initializeAddresses(db);
            initializeAddressesOfCustomers(db);
            initializeAddressesOfParties(db);
            return true;
        }
    }
}
