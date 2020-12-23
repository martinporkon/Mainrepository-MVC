using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Aids.Methods;
using Quantity.Facade.Common;

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
