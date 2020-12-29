namespace Quantity.Domain {

    public sealed class UnspecifiedUnit : Unit {

        public override double ToBase(in double amount) => UnspecifiedDouble;

        public override double FromBase(in double amount) => UnspecifiedDouble;

        protected override Unit multiply(DerivedUnit u, string n = null, string c = null, string d = null) => this;

        protected override Unit multiply(FactoredUnit u, string n = null, string c = null, string d = null) => this;

        protected override Unit multiply(FunctionedUnit u, string n = null, string c = null, string d = null) => this;

        protected override Unit toPower(in int power, string n = null, string c = null, string d = null) => this;

        protected override string formula(bool isLong = false) => Unspecified;

        protected override Unit sqrt(string n = null, string c = null, string d = null) => this;

    }

}