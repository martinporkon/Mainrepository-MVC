using System.ComponentModel;
using Quantity.Facade.Common;
using Sooduskorv_MVC.Aids.Methods;

namespace Quantity.Facade {

    public abstract class CommonTermView : PeriodView {

        public int Power { get; set; }

        [DisplayName("Term")]
        public string TermId { get; set; }

        [DisplayName("Metric")]
        public string MasterId { get; set; }

        public override string GetId() => Compose.Id(MasterId, TermId);

    }

}
