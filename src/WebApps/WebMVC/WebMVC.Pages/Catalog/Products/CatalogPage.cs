using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Aids.Methods;
using System;
using System.Collections.Generic;
using Web.Domain.Common.Catalog.Products;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalog.Products.ProductTypes;
using Web.Facade.Profiles.Catalog.Products;
using Web.Pages.Common;
using Web.Pages.Common.Const;

namespace Web.Pages.Catalog.Products
{

    public sealed class CatalogPage : ViewsPage<IProductTypesRepository, IProductType, ProductTypeView, ProductTypeDto>
    {
        public CatalogPage(IProductTypesRepository r)
            : base(r, ProductPagesNames.ProductTypes)
        {
            /*ProductTypes = newItemsList<IProductType, ProductTypeData>(db);*/
        }

        public IEnumerable<SelectListItem> ProductTypes { get; private set; }
        public ProductKind ProductKind { get; internal set; }
        protected override Uri pageUrl() => new Uri(ProductPagesUrls.ProductTypes, UriKind.Relative);

        protected override IProductType toObject(ProductTypeView view) => throw new NotImplementedException();

        protected override ProductTypeView toView(IProductType o)
        {
            throw new NotImplementedException();
        }

        public Uri CreateUri(ProductKind k) => createUri((int)k);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            ProductKind = Safe.Run(() => (ProductKind)(switchOfCreate ?? 1000), ProductKind.Unspecified);



            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

    }

}