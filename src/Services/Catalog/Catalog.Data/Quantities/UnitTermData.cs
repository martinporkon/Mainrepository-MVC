namespace Catalog.Data.Quantities
{


    public sealed class UnitTermData : CommonTermData
    {

        public UnitTermData() : this(null) { }

        public UnitTermData(string masterId = null, int power = 0, string termId = null) :
            base(masterId, power, termId)
        { }

    }

}