using Catalog.Domain.Common;
using CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Catalog
{
    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NamedEntityData, new()
    {

        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name => Data?.Name ?? Unspecified;
    }
}
