using Aids.Methods;
using Quantity.Data;
using Quantity.Domain;

namespace Quantity.Facade {

    public static class UnitTermViewFactory {

        public static UnitTerm Create(UnitTermView v) {
            var d = new UnitTermData();
            Copy.Members(v, d);

            return new UnitTerm(d);
        }

        public static UnitTermView Create(UnitTerm o) {
            var v = new UnitTermView();
            Copy.Members(o.Data, v);

            return v;
        }

    }

}
