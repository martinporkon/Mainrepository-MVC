namespace Basket.Domain.Common
{
    public interface IDefinedEntity : INamedEntity
    {

        string Definition { get; }

    }
    public interface IDefinedEntity<out TData> : IDefinedEntity, IEntity<TData> { }
}