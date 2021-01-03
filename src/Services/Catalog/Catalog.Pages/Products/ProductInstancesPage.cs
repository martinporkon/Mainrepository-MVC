using Catalog.Data.Price;
using Catalog.Data.Product;
using Catalog.Domain.Prices;
using Catalog.Domain.Product;
using Catalog.Facade.Product;
using Catalog.Pages.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sooduskorv_MVC.Aids.Methods;
using System;
using System.Collections.Generic;

namespace Catalog.Pages.Products
{
    public sealed class ProductInstancesPage : ViewsPage<IProductInstancesRepository, IProductInstance, ProductInstanceView, ProductInstanceData>
    {
        public ProductInstancesPage(IProductInstancesRepository r,
           //IUnitsRepository u,
           IProductTypesRepository t,IPricesRepository p/* IPartyRepository p*/)
           : base(r, ProductPagesNames.ProductInstances)
        {
            productTypesRepository = t;
           
            Prices = newPricesList<Price, PriceData>(p);
            //Parties = newItemsList<Party, PartyData>(p);

            //Units = newItemsList<Unit, UnitData>(u);
        }
        // public IEnumerable<SelectListItem> Parties { get; }

        public IEnumerable<SelectListItem> Prices;
        private readonly IProductTypesRepository productTypesRepository;

        public string ProductTypeId { get; set; }
        //public IEnumerable<SelectListItem> Units { get; }
        public ProductKind ProductKind { get; internal set; }

       

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            ProductKind = Safe.Run(() => (ProductKind)(switchOfCreate ?? 1000), ProductKind.Unspecified);

            createItem();

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        private void createItem()
        {
            Item = new ProductInstanceView()
            {
                ProductKind = ProductKind,
                Id = Guid.NewGuid().ToString(),
            };
            //updateProductTypes();
        }

        //internal void updateProductTypes()
        //    => ProductTypes =
        //        newItemsList<IProductType, ProductTypeData>(productTypesRepository, d => d.ProductKind == ProductKind  );

        protected override Uri pageUrl() => new Uri(ProductPagesUrls.ProductInstances, UriKind.Relative);

        protected override IProductInstance toObject(ProductInstanceView view) => ProductInstanceViewFactory.Create(view);

        protected override ProductInstanceView toView(IProductInstance obj)
        {
            ProductKind = obj.ProductKind;
            ProductTypeId = obj.ProductTypeId;
            
            //updateProductTypes();
            return ProductInstanceViewFactory.Create(obj);
        }

       // public string ProductTypeName(string id) => itemName(ProductTypes, id);

        //public string UnitName(string id) => itemName(Units, id);

        public Uri CreateUri(ProductKind k) => createUri((int)k);



        private static string subTitle(string item, string name) => $"For {item} ({name})";

        private static string removeId(string idField) => idField?.Replace("Id", string.Empty) ?? string.Empty;

        public string priceAmount(string productInstanceId) {
            return itemPrice(Prices, productInstanceId).ToString();
        }
        

        public decimal itemPrice(IEnumerable<SelectListItem> list, string productInstanceId)
        {
            if (list is null) return 0;

            foreach (var m in list)
            {
                if (m.Value == productInstanceId)
                    return decimal.Round(Convert.ToDecimal(m.Text), 2, MidpointRounding.AwayFromZero);
            }
               

            return 0;
        }
    }
}
