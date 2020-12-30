using System.Collections.Generic;
using Aids.Reflection;
using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public abstract class Measure : CommonMetric<MeasureData> {

        protected MeasureTerms measureTerms;
        protected MeasureData measureData;
        protected DerivedMeasure measure;
        protected MeasureTermData termData;
        protected MeasureTerm term;
        private string measureId => GetMember.Name<UnitData>(x => x.MeasureId);

        protected Measure(MeasureData d = null) : base(d) { }

        public IReadOnlyList<Unit> Units 
            => new GetFrom<IUnitsRepository, Unit>().ListBy(measureId, Id);

        public Measure Multiply(Measure m, string name = null, string c = null, string d = null) {
            if (m is DerivedMeasure x) return toIdIsFormula(multiply(x, name, c, d));

            return toIdIsFormula(multiply(m as BaseMeasure, name, c, d));
        }
        public Measure Power(int i, string n = null, string c = null, string d = null)
            => toIdIsFormula(power(i, n, c, d));

        public Measure Sqrt(string n = null, string c = null, string d = null)
            => toIdIsFormula(toSqrt(n, c, d));

        public Measure Divide(Measure m, string n = null, string c = null, string d = null) {
            if (m is DerivedMeasure x) return divide(x, n, c, d);

            return divide(m as BaseMeasure, n, c, d);
        }

        protected Measure divide(DerivedMeasure m, string n = null, string c = null, string d = null)
            => Multiply(m.Inverse(), n, c, d);

        protected Measure divide(BaseMeasure m, string name = null, string c = null, string d = null)
            => Multiply(m.Inverse(), name, c, d);


        protected abstract Measure multiply(BaseMeasure m, string n = null, string c = null, string d = null);

        protected abstract Measure multiply(DerivedMeasure m, string n = null, string c = null, string d = null);

        public Measure Inverse(string n = null, string c = null, string d = null) => Power(-1, n, c, d);

        private static Measure toIdIsFormula(Measure m) {
            m.data.Id = m.Formula();
            return m;
        }
        protected abstract Measure power(in int i, string n = null, string c = null, string d = null);

        public string Formula(in bool isLong = false)
        {
            var f = formula(isLong);

            return string.IsNullOrWhiteSpace(f) ? Unspecified : f;
        }
        protected abstract string formula(bool isLong = false);

        protected void createMeasure(string n = null, string c = null, string d = null) {
            measureTerms = new MeasureTerms();
            measureData = new MeasureData(n, c, d, MeasureType.Derived);

            measure = new DerivedMeasure(measureData, measureTerms);
        }

        protected void addTerm(BaseMeasure m, int power) {
            termData = new MeasureTermData(measureData.Id, power, m.Id);
            term = measureTerms.Find(x => x.TermMeasure.Name == m.Name);

            if (!(term is null)) {
                termData.Power = power + term.Power;
                measureTerms.Remove(term);
            }

            term = new MeasureTerm(termData, measure, m);
            measureTerms.Add(term);
        }
        
        protected abstract Measure toSqrt(string n = null, string c = null, string d = null);

    }

}
