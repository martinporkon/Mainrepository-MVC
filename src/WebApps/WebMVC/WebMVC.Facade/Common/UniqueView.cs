namespace Web.Facade.Common
{
    public class UniqueView : PeriodView
    {
        public string Id { get; set; }
        public override string GetId() => Id;
    }
}