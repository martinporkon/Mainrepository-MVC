using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Basket.Domain.Common
{
    public interface ISpecification<T>
    {
        IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; }
        bool IsSatisfiedBy(T candidate);
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> AndNot(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> OrNot(ISpecification<T> other);
        ISpecification<T> Not();
        int Take { get; }
        int Skip { get; }
    }
}