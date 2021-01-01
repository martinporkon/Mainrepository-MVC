using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Common
{
    public interface IUniqueEntity : IEntity
    {

        string Id { get; }

    }

    public interface IUniqueEntity<out TData> : IUniqueEntity, IEntity<TData> { }
}
