using System;
using System.Collections.Generic;
using System.Linq;
using Quantity.Data;
using Quantity.Domain.Common;
using Sooduskorv_MVC.Aids.Reflection;

namespace Quantity.Domain {

    public sealed class DerivedUnit : Unit {

        private readonly UnitTerms terms;
        internal static string field => GetMember.Name<UnitTermData>(x => x.MasterId);

        public DerivedUnit(UnitData d = null) : base(d) { }
        public DerivedUnit(UnitData d, Measure m, UnitTerms t= null) : base(d, m)  => terms = t;
        public IReadOnlyList<UnitTerm> Terms => terms?.AsReadOnly()?? new GetFrom<IUnitTermsRepository, UnitTerm>().ListBy(field, Id);

        public override double ToBase(in double d) {
            var r = d;

            foreach (var t in Terms) {
                var u = t.TermUnit;
                var p = t.Power;

                if (p == 0) continue;

                if (p > 0) for (var i = 1; i <= p; i++) r *= u.ToBase(1);
                else for (var i = -1; i >= p; i--) r /= u.ToBase(1);
            }

            return r;
        }
        public override double FromBase(in double d) {
            var r = d;

            foreach (var t in Terms) {
                var u = t.TermUnit;
                var p = t.Power;

                if (p == 0) continue;

                if (p > 0) for (var i = 1; i <= p; i++) r *= u.FromBase(1);
                else for (var i = -1; i >= p; i--) r /= u.FromBase(1);
            }

            return r;
        }
        protected override Unit multiply(DerivedUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            foreach (var t in Terms) addTerm(t.TermUnit, t.Power);
            foreach (var t in u.Terms) addTerm(t.TermUnit, t.Power);

            return unit;
        }
        protected override Unit multiply(FactoredUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            foreach (var t in Terms) addTerm(t.TermUnit, t.Power);
            addTerm(u, 1);

            return unit;
        }
        protected override Unit multiply(FunctionedUnit u, string n = null, string c = null, string d = null) {
            var m = Measure.Multiply(u.Measure);
            createUnit(m, n, c, d);
            foreach (var t in Terms) addTerm(t.TermUnit, t.Power);
            addTerm(u, 1);

            return unit;
        }
        protected override Unit toPower(in int power, string n = null, string c = null, string d = null) {
            var m = Measure.Power(power);
            createUnit(m, n, c, d);
            foreach (var t in Terms) addTerm(t.TermUnit, t.Power * power);

            return unit;
        }
        protected override string formula(bool isLong = false)
        {

            var d = Terms.ToDictionary(e => e.Formula(isLong), e => e.Power);

            d = d.OrderByDescending(x => x.Value, new elementComparer()).ToDictionary(pair => pair.Key, pair => pair.Value);

            var l = d.Where(e => e.Value != 0).Select(e => e.Key).ToList();

            return l.Aggregate(string.Empty, (c, s)
                => c == string.Empty ? s : $"{c} * {s}");

        }
        protected override Unit sqrt(string n = null, string c = null, string d = null) {
            var m = Measure.Sqrt();
            createUnit(m, n, c, d);
            foreach (var t in Terms) addTerm(t.TermUnit, t.Power / 2);

            return unit;
        }

        private class elementComparer : IComparer<int>
        {

            public int Compare(int x, int y)
            {
                if (x == y) return 0;
                if ((x > 0) & (y < 0)) return 1;
                if ((x < 0) & (y > 0)) return -1;
                x = Math.Abs(x);
                y = Math.Abs(y);
                if (x > y) return -1;
                if (x < y) return 1;

                return 0;
            }

        }

    }

}