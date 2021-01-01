using System.Threading.Tasks;
using Aids.Extensions;
using Microsoft.EntityFrameworkCore;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;

namespace Quantity.Infra {

    public sealed class MeasureTermsRepository : PaginatedRepository<MeasureTerm, MeasureTermData>, IMeasureTermsRepository {

        public MeasureTermsRepository(QuantityDbContext c = null) : base(c, c?.MeasureTerms) { }

        public override MeasureTerm toDomainObject(MeasureTermData d) => new MeasureTerm(d);

        protected override async Task<MeasureTermData> getData(string id) {
            var masterId = id.GetHead();
            var termId = id.GetTail();
            return await dbSet.SingleOrDefaultAsync(x => x.TermId == termId && x.MasterId == masterId);
        }
        protected override MeasureTermData getDataById(MeasureTermData d)
            => dbSet.Find(d.MasterId, d.TermId);

    }

}
