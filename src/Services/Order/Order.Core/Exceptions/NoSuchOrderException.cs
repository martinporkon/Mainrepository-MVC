using System;

namespace Order.Core
{
    [Serializable()]
    public class NoSuchOrderException : Exception
    {
        internal NoSuchOrderException(string message)
            : base(message)
        {

        }
    }
}