using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Common
{
    public interface IEntity
    {
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }

        bool IsUnspecified { get; }
    }
    public interface IEntity<out TData> : IEntity
    {
        TData Data { get; }
    }
}
