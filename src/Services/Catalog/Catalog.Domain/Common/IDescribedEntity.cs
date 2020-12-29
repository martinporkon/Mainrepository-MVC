using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Common
{
    public interface IDescribedEntity : INamedEntity
    {

        string Description { get; }

    }
    public interface IDescribedEntity<out TData> : IDescribedEntity, IUniqueEntity<TData> { }
}
