using Aids.Methods;
using Quantity.Data;
using Quantity.Domain;

namespace Quantity.Facade {

    public static class UnitViewFactory {

        public static Unit Create(UnitView v) {
            var d = new UnitData();
            Copy.Members(v, d);

            return UnitFactory.Create(d);
        }

        public static UnitView Create(Unit o) {
            var v = new UnitView();
            Copy.Members(o.Data, v);
            v.UnitType = o switch {
                FactoredUnit _ => UnitType.Factored,
                FunctionedUnit _ => UnitType.Functioned,
                DerivedUnit _ => UnitType.Derived,
                _ => UnitType.Unspecified
            };

            return v;
        }

    }

}
