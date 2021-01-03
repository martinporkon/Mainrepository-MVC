using System.Collections.Generic;
using System.Linq;
using Quantity.Data;
using Quantity.Domain.Common;
using Sooduskorv_MVC.Aids.Reflection;

namespace Quantity.Domain {

    public sealed class FunctionedUnit : Unit {

        internal static string field => GetMember.Name<UnitRulesData>( x => x.UnitId);

        public FunctionedUnit(UnitData d = null) : base(d) { }

        public IReadOnlyList<UnitRules> Rules => new GetFrom<IUnitRulesRepository, UnitRules>().ListBy(field,Id);

        public UnitRules SiSystemRules
            => Rules.FirstOrDefault(x => x.SystemOfUnitsId == Core.Units.SystemOfUnits.SiSystemId) ??
               Rules.FirstOrDefault() ??
               new UnitRules();

        //public BaseRule ToBaseUnitRule => SiSystemRules.ToBaseUnitRule;
        
        //public BaseRule FromBaseUnitRule => SiSystemRules.FromBaseUnitRule;

        //public override double ToBase(in double amount) =>Doubles.ToDouble(ToBaseUnitRule.Evaluate(amount));
        //public override double FromBase(in double amount) => Doubles.ToDouble(FromBaseUnitRule.Evaluate(amount));
        public override double ToBase(in double amount)
        {
            throw new System.NotImplementedException();
        }

        public override double FromBase(in double amount)
        {
            throw new System.NotImplementedException();
        }

        protected override Unit multiply(DerivedUnit u, string n = null, string c = null, string d = null)
        {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            addTerm(this, 1);

            foreach (var t in u.Terms) addTerm(t.TermUnit, t.Power);

            return unit;
        }
        protected override Unit multiply(FactoredUnit u, string n = null, string c = null, string d = null)
        {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            addTerm(this, 1);
            addTerm(u, 1);

            return unit;
        }
        protected override Unit multiply(FunctionedUnit u, string n = null, string c = null, string d = null)
        {
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