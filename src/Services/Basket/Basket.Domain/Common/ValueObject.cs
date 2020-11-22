using System;
using System.Collections.Generic;
using System.Linq;
using Basket.Domain.Common;
using Sooduskorv_MVC.Aids.Methods;

namespace Catalog.Domain.Common
{
    public abstract class ValueObject<TData> : BaseEntity where TData : class, new()
    {
        protected readonly TData data;
        internal static Guid guid;
        protected internal ValueObject(TData d = null) => data = d ?? new TData();

        public TData Data
        {
            get
            {
                if (data is null) return null;
                var d = new TData();
                Copy.Members(data, d);

                return d;// TODO
            }
        }

        private static bool isGuid(string s)
        {
            try
            {
                guid = new Guid(s);
                return true;
            }
            catch (FormatException) { return false; }
        }

        public static bool operator ==(ValueObject<TData> left, ValueObject<TData> right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(ValueObject<TData> left, ValueObject<TData> right)
        {
            return !(left == right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject<TData>)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}