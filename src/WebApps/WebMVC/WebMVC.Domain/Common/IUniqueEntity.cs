namespace Web.Domain.Common
{
    public interface IUniqueDto : IDto
    {

        string Id { get; }

    }

    public interface IUniqueDto<out TData> : IUniqueDto, IDto<TData> { }
}