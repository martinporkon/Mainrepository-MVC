using Quantity.Data;

namespace Quantity.Domain {

    public static class UnitFactory {

        public static Unit Create(UnitData d = null) {
            return d?.UnitType switch {
                UnitType.Derived => new DerivedUnit(d),
                UnitType.Functioned => new FunctionedUnit(d),
                _ => new FactoredUnit(d)
            };
        }

    }

}