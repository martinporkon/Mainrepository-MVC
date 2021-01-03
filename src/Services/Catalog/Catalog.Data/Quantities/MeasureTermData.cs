namespace Catalog.Data.Quantities
{

    public sealed class MeasureTermData : CommonTermData
    {

        public MeasureTermData() : this(null) { }

        public MeasureTermData(string masterId = null, int power = 0, string termId = null) :
            base(masterId, power, termId)
        { }

    }

}