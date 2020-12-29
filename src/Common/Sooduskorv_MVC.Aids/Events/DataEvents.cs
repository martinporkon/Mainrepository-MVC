using Microsoft.Extensions.Logging;

namespace Sooduskorv_MVC.Aids.Events
{
    public class DataEvents
    {
        public static readonly EventId GetMany = new EventId(10001, "GetManyFromRepo");
        public static readonly EventId AmendOrder = new EventId(123, "EventForOrderAmend");
    }
}