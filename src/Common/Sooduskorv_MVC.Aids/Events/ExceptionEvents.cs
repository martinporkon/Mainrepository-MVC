using Microsoft.Extensions.Logging;

namespace Sooduskorv_MVC.Aids.Events
{
    public class ExceptionEvents// TODO fix event ID.s. Replace with guid somehow?
    {
        public static readonly EventId Exception = new EventId(2783, "Exception");
        public static readonly EventId NotSupported = new EventId(09, "NotSupported");
        public static readonly EventId NotSupportedOperation = new EventId(26, "The operation was not supported");
    }
}