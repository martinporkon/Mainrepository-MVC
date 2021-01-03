using Catalog.Data.Product;
using Catalog.Data.Services;
using Catalog.Domain.Product;
using System;

namespace Catalog.Domain.Service
{
    public sealed class Service : BaseProductInstance<ServiceType>
    {

        public Service(ProductInstanceData d = null) : base(d) { }

        public override ServiceType Type => type as ServiceType;

        public DateTime DeliveredFrom => Data?.DeliveredFrom ?? UnspecifiedValidFrom;

        public DateTime DeliveredTo => Data?.DeliveredTo ?? UnspecifiedValidFrom;

        public DateTime ScheduledFrom => Data?.ScheduledFrom ?? UnspecifiedValidFrom;

        public DateTime ScheduledTo => Data?.ScheduledTo ?? UnspecifiedValidFrom;

        public DeliveryStatus DeliveryStatus => Data?.DeliveryStatus ?? DeliveryStatus.Unspecified;

    }
}
