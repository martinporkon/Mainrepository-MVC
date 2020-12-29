﻿using Aids.Methods;
using Quantity.Data;
using Quantity.Domain;

namespace Quantity.Facade {

    public static class SystemOfUnitsViewFactory {

        public static SystemOfUnits Create(SystemOfUnitsView v) {
            var d = new SystemOfUnitsData();
            if ( !(v is null)) Copy.Members(v, d);

            return new SystemOfUnits(d);
        }

        public static SystemOfUnitsView Create(SystemOfUnits o) {
            var v = new SystemOfUnitsView();

            if (! (o is null)) Copy.Members(o.Data, v);

            return v;
        }

    }

}
