using System.Net.Http;

namespace Nupp2.Views.Home
{
    public class CatalogItemState : ViewState
    {
        public string SelectedButtons { get; set; }
        public string SelectedCss { get; set; }

        /*public ProductTypeView Product { get; set; }*/
    }
}