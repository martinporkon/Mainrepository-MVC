using System;
using System.Collections.Generic;
using System.Text;

namespace WebMVC.Bff.HttpAggregator.Core.Errors
{
    public abstract class Error
    {
        public abstract TResult Accept<TVisitor, TResult>(TVisitor visitor)
            where TVisitor : IErrorVisitor<TResult>;
    }
}