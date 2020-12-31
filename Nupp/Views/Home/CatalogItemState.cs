using System.Net.Http;

namespace Nupp.Views.Home
{
    public class CatalogItemState : ViewState
    {
        public string SelectedButtons { get; set; }
        public string SelectedCss { get; set; }

        /*public ProductTypeView Product { get; set; }*/
    }
}