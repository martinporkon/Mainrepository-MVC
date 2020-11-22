using System;
using System.Collections.Generic;
using System.Text;

namespace WebMVC.Bff.HttpAggregator.Core.Errors
{
    public sealed class Unauthorized : Error
    {
        public Unauthorized(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override TResult Accept<TVisitor, TResult>(TVisitor visitor)
            => visitor.Visit(this);
    }
}