using System.Linq;
using Aids.Random;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    internal class derivedUnitTestData {

        private readonly IUnitTermsRepository terms;
        private readonly IUnitsRepository units;
        private readonly IUnitFactorsRepository factors;
        private readonly DerivedUnit obj;
        private readonly bool factored;
        private double fa;
        private double fb;
        private double fc;
        private double fd;

        public derivedUnitTestData(DerivedUnit u, bool onlyFactored = false) {
            units = GetRepository.Instance<IUnitsRepository>();
            terms = GetRepository.Instance<IUnitTermsRepository>();
            factors = GetRepository.Instance<IUnitFactorsRepository>();
            obj = u;
            factored = onlyFactored;
        }
        internal void add() {
            addTermAndUnit("a", 1);
            addTermAndUnit("b", -1);
            addTermAndUnit("c", 2);
            addTermAndUnit("d", -2);
            getFactors();
        }
        private void getFactors() {
            fa = getFactor("ua");
            fb = getFactor("ub");
            fc = getFactor("uc");
            fd = getFactor("ud");
        }
        private void addTermAndUnit(string code, int power) {
            var c = code;
            var id = getMeasureId(code, obj);
            var i = GetRandom.Int32(3, 5);
            do {
                var dUnit = addUnit(id, c);
                if (c == code) addTerm(dUnit, power);
                c = code + i--;

                if (dUnit.UnitType == UnitType.Functioned) return;
                addFactor(dUnit);
            } while (i >= 0);
        }
        private UnitData addUnit(string id, string code) {
            var b = factored || GetRandom.Bool();
            var dUnit = new UnitData {
                MeasureId = id,
                Id = "u" + code,
                Code = "u" + code,
                Name = "uu" + code,
                UnitType = b ? UnitType.Factored : UnitType.Functioned
            };
            units.Add(UnitFactory.Create(dUnit)).GetAwaiter();

            return dUnit;
        }
        private void addTerm(UnitData dUnit, int power) {
            var dTerm = new UnitTermData {MasterId = obj.Id, TermId = dUnit.Id, Power = power};
            terms.Add(new UnitTerm(dTerm)).GetAwaiter();
        }
        private void addFactor(UnitData dUnit) {
            var f = GetRandom.Int32(5, 100);
            var dFactor = new UnitFactorData
                {UnitId = dUnit.Id, Factor = f, SystemOfUnitsId = global::Quantity.Core.Units.SystemOfUnits.SiSystemId };
            factors.Add(new UnitFactor(dFactor)).GetAwaiter();
        }
        private string getMeasureId(string c, Unit u) {
            var m = (u.Measure as DerivedMeasure)?.Terms
                .FirstOrDefault(x => x.TermMeasure.Code == c);

            return m?.TermMeasure.Id;
        }
        private double getFactor(string c) {
            var t = obj?.Terms?.FirstOrDefault(x => x.TermUnit.Code == c);
            var u = t?.TermUnit as FactoredUnit;
            var d = u?.Factor ?? double.NaN;

            return d;
        }
        internal double fromBase(double d) {
            d /= fa;
            d /= (fc * fc);
            d *= fb;
            d *= (fd * fd);

            return d;
        }
        internal double toBase(double d) {
            d *= fa;
            d *= (fc * fc);
            d /= fb;
            d /= (fd * fd);

            return d;
        }

    }

}
