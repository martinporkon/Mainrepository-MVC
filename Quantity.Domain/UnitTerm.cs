using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public sealed class UnitTerm : Term<UnitTermData> {

        private readonly DerivedUnit master;
        private readonly Unit term;

        public UnitTerm(UnitTermData data = null) : base(data) { }

        public UnitTerm(UnitTermData data, DerivedUnit m, Unit t) : this(data) {
            master = m;
            term = t;
        }

        public string MasterUnitId => Data?.MasterId ?? Unspecified;

        public string TermUnitId => Data?.TermId ?? Unspecified;

        public DerivedUnit MasterUnit => master ?? new GetFrom<IUnitsRepository, Unit>().ById(MasterUnitId) as DerivedUnit;

        public Unit TermUnit => term ?? new GetFrom<IUnitsRepository, Unit>().ById(TermUnitId);

        public string Formula(in bool isLong = false) => isLong ? formula(TermUnit.Name) : formula(TermUnit.Code);

    }

}
