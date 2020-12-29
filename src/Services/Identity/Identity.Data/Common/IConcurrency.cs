namespace Identity.Data.Entities
{
    public interface IConcurrency
    {
        string ConcurrencyStamp { get; set; }
    }
}