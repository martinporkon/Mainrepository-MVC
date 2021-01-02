using Quantity.Data;

namespace Quantity.Domain {

    public sealed class UnitRules : UnitAttribute<UnitRulesData>
    {

        public UnitRules(UnitRulesData d = null) : base(d) { }
        public string FromBaseUnitRuleId => Data?.FromBaseUnitRuleId ?? Unspecified;

        public string ToBaseUnitRuleId => Data?.ToBaseUnitRuleId ?? Unspecified;

        //public BaseRule FromBaseUnitRule => new GetFrom<IRulesRepository, BaseRule>().ById(FromBaseUnitRuleId);

        //public BaseRule ToBaseUnitRule => new GetFrom<IRulesRepository, BaseRule>().ById(ToBaseUnitRuleId);

    }

}