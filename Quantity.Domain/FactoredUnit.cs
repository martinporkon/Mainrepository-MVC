using System.Collections.Generic;
using System.Linq;
using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public sealed class FactoredUnit : Unit {

        internal static string field => GetMember.Name<UnitFactorData>( x => x.UnitId);

        public FactoredUnit(UnitData d = null) : base(d) { }

        public IReadOnlyList<UnitFactor> Factors => new GetFrom<IUnitFactorsRepository, UnitFactor>().ListBy(field,Id);

        public UnitFactor SiSystemFactor
            => Factors.FirstOrDefault(x => x.SystemOfUnitsId == Core.Units.SystemOfUnits.SiSystemId) ??
               Factors.FirstOrDefault() ??
               new UnitFactor();

        public double Factor => SiSystemFactor.Factor;

        public override double ToBase(in double amount) => amount * Factor;

        public override double FromBase(in double amount) => amount / Factor;

        protected override Unit multiply(DerivedUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            addTerm(this, 1);

            foreach (var t in u.Terms) addTerm(t.TermUnit, t.Power);

            return unit;
        }
        protected override Unit multiply(FactoredUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            addTerm(this, 1);
            addTerm(u, 1);

            return unit;
        }
        protected override Unit multiply(FunctionedUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            addTerm(this, 1);
            addTerm(u, 1);

            return unit;
        }
        protected override Unit toPower(in int power, string n = null, string c = null, string d = null) {
            var m = Measure.Power(power);
            createUnit(m, n, c, d);
            addTerm(this, power);

            return unit;
        }
        protected override string formula(bool isLong = false) => isLong ? Name : Code;
        protected override Unit sqrt(string n = null, string c = null, string d = null) {
            var m = Measure.Sqrt();
            createUnit(m, n, c, d);

            return unit;
        }

    }

}