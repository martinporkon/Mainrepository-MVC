using Quantity.Data;

namespace Quantity.Domain {

    public sealed class UnitFactor : UnitAttribute<UnitFactorData>
    {

        public UnitFactor(UnitFactorData d = null) : base(d) { }

        public UnitFactor()
        { 
        }


        public double Factor => Data?.Factor ?? 0D;

    }

}
