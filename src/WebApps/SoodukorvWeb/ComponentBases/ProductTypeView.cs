using System.Collections.Generic;

namespace SooduskorvWebMVC.ComponentBases
{
    public class ProductTypeView
    {
        public string Id { get; set; } = "1";
        public string Name { get; set; } = "2";
        public string Image { get; set; } = "3";
        public string BrandId { get; set; } = "4";
        public string Amount { get; set; } = "8";
        public string UnitId { get; set; } = "6";
        public List<PartyInstanceView> Parties { get; set; } = new List<PartyInstanceView>
        {
            new PartyInstanceView() { Name = "test2"},
            new PartyInstanceView() { Id = "123"},
        };
    }
}