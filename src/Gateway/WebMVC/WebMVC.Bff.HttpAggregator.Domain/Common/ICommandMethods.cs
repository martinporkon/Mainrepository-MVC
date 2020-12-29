using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public interface ICommandMethods<in T>
    {
        Task Delete(string id);
        Task Add(T obj);
        Task Update(T obj);
    }
}