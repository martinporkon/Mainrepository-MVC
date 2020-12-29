using System;
using Sooduskorv_MVC.Aids.Enums;

namespace Sooduskorv_MVC.Aids.Values
{
    public interface ITimeService
    {
        public DateTime GetCurrentTimeAsync(Time p);
        DateTime GetCurrentTime { get; }
        DateTime GetCurrentUtcDateTime { get; }
    }
}