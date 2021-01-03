namespace SooduskorvWebMVC.Domain.DTO.Common
{
    public abstract class NamedDto : UniqueDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

}