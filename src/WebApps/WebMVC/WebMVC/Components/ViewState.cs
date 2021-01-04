using System;
using Web.Facade.Catalog.Products;

namespace SooduskorvWebMVC.Components
{
    public class ViewState
    {
        public ProductTypeView Product { get; set; }

        public event Action OnChange;

        public event Action OnRemove;

        public void NotifyStateChanged() => OnChange?.Invoke();
        public void NotifyStateRemoveChanged() => OnRemove?.Invoke();
    }
}