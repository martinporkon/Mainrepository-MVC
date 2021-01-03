using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Quantity.Data;
using Quantity.Facade.Common;

namespace Quantity.Facade
{
    public sealed class UnitView: DefinedView
    {
        [Required]
        [DisplayName("Measure")]
        public string MeasureId { get; set; }

        [Required]
        [DisplayName("Type")]

        public UnitType UnitType { get; set; }
    }
}
