namespace WebMVC.Bff.HttpAggregator.Core.User
{
    public interface ICurrentUserAccessor
    {
        string UserId { get; }
    }
}