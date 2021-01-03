namespace Web.Domain.DTO.Common
{
    public abstract class DefinedEntityDto : NamedEntityDto
    {
        public string Definition { get; set; }
    }
}