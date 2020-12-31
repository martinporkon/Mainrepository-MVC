namespace Nupp.Views.Home
{
    public class CartItemState : ViewState
    {
        //TODO siit saame kontrollida iga komponendi olekut kui lehte vahetatakse ning tullakse tagasi.
        public string SelectedButtons { get; set; }
        public string SelectedCss { get; set; }
    }
}