using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Facade.Profiles.CatalogView
{
    public class CatalogView
    {
        [Required]
        [DisplayName("Buy")]
        public string Id { get; set; }
    }
}