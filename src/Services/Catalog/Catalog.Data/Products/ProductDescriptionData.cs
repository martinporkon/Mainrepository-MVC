using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Data.Product
{
    [ComplexType]
    public class ProductDescriptionData
    {
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature4 { get; set; }
        public string Feature5 { get; set; }
        public string Feature6 { get; set; }
        public string Feature8 { get; set; }
    }
}