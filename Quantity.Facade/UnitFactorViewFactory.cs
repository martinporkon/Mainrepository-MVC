using Aids.Methods;
using Quantity.Data;
using Quantity.Domain;

namespace Quantity.Facade {

    public static class UnitFactorViewFactory {

        public static UnitFactor Create(UnitFactorView v) {
            var d = new UnitFactorData();
            Copy.Members(v, d);

            return new UnitFactor(d);
        }

        public static UnitFactorView Create(UnitFactor o) {
            var v = new UnitFactorView();
            Copy.Members(o.Data, v);

            return v;
        }

    }

}
