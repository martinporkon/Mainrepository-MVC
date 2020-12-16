using System;
using System.Collections.Generic;
using System.Text;

namespace Sooduskorv_MVC.Aids.Constants
{
    public static class LogKeys// TODO kuhu kausta panna. Kas Constants või Logging? Low coupling põhimõte ning high cohesion kasutatava klassi perspektiivist.
    {
        public static string OrderEventForAmended => "OrderAmendEvent";

        /*
        const Func<string, string> OrderEventForAmended = "OrderAmendEvent";
    */
    }
}