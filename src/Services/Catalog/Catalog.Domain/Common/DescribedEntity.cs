using Catalog.Domain.Common;
using CommonData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Catalog
{
    public abstract class DescribedEntity<T> : NamedEntity<T>, IDescribedEntity<T> where T : DescribedEntityData, new()
    {

        protected internal DescribedEntity(T d = null) : base(d) { }

        public virtual string Description => Data?.Description ?? Unspecified;

    }
}
