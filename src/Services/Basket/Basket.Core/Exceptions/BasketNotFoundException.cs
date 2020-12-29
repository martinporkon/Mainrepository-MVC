using System;
using System.Runtime.Serialization;

namespace Basket.Core.Exceptions
{
    [Serializable()]
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(int basketId) : base($"No basket found with {basketId}")
        {

        }

        protected BasketNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public BasketNotFoundException(string message) : base(message)
        {

        }

        public BasketNotFoundException(string message, Exception innerMostException) : base(message, innerMostException)
        {

        }
    }
}