using Catalog.Data.Price;
using Catalog.Data.Product;
using Catalog.Domain.Catalog;
using Catalog.Domain.Prices;
using Catalog.Domain.Product;
using Catalog.Facade.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Aids.Methods;
using System;
using System.Collections.Generic;

namespace Catalog.Pages.Products
{

    public sealed class
        CatalogPage : ViewsPage<IProductTypesRepository, IProductType, ProductTypeView, ProductTypeData>
    {

        public CatalogPage(IProductTypesRepository r, IBrandsRepository b, IProductInstancesRepository i, IPricesRepository c, IProductCategoriesRepository p)
            : base(r, ProductPagesNames.ProductTypes)
        {
            //Units = newItemsList<Unit, UnitData>(u);
            Prices = newPricesList<Price, PriceData>(c);
            Parties = newPartiesList<IProductType, ProductTypeData>(i);
            Brands = newItemsList<Brand, BrandData>(b);
            ProductInstances = newInstancesList<IProductType, ProductTypeData>(i);
            ProductTypes = newItemsList<IProductType, ProductTypeData>(db);
            CategoryNames = newItemsList<ProductCategory, ProductCategoryData>(p);
            Categories = newSubCategoriesList<ProductCategory, ProductCategoryData>(p);

        }
        public IEnumerable<SelectListItem> CategoryNames;
        public IEnumerable<SelectListItem> Prices;
        public ProductKind ProductKind { get; internal set; }
        public IEnumerable<SelectListItem> Categories { get; }
        public IEnumerable<SelectListItem> Units { get; }
        public IEnumerable<SelectListItem> Brands { get; }
        public IEnumerable<SelectListItem> Parties { get; }
        public IEnumerable<SelectListItem> ProductInstances { get; }

        protected override Uri pageUrl() => new Uri(ProductPagesUrls.ProductTypes, UriKind.Relative);

        protected override IProductType toObject(ProductTypeView view) => ProductTypeViewFactory.Create(view);

        protected override ProductTypeView toView(IProductType o)
        {
            ProductKind = o.ProductKind;
            return ProductTypeViewFactory.Create(o);
        }

       
        public Uri CreateUri(ProductKind k) => createUri((int)k);

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
            Item = new ProductTypeView()
            {
                ProductKind = ProductKind,
                Id = Guid.NewGuid().ToString(),
            };
            updateProductTypes();
        }

        internal void updateProductTypes() =>
            ProductTypes = newItemsList<IProductType, ProductTypeData>(db, d => d.ProductKind == ProductKind);

        public IEnumerable<SelectListItem> ProductTypes { get; private set; }

        public string BaseTypeName(string id) => itemName(ProductTypes, id);
        public string CategoryName(string id) => itemName(CategoryNames, id);

        public string UnitName(string id) => itemName(Units, id);
        public string BrandName(string id) => itemName(Brands, id);
        public string priceAmount(string productInstanceId)
        {
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
        public string getPartyId(string productInstanceId)
        {
            return partyId(Parties, productInstanceId);
        }

        public string partyId(IEnumerable<SelectListItem> list, string productInstanceId)
        {
            if (list is null) return Word.Undefined;

            foreach (var m in list)
            {
                if (m.Text == productInstanceId)
                    return m.Value;
            }


            return Word.Undefined;
        }



    }

}

