using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public sealed class MeasureTerm : Term<MeasureTermData> {

        private readonly DerivedMeasure master;
        private readonly BaseMeasure term;

        public MeasureTerm(MeasureTermData data = null) : base(data) { }

        public MeasureTerm(MeasureTermData data, DerivedMeasure m, BaseMeasure t) : this(data) {
            master = m;
            term = t;
        }

      

        public string MasterMeasureId => Data?.MasterId ?? Unspecified;

        public string TermMeasureId => Data?.TermId ?? Unspecified;

        public DerivedMeasure MasterMeasure => master?? new GetFrom<IMeasuresRepository, Measure>().ById(MasterMeasureId) as DerivedMeasure;

        public BaseMeasure TermMeasure => term?? new GetFrom<IMeasuresRepository, Measure>().ById(TermMeasureId) as BaseMeasure;

        public string Formula(in bool isLong = false) => isLong ? formula(TermMeasure.Name) : formula(TermMeasure.Code);

    }

}


