using Basket.Domain.Common;

namespace Catalog.Domain.Common
{
    public sealed class GetFrom<TRepository, TObject>
    {
        internal TRepository repository
            => GetRepository.Instance<TRepository>();


    }
}