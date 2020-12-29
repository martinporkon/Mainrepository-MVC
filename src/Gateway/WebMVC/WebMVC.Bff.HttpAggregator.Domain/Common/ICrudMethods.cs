namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public interface ICrudMethods<T> : ICommandMethods<T>, IQueryMethods<T>
    {

    }
}