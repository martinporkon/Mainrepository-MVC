using System;
using Microsoft.Extensions.Logging;

namespace Sooduskorv_MVC.Aids.Logging
{
    public static class LogKeys
    {
        public static string OrderEventForAmended => "OrderAmendEvent";
        private static Func<string, string> OrderIdForSubjectId { get; set; }
        private static Func<string, EventId, string> ForSubjectId { get; set; }
    }
}