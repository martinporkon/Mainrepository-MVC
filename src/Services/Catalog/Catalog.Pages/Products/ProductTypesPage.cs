using Aids.Methods;
using Catalog.Data.Product;
using Catalog.Domain.Product;
using Catalog.Facade.Product;
using Catalog.Pages;
using Catalog.Pages.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Catalog.Pages.Products
{

    public sealed class
        ProductTypesPage : ViewsPage<IProductTypesRepository, IProductType, ProductTypeView, ProductTypeData>
    {

        public ProductTypesPage(IProductTypesRepository r)
            : base(r, ProductPagesNames.ProductTypes)
        {
            //Units = newItemsList<Unit, UnitData>(u);
            ProductTypes = newItemsList<IProductType, ProductTypeData>(db);
        }

        protected internal override Uri pageUrl() => new Uri(ProductPagesUrls.ProductTypes, UriKind.Relative);

        protected internal override IProductType toObject(ProductTypeView view) => ProductTypeViewFactory.Create(view);

        protected internal override ProductTypeView toView(IProductType o)
        {
            ProductKind = o.ProductKind;
            return ProductTypeViewFactory.Create(o);
        }

        public ProductKind ProductKind { get; internal set; }

        public IEnumerable<SelectListItem> Units { get; }

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

        public string UnitName(string id) => itemName(Units, id);

    }

}

