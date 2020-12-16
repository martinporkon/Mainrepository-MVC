using System;

namespace Sooduskorv_MVC.Aids.Values
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime => DateTime.Now;
        public DateTime CurrentUtcDateTime => DateTime.UtcNow;
        /*public DateTime TimeInLondonVms => DateTime.UtcNow;*/
        /*public DateTime TimeInNewYorkVms => DateTime.UtcNow;*/
    }
}