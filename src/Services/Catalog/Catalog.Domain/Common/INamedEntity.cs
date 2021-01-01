using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Common
{
    public interface INamedEntity : IUniqueEntity
    {
        string Name { get; }     
    }

    public interface INamedEntity<out TData> : INamedEntity, IEntity<TData> { }
}
