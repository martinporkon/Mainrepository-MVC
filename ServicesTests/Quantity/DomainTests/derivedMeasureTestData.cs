using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;

namespace ServicesTests.Quantity.DomainTests
{

    internal class derivedMeasureTestData {

        private readonly MeasureTermsRepository terms;
        private readonly MeasuresRepository measures;
        private readonly Measure obj;

        public derivedMeasureTestData(Measure m) {
            measures = GetRepository.Instance<IMeasuresRepository>() as MeasuresRepository;
            terms = GetRepository.Instance<IMeasureTermsRepository>() as MeasureTermsRepository;
            obj = m;
        }

        internal void add() {
            addTermAndMeasure("a", "aa", 1);
            addTermAndMeasure("b", "bb", -1);
            addTermAndMeasure("c", "cc", 2);
            addTermAndMeasure("d", "dd", -2);
        }

        private void addTermAndMeasure(string code, string name, int power) {
            var dMeasure = new MeasureData {Id = code, Code = code, Name = name, MeasureType = MeasureType.Base};
            var dTerm = new MeasureTermData {MasterId = obj.Id, TermId = dMeasure.Id, Power = power};
            terms.Add(new MeasureTerm(dTerm)).GetAwaiter();
            measures.Add(new BaseMeasure(dMeasure)).GetAwaiter();
        }

    }

}
