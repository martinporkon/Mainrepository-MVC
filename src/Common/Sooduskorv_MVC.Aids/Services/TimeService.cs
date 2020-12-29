using System;
using Sooduskorv_MVC.Aids.Enums;

namespace Sooduskorv_MVC.Aids.Values
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTimeAsync(Time p) => throw new NotImplementedException();

        public DateTime GetCurrentTime => DateTime.Now;

        public DateTime GetCurrentUtcDateTime => DateTime.UtcNow;
    }
}