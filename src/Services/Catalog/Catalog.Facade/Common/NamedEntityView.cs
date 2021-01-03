using System.ComponentModel.DataAnnotations;

namespace Catalog.Facade.Common
{
    public abstract class NamedEntityView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
    }
}