using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;
using Sooduskorv_MVC.Aids.Extensions;

namespace Quantity.Infra {

    public sealed class UnitTermsRepository : PaginatedRepository<UnitTerm, UnitTermData>, IUnitTermsRepository {

        public UnitTermsRepository(QuantityDbContext c = null) : base(c, c?.UnitTerms) { }

        protected internal override UnitTerm toDomainObject(UnitTermData d) => new UnitTerm(d);

        protected override async Task<UnitTermData> getData(string id) {
            var masterId = id?.GetHead();
            var termId = id?.GetTail();

            return await dbSet.SingleOrDefaultAsync(x => x.TermId == termId && x.MasterId == masterId);
        }

        protected override UnitTermData getDataById(UnitTermData d) 
            => dbSet.Find(d?.MasterId, d?.TermId);

    }

}

