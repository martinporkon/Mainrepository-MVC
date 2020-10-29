using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Sooduskorv_MVC.Aids.Events
{
    public class DataEvents
    {
        public static EventId GetMany = new EventId(10001, "GetManyFromRepo");
    }
}