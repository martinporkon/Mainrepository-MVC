using Order.Data.Common;

namespace Order.Data.ShipMethodOfParty
{
    public sealed class ShipMethodsOfPartyData : PricedEntityData
    {
        public string PartyId { get; set; }
        public string ShipMethodId { get; set; }
        public decimal MinimalOrderPrice { get; set; }
    }
}