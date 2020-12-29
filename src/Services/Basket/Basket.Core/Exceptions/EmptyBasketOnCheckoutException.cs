using System;
using System.Runtime.Serialization;

namespace Basket.Core.Exceptions
{
    [Serializable()]
    public class EmptyBasketOnCheckoutException : Exception
    {
        public EmptyBasketOnCheckoutException() : base($"Basket cannot have 0 items on checkout")
        {

        }

        protected EmptyBasketOnCheckoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public EmptyBasketOnCheckoutException(string message) : base(message)
        {

        }

        public EmptyBasketOnCheckoutException(string message, Exception innerMostException) : base(message, innerMostException)
        {

        }
    }
}