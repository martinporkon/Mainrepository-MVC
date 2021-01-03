using Quantity.Data;

namespace Quantity.Domain.Common {

    public abstract class Term<TData> : Entity<TData>, ITerm where TData: CommonTermData, new(){

        protected Term(TData data) : base(data) {}

        protected Term()
        {
        }

        public int Power => data?.Power?? 0;
        
        protected internal string formula(string s) => Power  == 1 ? s : $"{s}^{Power}";

    }

}