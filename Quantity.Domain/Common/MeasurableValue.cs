using System;
using CommonData;
using Quantity.Core.Rounding;

namespace Quantity.Domain.Common {

    public abstract class MeasurableValue<TQuantity, TAmount, TMeasure> : PeriodData, IComparable<TQuantity>,
        IComparable
        where TQuantity : class
        where TMeasure : class, IDefinedEntity<DefinedEntityData> {

        protected readonly TMeasure measure;

        protected MeasurableValue(TAmount amount, TMeasure m, DateTime? date = null) {
            //TODO TMeasure must be added to the repository
            Amount = amount;
            measure = m;
            ValidFrom = date ?? DateTime.Now;
        }

        public override string ToString() => $"{Amount} {measure.Code}";
        
        public TAmount Amount { get; }

        public abstract int CompareTo(TQuantity other);

        public int CompareTo(object obj) => CompareTo(obj as TQuantity);

        public abstract TQuantity ConvertTo(TMeasure m);

        public abstract TQuantity Add(TQuantity q);
        public abstract TQuantity Subtract(TQuantity q);
        public abstract TQuantity Multiply(TAmount a);
        public abstract TQuantity Divide(TAmount a);
        public abstract TQuantity Round(IRoundingPolicy p);
        public abstract bool IsEqual(TQuantity q);
        public abstract bool IsLess(TQuantity q);
        public abstract bool IsGreater(TQuantity q);

    }

}