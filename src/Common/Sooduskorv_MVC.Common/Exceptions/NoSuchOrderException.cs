using System;

namespace Sooduskorv_MVC.Common.Exceptions
{
    [Serializable()]
    public class NoSuchOrderException : Exception
    {
        internal NoSuchOrderException(string message)
            : base(message)
        {
            // Add any type-specific logic.
        }
    }
}