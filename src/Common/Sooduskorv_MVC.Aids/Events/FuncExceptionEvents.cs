using System;
using Microsoft.Extensions.Logging;

namespace Sooduskorv_MVC.Aids.Events
{
    public class FuncExceptionEvents
    {
        public static Func<EventId, EventId> Todo { get; set; }
        public static Func<string, EventId> TODO { get; set; }
    }
}