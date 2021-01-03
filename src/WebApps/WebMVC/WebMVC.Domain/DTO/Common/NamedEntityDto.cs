namespace Web.Domain.DTO.Common
{
    public abstract class NamedEntityDto : UniqueEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}