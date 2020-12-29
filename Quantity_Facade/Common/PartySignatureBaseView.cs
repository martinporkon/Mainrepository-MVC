
using System.ComponentModel;

namespace Quantity.Facade.Common {

    public abstract class PartySignatureBaseView : PartyAttributeView {

        [DisplayName("Authentication")]
        public string AuthenticationId { get; set; }

        public string Reason { get; set; }

        [DisplayName("Party Summary")]
        public string PartySummaryId { get; set; }

        [DisplayName("Signed Entity")]
        public string SignedEntityId { get; set; }

        [DisplayName("Signed Entity Type")]
        public string SignedEntityTypeId { get; set; }



    }

}
