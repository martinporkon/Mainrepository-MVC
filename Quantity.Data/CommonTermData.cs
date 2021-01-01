using CommonData;

namespace Quantity.Data {

    public abstract class CommonTermData : PeriodData {

        protected CommonTermData() : this(null) { }

        protected CommonTermData(string masterId = null, int power = 0, string termId = null)
        {
            MasterId = masterId;
            Power = power;
            TermId = termId;
        }
        public int Power { get; set; }
        public string TermId { get; set; }
        public string MasterId { get; set; }

    }

}
