using System;
using System.Runtime.Serialization;

namespace Sooduskorv_MVC.Aids.Methods
{
    [Serializable()]
    public class Exceptions : Exception
    {
        internal Exceptions()
        {
            // Add any type-specific logic, and supply the default message.
            throw new ArgumentException();
        }

        internal Exceptions(string message)
            : base(message)
        {
            // Add any type-specific logic.
        }

        internal Exceptions(string message, Exception innerMostException)
            : base(message, innerMostException)
        {
            // Add any type-specific logic for innerMost exceptions.
            throw new ArgumentException();
        }

        internal Exceptions(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }

        // TODO OperationCanceledException
    }
}