namespace Web.Domain.DTO.Common
{
    public abstract class NamedEntityData : UniqueEntityData, IUniqueNamedData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public interface IUniqueNamedData
    {
        public string Name { get; }
        public string Id { get; }

    }
}