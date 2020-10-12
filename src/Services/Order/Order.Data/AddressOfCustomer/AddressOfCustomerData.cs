using CommonData;

namespace Order.Data.AddressOfCustomer
{
    public sealed class AddressOfCustomerData :PeriodData
    {
        public string AddressId { get; set; }
        public string CustomerId { get; set; }
    }
}