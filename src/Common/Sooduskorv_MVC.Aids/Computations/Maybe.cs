using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Sooduskorv_MVC.Aids.Extensions;

namespace Sooduskorv_MVC.Aids.Computations
{
    public readonly struct Maybe<T>
    {
        public T Value { get; }

        public bool HasValue { get; }

        internal Maybe(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public bool Equals([AllowNull] Maybe<T> other)
        {
            if (!HasValue && !other.HasValue)
            {
                return true;
            }
            else if (HasValue && other.HasValue)
            {
                return EqualityComparer<T>.Default.Equals(Value, other.Value);
            }

            return false;
        }

        public int CompareTo([AllowNull] Maybe<T> other)
        {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            return Comparer<T>.Default.Compare(Value, other.Value);
        }

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            if (none == null) throw new ArgumentNullException(nameof(none));
            return HasValue ? some(Value) : none();
        }

        public Maybe<TResult> Map<TResult>(Func<T, TResult> mapping)
        {
            if (mapping == null) throw new ArgumentNullException(nameof(mapping));

            return Match(
                some: value => Maybe.Some(mapping(value)),
                none: () => Maybe.None<TResult>()
            );
        }

        public Maybe<T> Or(T alternative) => HasValue ? this : Maybe.Some(alternative);

        public Maybe<T> Or(Func<T> alternativeFactory)
        {
            if (alternativeFactory == null) throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? this : Maybe.Some(alternativeFactory());
        }
    }
}