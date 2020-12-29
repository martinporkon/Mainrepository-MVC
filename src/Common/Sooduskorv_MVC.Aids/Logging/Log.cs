using System;

namespace Sooduskorv_MVC.Aids.Logging
{

    public static class Log
    {
        internal static ILogBook logBook;

        public static void Message(string message)
        {
            logBook?.WriteEntry(message);

            var a = LogKeys.OrderEventForAmended;
        }

        public static void Exception(Exception e)// TODO
        {
            logBook?.WriteEntry(e);
        }
    }

}