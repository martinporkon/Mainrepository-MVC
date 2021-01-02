using System.ComponentModel.DataAnnotations;

namespace Sooduskorv_MVC.Facade
{
    public abstract class UniqueEntityView
    {
        [Required]
        public string Id { get; set; } = "asd";
        public abstract string GetId();
    }
}
