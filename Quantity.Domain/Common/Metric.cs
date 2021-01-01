using System.Collections.Generic;
using CommonData;

namespace Quantity.Domain.Common {

    public abstract class Metric<TData, TTerm> : CommonMetric<TData>
        where TData : CommonMetricData, new()
        where TTerm : ITerm {

        protected Metric(TData data = null) : base(data) { }

        public abstract IReadOnlyList<TTerm> Terms { get; }

    }

}