namespace Catalog.Domain.Product
{
    public abstract class QuantifiedProductType : BaseProductType
    {

        //protected QuantifiedProductType(ProductTypeData d = null) : base(d) { }

        //public string UnitId => Data?.UnitId ?? Unspecified;

        //public Unit Unit => new GetFrom<IUnitsRepository, Unit>().ById(UnitId) ?? new UnspecifiedUnit();

        //public Measure Measure => Unit?.Measure ?? new UnspecifiedMeasure();

        //public IReadOnlyList<Unit> PossibleUnits => Measure?.Units;

        //public double Amount => Data?.Amount ?? UnspecifiedDouble;

        //public Quantity QuantityOnHand => new Quantity(Amount, UnitId);

    }
}
