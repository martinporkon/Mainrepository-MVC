namespace Quantity.Domain {

    public sealed class UnspecifiedMeasure : Measure {

        protected override Measure multiply(BaseMeasure m, string n = null, string c = null, string d = null) 
            => this;

        protected override Measure multiply(DerivedMeasure m, string n = null, string c = null, string d = null) =>
            this;

        protected override Measure power(in int i, string n = null, string c = null, string d = null) => this;

        protected override string formula(bool isLong = false) => Unspecified;

        protected override Measure toSqrt(string n = null, string c = null, string d = null) => this;

    }

}