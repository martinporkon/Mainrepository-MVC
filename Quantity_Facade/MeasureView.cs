using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Quantity.Data;
using Quantity.Facade.Common;

namespace Quantity.Facade {

    public sealed class MeasureView : DefinedView {

        [Required]
        [DisplayName("Type")]

        public MeasureType MeasureType { get; set; }

    }

}
