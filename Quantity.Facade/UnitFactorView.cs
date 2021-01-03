using System.ComponentModel;
using Quantity.Facade.Common;
using Sooduskorv_MVC.Aids.Methods;

namespace Quantity.Facade {

    public sealed class UnitFactorView : PeriodView {

        [DisplayName("Unit")]
        public string UnitId { get; set; }

        [DisplayName("System of Units")]
        public string SystemOfUnitsId { get; set; }

        public double Factor { get; set; }

        public override string GetId() => Compose.Id(SystemOfUnitsId, UnitId);

    }

}
