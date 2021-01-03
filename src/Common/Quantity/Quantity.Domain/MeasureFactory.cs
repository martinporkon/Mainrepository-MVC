using Quantity.Data;

namespace Quantity.Domain {

    public static class MeasureFactory {

        public static Measure Create(MeasureData d = null) {
            return d?.MeasureType switch {
                MeasureType.Derived => new DerivedMeasure(d),
                _ => new BaseMeasure(d)
            };
        }

    }

}
