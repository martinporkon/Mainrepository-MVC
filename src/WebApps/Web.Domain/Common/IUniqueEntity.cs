namespace Web.Domain.Common
{
    public interface IUniqueEntity : IDto
    {

        string Id { get; }

    }

    public interface IUniqueEntity<out TData> : IUniqueEntity, IDto<TData> { }
}