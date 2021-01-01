using System.ComponentModel;

namespace Quantity.Facade.Common
{
    public abstract class PartyAttributeView: UniqueEntityView
    {
        [DisplayName("Belongs to")]
        public string PartyId { get; set; }

    }
}
