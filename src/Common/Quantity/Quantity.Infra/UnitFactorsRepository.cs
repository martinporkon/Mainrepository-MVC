using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;
using Sooduskorv_MVC.Aids.Extensions;

namespace Quantity.Infra {

    public sealed class UnitFactorsRepository : PaginatedRepository<UnitFactor, UnitFactorData>, IUnitFactorsRepository {

        public UnitFactorsRepository(QuantityDbContext c = null) : base(c, c?.UnitFactors) { }

        public override UnitFactor toDomainObject(UnitFactorData d) => new UnitFactor(d);

        protected override async Task<UnitFactorData> getData(string id) {
            var systemOfUnitsId = id.GetHead();
            var unitId = id.GetTail();

            return await dbSet.SingleOrDefaultAsync(x => x.SystemOfUnitsId == systemOfUnitsId && x.UnitId == unitId);
        }
        protected override UnitFactorData getDataById(UnitFactorData d)
            => dbSet.Find(d.SystemOfUnitsId, d.UnitId);

    }

}
