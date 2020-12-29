using Sooduskorv_MVC.Data.CommonData;

namespace Order.Data.AddressOfCustomer
{
    public sealed class AddressOfCustomerData :AddressedEntityData
    {
        public string BuyerId { get; set; }
        public string Id { get; set; }
    }
}