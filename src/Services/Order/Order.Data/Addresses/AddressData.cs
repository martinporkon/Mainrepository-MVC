using Order.Data.Common;

namespace Order.Data.Addresses
{
    public sealed class AddressData : PeriodData
    {
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Area { get; set; }
    }
}