using Quantity.Data;
using Quantity.Domain;
using Sooduskorv_MVC.Aids.Methods;

namespace Quantity.Facade {

    public static class MeasureViewFactory {

        public static Measure Create(MeasureView v) {
            var d = new MeasureData();
            Copy.Members(v, d);

            return MeasureFactory.Create(d);
        }

        public static MeasureView Create(Measure o) {
            var v = new MeasureView();
            Copy.Members(o.Data, v);
            v.MeasureType = o switch {
                BaseMeasure _ => MeasureType.Base,
                DerivedMeasure _ => MeasureType.Derived,
                _ => MeasureType.Unspecified
            };

            return v;
        }

    }

}
